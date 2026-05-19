using LibMPSSE;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace AibbyScopeViewer {
  public partial class MainForm : Form {
    string appName = typeof(MainForm).Assembly.GetName().Name;
    SerialPort com = null;
    IntPtr ft_handle = IntPtr.Zero;
    bool noTransmit = false;    // COMポートオープン時にTrueにしてコントロール更新時の送信を禁止させる
    Color colorLine = Color.FromArgb(255, 0, 0);
    Color colorDash = Color.FromArgb(192, 0, 0);
    Color colorWave = Color.FromArgb(0, 255, 0);
    Label[] xLabel;
    Pen penLine;
    Pen penDash;
    int smpSz;
    int gridDiv = 10;
    int fps_counter = 0;


    // メインスレッドからワーカースレッドへ渡すためのもの
    Bitmap bmp;
    //Graphics graph;

    public MainForm() {
      InitializeComponent();
      InitializeComponentEx();
    }

    private void InitializeComponentEx() {
      // 追加の初期化項目
      xLabel = new Label[] { x1, x2, x3, x4, x5, x6, x7, x8, x9, x10 };
      this.sampleSize.SelectedIndex = 0;
      refreshUartmList();
      refreshSpiList();

      penLine = new Pen(colorLine);
      penDash = new Pen(colorDash);
      penDash.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
      penDash.DashPattern = new float[] { 3f, 3f };

      bmp = new Bitmap(pictWave.Width, pictWave.Height);
      drawGrid(null, false);

      smpSz = int.Parse(sampleSize.SelectedItem.ToString());
    }

    private bool readAibbyState() {
      // UART経由でAibbyから状態を読み込んでフォームへ反映させる
      com.DiscardInBuffer();
      sendCommand("c");

      string[] state = com.ReadLine().Split(',');
      bool err = false;

      if (state.Length != 9) {
        err = true;
      }
      else {
        noTransmit = true;

        // mode
        switch (state[0]) {
          case "w":
            modeWave.Checked = true;
            break;

          case "f":
            modeFft.Checked = true;
            break;

          default:
            err = true;
            break;
        }

        // samplingRate
        if (state[1].Substring(0, 1) == "r") {
          try {
            samplingRate.Value = int.Parse(state[1].Substring(1));
          }
          catch (Exception) {
            err = true;
          }
        }

        // sampleSize
        if (state[2].Substring(0, 1) == "s") {
          try {
            int val = int.Parse(state[2].Substring(1));
            int i = 0;
            foreach (string item in sampleSize.Items) {
              if (item == val.ToString()) {
                sampleSize.SelectedIndex = i;
                break;
              }
              else {
                i++;
              }

              if (i > sampleSize.Items.Count) {
                err = true;
              }
            }
          }
          catch (Exception) {
            err = true;
          }
        }

        // Q-Format
        if (state[3].Substring(0, 1) == "q") {
          try {
            qFormat.Value = int.Parse(state[3].Substring(1)) - 4;
          }
          catch (Exception) {
            err = true;
          }
        }

        // Window
        switch (state[4]) {
          case "n":
            winRect.Checked = true;
            break;

          case "h":
            winHann.Checked = true;
            break;

          default:
            err = true;
            break;
        }

        // logPlot
        switch (state[5]) {
          case "b":
            logPlot.Checked = true;
            break;

          case "l":
            logPlot.Checked = false;
            break;

          default:
            err = true;
            break;
        }

        // dotTimer
        if (state[6].Substring(0, 1) == "d") {
          try {
            dotClock.Value = int.Parse(state[6].Substring(1));
          }
          catch (Exception) {
            err = true;
          }
        }

        // VSync
        if (state[7].Substring(0, 1) == "v") {
          try {
            vSync.Value = int.Parse(state[7].Substring(1));
          }
          catch (Exception) {
            err = true;
          }
        }

        // pause
        switch (state[8].Substring(0, 1)) {
          case "0":
            pictWave.Tag = 0;
            this.Text = $"{appName} - Pause";
            break;

          case "1":
            pictWave.Tag = 1;
            this.Text = $"{appName}";
            break;

          default:
            this.Text = $"{appName}";
            err = true;
            break;
        }

        noTransmit = false;
      } // state.Length == 9

      if (err) {
        MessageBox.Show("Aibbyの状態を正しく読み取れません。", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return !err;
    }

    private float calcVelocity(byte a, byte b) {
      // 対数変換
      float f = BitConverter.ToSingle(new byte[] { 0, 0, a, b }, 0);
      if (float.IsNaN(f) || float.IsInfinity(f) || f < 0) {
        f = 0;
      }

      return 3.541666667f * 20f * (float)Math.Log10((f + 1f) / 4095f);
    }  // 3.541fは-72dBを255で表示するための値

    private bool pollGpioLevel(byte value, byte mask) {
      // 指定されたレベルになるまで戻らない
      do {
        FT_STATUS ft_stat = GPIO.ReadGPIO(ft_handle, out byte data);
        if (ft_stat != FT_STATUS.OK) {
          MessageBox.Show($"ReadGPIO failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return false;
        }
        if ((data & mask) == value) {
          return true;
        }
        Thread.Sleep(1);
      } while (!imgUpdate.CancellationPending);

      return true;
    }
  }
}
