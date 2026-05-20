using LibMPSSE;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AibbyScopeViewer {
  public partial class MainForm : Form {
    private void xLabelTime() {
      xUnit.Text = "ms";
      xDelta.Text = $"[Δt：{String.Format("{0:#0.00}", 1000 / samplingRate.Value)}]";

      for (int i = 1; i <= gridDiv - 1; i++) {
        xLabel[i - 1].Text = String.Format("{0:#0.00}", 1024000 / gridDiv / (1024 / int.Parse(sampleSize.SelectedItem.ToString())) / samplingRate.Value * i);
      }
      xLabel[9].Text = String.Format("{0:#0.00}", 1024000 / (1024 / int.Parse(sampleSize.SelectedItem.ToString())) / samplingRate.Value);
      xLabelPosition();
    }

    private void xLabelFreq() {
      xUnit.Text = "Hz";
      xDelta.Text = $"[Δf：{String.Format("{0:#0.0}", (float)samplingRate.Value / int.Parse(sampleSize.Text)).Replace(".0", "")}]";

      for (int i = 1; i <= gridDiv - 1; i++) {
        xLabel[i - 1].Text = String.Format("{0:#0.0}", (float)samplingRate.Value * i * 10 / gridDiv / 20).Replace(".0", "");
      }
      xLabel[9].Text = String.Format("{0:#0}", samplingRate.Value * 10 / 20);
      xLabelPosition();
    }

    private void yLabelWave() {
      y4.Text = "2047";
      y2.Text = "0";
      y0.Text = "-2048";
      y3.Visible = false;
      y1.Visible = false;
      y4.Width = 35;
      y0.Width = 35;
    }

    private void yLabelFft() {
      y0.Width = 30;
      y4.Width = 30;

      if (logPlot.Checked) {
        y4.Text = "0dB";
        y2.Text = "";
        y0.Text = "-72";
        y3.Visible = true;
        y1.Visible = true;
      }
      else {
        y4.Text = "255";
        y2.Text = "128";
        y0.Text = "0";
        y3.Visible = false;
        y1.Visible = false;
      }
    }

    private void xLabelPosition() {
      if (gridDiv == 10) {
        x8.Visible = true;
        x9.Visible = true;
        for (int i = 0; i < gridDiv - 1; i++) {
          xLabel[i].Left = (int)(102.4f * (i + 1)) - 7 + 30;
        }
      }
      else {
        x8.Visible = false;
        x9.Visible = false;
        for (int i = 0; i < gridDiv - 1; i++) {
          xLabel[i].Left = (int)128 * (i + 1) - 7 + 30;
        }
      }
    }

    private void drawGrid(Graphics graph, bool yGrid) {
      bool selfGraph = false;
      if (graph is null) {
        selfGraph = true;
        graph = Graphics.FromImage(bmp);
        graph.Clear(Color.Black);
      }
      graph.DrawRectangle(penLine, 36, 6, 1025, 257);

      float max = 10240.0f / gridDiv;
      float div = max / 10f;
      float x = div + 36f;

      // X軸 FFTの1本目の補助線
      if (modeFft.Checked) {
        penDash.DashPattern = new float[] { 1f, 3f };
        graph.DrawLine(penDash, (int)(max / 20f) + 36, 7, (int)(max / 20f) + 36, 263);
      }

      // X軸の残り
      penDash.DashPattern = new float[] { 3f, 3f };
      for (int i = 1; i <= gridDiv; i++) {
        graph.DrawLine(penDash, (int)x, 7, (int)x, 263);
        x += div;
      }

      // Y軸
      if (yGrid) {
        // Log表示用
        for (int y = 1; y < 6; y++) {
          graph.DrawLine(penDash, 36, 6 + (int)(42.6667f * y), 1060, 6 + (int)(42.6667f * y));
        }
      }
      else {
        // それ以外
        for (int i = 1; i <= 7; i++) {
          graph.DrawLine(penDash, 36, 6 + i * 32, 1060, 6 + i * 32);
        }
      }

      if (selfGraph) {
        graph.Dispose();
        pictWave.Image = bmp;
      }
    }

    private void imgUpdate_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
      const int READMAX = 1024 + 2;
      const SPI.TransferOptions xfrOpts = SPI.TransferOptions.AssertCs | SPI.TransferOptions.NegateCs;

      FT_STATUS ft_stat;
      Graphics graph;
      byte[] rdBuf = new byte[READMAX];
      uint szXfrd;
      uint dataSize;

      using (Brush brushWave = new SolidBrush(colorWave))
      using (Pen penWave = new Pen(colorWave)) {

        // Graphic作成
        try {
          this.Invoke((MethodInvoker)(() => { pictWave.Image = bmp; }));
          graph = Graphics.FromImage(bmp);
        }
        catch (Exception) {
          return;
        }

        do {
          if (!pollGpioLevel(0, 1)) { // トリガーが戻るの待ち
            e.Cancel = true;
            break;
          }

          if (!pollGpioLevel(1, 1)) { // トリガーが入るの待ち
            e.Cancel = true;
            break;
          }

          // データサイズリード
          ft_stat = SPI.Read(ft_handle, rdBuf, 2, out szXfrd, xfrOpts);
          if (ft_stat != FT_STATUS.OK || szXfrd != 2) {
            MessageBox.Show($"SPI_Read failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
            break;
          }

          // ヘッダチェック
          if ((rdBuf[0] & 0xf0) != 0x50) {
            continue;
          }

          // データサイズチェック
          dataSize = (((uint)rdBuf[0] & 0x0f) << 8) + rdBuf[1];
          if (dataSize > READMAX) {
            continue;
          }

          // データリード
          ft_stat = SPI.Read(ft_handle, rdBuf, dataSize, out szXfrd, xfrOpts);
          if (ft_stat != FT_STATUS.OK || dataSize != szXfrd) {
            MessageBox.Show($"SPI_Read failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
            break;
          }

          // データが有効期間内に取得できたか
          ft_stat = GPIO.ReadGPIO(ft_handle, out byte data);
          if (ft_stat != FT_STATUS.OK) {
            MessageBox.Show($"SPI_Read failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
            break;
          }

          // 描画
          if ((data & 1) == 1) {
            graph.Clear(Color.Black);
            int x = 37;
            int dx = 1024 / smpSz;

            if (modeWave.Checked) {   // WAVE
              drawGrid(graph, false);

              if (drawLine.Checked) { // WAVE LINE
                int y = 262 - rdBuf[0];
                for (int i = 0; i < dataSize - 1; i++) {
                  int yPrev = y;
                  y = 262 - rdBuf[i + 1];
                  graph.DrawLine(penWave, x, yPrev, x + dx, y);
                  x += dx;
                }
                y = 262 - rdBuf[dataSize - 1];
                graph.DrawLine(penWave, x, y, x + dx, y);
              }
              else {                  // WAVE BAR
                int gap = (smpSz < 1024 && useGap.Checked) ? 1 : 0;
                for (int i = 0; i < dataSize; i++) {
                  int y = 262 - rdBuf[i];
                  if (y < 134) {
                    graph.FillRectangle(brushWave, x, y, dx - gap, 134 - y);
                  }
                  else {
                    graph.FillRectangle(brushWave, x, 134, dx - gap, y - 133);
                  }
                  x += dx;
                }
              }
            }
            else {                        // FFT
              drawGrid(graph, logPlot.Checked);
              dx *= 2;

              if (logPlot.Checked) {       // FFT LOG
                int y = (int)calcVelocity(rdBuf[0], rdBuf[1]);

                graph.FillRectangle(brushWave, 31, 7 - y, 4, 256 + y);

                if (drawLine.Checked) {    // FFT LOG LINE
                  y = (int)calcVelocity(rdBuf[2], rdBuf[3]);
                  for (int i = 1; i < (dataSize >> 1) - 1; i++) {
                    int yPrev = y;
                    y = (int)calcVelocity(rdBuf[(i << 1) + 2], rdBuf[(i << 1) + 3]);
                    graph.DrawLine(penWave, x, 7 - yPrev, x + dx, 7 - y);
                    x += dx;
                  }
                  y = (int)calcVelocity(rdBuf[dataSize - 2], rdBuf[dataSize - 1]);
                  graph.DrawLine(penWave, x, 7 - y, x + dx - 1, 262);
                }
                else {                    // FFT LOG BAR
                  int gap = useGap.Checked ? 1 : 0;
                  for (int i = 1; i < (dataSize >> 1); i++) {
                    y = (int)calcVelocity(rdBuf[(i << 1)], rdBuf[(i << 1) + 1]);
                    graph.FillRectangle(brushWave, x, 7 - y, dx - gap, 256 + y);
                    x += dx;
                  }
                }
              }
              else {                      // FFT LINEAR
                int y = rdBuf[0];
                graph.FillRectangle(brushWave, 31, 262 - y, 4, y + 1);

                if (drawLine.Checked) {   // FFT LINEAR LINE
                  y = 262 - rdBuf[1];
                  for (int i = 1; i < dataSize - 1; i++) {
                    int yPrev = y;
                    y = 262 - rdBuf[i + 1];
                    graph.DrawLine(penWave, x, yPrev, x + dx, y);
                    x += dx;
                  }
                  y = 262 - rdBuf[dataSize - 1];
                  graph.DrawLine(penWave, x, y, x + dx - 1, 262);
                }
                else {                    // FFT LINEAR BAR
                  int gap = useGap.Checked ? 1 : 0;
                  for (int i = 1; i < dataSize; i++) {
                    y = rdBuf[i];
                    graph.FillRectangle(brushWave, x, 262 - y, dx - gap, y + 1);
                    x += dx;
                  }
                }
              }
            }

            try {
              this.Invoke((MethodInvoker)(() => { pictWave.Image = bmp; }));
            }
            catch (Exception) {
              e.Cancel = true;
              break;
            }

            fps_counter++;
          } // 描画
        } while (!imgUpdate.CancellationPending);

        graph?.Dispose();
      } // using
      // DoWorkを抜けるとRunWorkerCompletedでSPIをクローズする。
    }
  }
}