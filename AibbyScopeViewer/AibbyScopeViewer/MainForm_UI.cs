using System;
using System.Windows.Forms;

namespace AibbyScopeViewer {
  public partial class MainForm : Form {

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      if (imgUpdate.IsBusy) {
        imgUpdate.CancelAsync();
      }

      comForceDisconnect();
      spiForceDisconnect();
      penDash.Dispose();
      penLine.Dispose();
    }

    private void modeWave_CheckedChanged(object sender, EventArgs e) {
      if (modeWave.Checked) {
        sendCommand("w");
        xLabelTime();
        yLabelWave();
        pictWave.Tag = 1;
        this.Text = $"{appName}";
        if (!imgUpdate.IsBusy) {
          drawGrid(null, false);
        }
      }
    }

    private void modeFft_CheckedChanged(object sender, EventArgs e) {
      if (modeFft.Checked) {
        sendCommand("f");
        xLabelFreq();
        yLabelFft();
        pictWave.Tag = 1;
        this.Text = $"{appName}";
        if (!imgUpdate.IsBusy) {
          drawGrid(null, logPlot.Checked);
        }
      }
    }

    private void samplingRate_ValueChanged(object sender, EventArgs e) {
      sendCommand($"r{(int)samplingRate.Value}\r");
      pictWave.Tag = 1;
      this.Text = $"{appName}";
      if (modeWave.Checked) {
        xLabelTime();
      }
      else if (modeFft.Checked) {
        xLabelFreq();
      }
    }

    private void rateDouble_Click(object sender, EventArgs e) {
      if (samplingRate.Value * 2 <= samplingRate.Maximum) {
        samplingRate.Value *= 2;
      }
    }

    private void rateHalf_Click(object sender, EventArgs e) {
      if (samplingRate.Value / 2 >= samplingRate.Minimum) {
        samplingRate.Value /= 2;
      }
    }

    private void sampleSize_SelectedIndexChanged(object sender, EventArgs e) {
      sendCommand($"s{sampleSize.Text}\r");

      int[] dotClk = { 460, 915, 1820, 3570, 6930, 13100, 23500, 39300, 65535 };
      dotClock.Value = dotClk[sampleSize.SelectedIndex];
      smpSz = int.Parse(sampleSize.SelectedItem.ToString());
      pictWave.Tag = 1;
      this.Text = $"{appName}";
      if (modeWave.Checked) {
        xLabelTime();
      }
      else if (modeFft.Checked) {
        xLabelFreq();
      }
    }

    private void qFormat_ValueChanged(object sender, EventArgs e) {
      sendCommand($"q{qFormat.Value + 4}\r");
      L_qFormat.Text = $"Attenuator\r\n{qFormat.Value * 6} dB";
      pictWave.Tag = 1;
      this.Text = $"{appName}";
    }

    private void winRect_CheckedChanged(object sender, EventArgs e) {
      if (winRect.Checked) {
        sendCommand("n");
        pictWave.Tag = 1;
        this.Text = $"{appName}";
      }
    }

    private void winHann_CheckedChanged(object sender, EventArgs e) {
      if (winHann.Checked) {
        sendCommand("h");
        pictWave.Tag = 1;
        this.Text = $"{appName}";
      }
    }

    private void refreshUart_Click(object sender, EventArgs e) {
      refreshUartmList();
    }

    private void refreshSpi_Click(object sender, EventArgs e) {
      refreshSpiList();
    }

    private void connUart_Click(object sender, EventArgs e) {
      if (com is null) {
        if (uartConnect() && !readAibbyState()) {
          comForceDisconnect();
        }
      }
      else {
        comForceDisconnect();
      }
    }

    private void connSpi_Click(object sender, EventArgs e) {
      if (ft_handle == IntPtr.Zero) {
        if (spiConnect()) {
          fpsNotify.Enabled = true;
          imgUpdate.RunWorkerAsync();
        }
        else {
          spiForceDisconnect();
        }
      }
      else {
        fpsNotify.Enabled = false;
        fps.Text = "0 fps";
        imgUpdate.CancelAsync();
        // ポートクローズはCancelAsyncでDoWorkを抜けたあとにRunWorkerCompletedで行う。
      }
    }
    private void imgUpdate_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
      spiForceDisconnect();
    }

    private void logPlot_CheckedChanged(object sender, EventArgs e) {
      sendCommand(logPlot.Checked ? "b" : "l");
      yLabelFft();
      pictWave.Tag = 1;
      this.Text = $"{appName}";
      if (!imgUpdate.IsBusy && modeFft.Checked) {
        drawGrid(null, logPlot.Checked);
      }
    }

    private void dotClock_ValueChanged(object sender, EventArgs e) {
      sendCommand($"d{dotClock.Value}\r");
      pictWave.Tag = 1;
      this.Text = $"{appName}";
    }

    private void vSync_ValueChanged(object sender, EventArgs e) {
      sendCommand($"v{vSync.Value}\r");
      pictWave.Tag = 1;
      this.Text = $"{appName}";
    }

    private void pictWave_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {  // 一時停止
        sendCommand(" ");

        if (com is null) {
          this.Text = $"{appName}";
          return;
        }
        else if (pictWave.Tag.ToString() == "0") {
          pictWave.Tag = 1;
          this.Text = $"{appName}";
        }
        else {
          pictWave.Tag = 0;
          this.Text = $"{appName} - Pause";
        }
      }
      else if (e.Button == MouseButtons.Middle) {  // Xグリッド幅変更
        gridDiv = (gridDiv == 10 ? 8 : 10);
        if (modeWave.Checked) {
          xLabelTime();
        }
        else if (modeFft.Checked) {
          xLabelFreq();
        }
      }
      else if (e.Button == MouseButtons.Right) {  // サンプリングレート自動設定
        if (modeWave.Checked || !curFreq.Visible) {
          return;
        }
        else {
          float freq = float.Parse(curFreq.Text.Split(' ')[0]);  // カーソルに表示中の周波数文字列から取得
          if (freq == 0) {
            return;
          }
          freq *= gridDiv * 2;
          while (freq < 250) {  // 最低リミット
            freq *= 2;
          }
          while (freq > 50000) {  // 最高リミット
            freq /= 2;
          }
          samplingRate.Value = (int)freq;
        }
      }

      if (!imgUpdate.IsBusy) {
        drawGrid(null, false);
      }
    }

    private void pictWave_MouseMove(object sender, MouseEventArgs e) {
      if (!modeFft.Checked) return;

      int x = e.X - 36;
      if (e.Y < 5 || e.Y > 265 || x < 0 || x > 1026) {
        curFreq.Visible = false;
        return;
      }

      // 周波数カーソル表示
      int div = sampleSize.SelectedIndex + 1;
      curFreq.Text = String.Format("{0:#0.0} Hz", x * samplingRate.Value / 2 / 1024).Replace(".0", "");
      if (x < 922) {
        curFreq.Left = x + 50;
      }
      else {
        curFreq.Left = x - 30;
      }
      curFreq.Top = e.Y + 40;
      curFreq.Visible = true;
    }

    private void pictWave_MouseLeave(object sender, EventArgs e) {
      curFreq.Visible = false;
    }

    private void fpsNotify_Tick(object sender, EventArgs e) {
      fps.Text = $"{fps_counter} fps";
      fps_counter = 0;
    }
  }
}
