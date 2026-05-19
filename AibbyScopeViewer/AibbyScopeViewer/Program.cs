using LibMPSSE;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AibbyScopeViewer {
  static class Program {
    /// <summary>
    /// アプリケーションのメイン エントリ ポイントです。
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // DLL動的リンクの確立
      FT_STATUS ft_stat;
      string appName = typeof(MainForm).Assembly.GetName().Name;

      try {
        ft_stat = MPSSE.Ver_libMPSSE(out uint verMPSSE, out uint verD2XX);
        if (ft_stat != FT_STATUS.OK) {
          MessageBox.Show($"Ver_libMPSSE failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      catch (Exception ex) {
        if (ex.HResult == -2146233052) {
          MessageBox.Show("libmpsse.dll が見つかりませんでした。", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        if (ex.HResult == -2147024885) {
          MessageBox.Show("異なるアーキテクチャ(x86/x64)のlibmpsse.dllが検出されました。\r\n正しいDLLファイルをインストールしてください。", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else {
          MessageBox.Show(ex.Message, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return;
      }

      timeBeginPeriod(1);
      Application.Run(new MainForm());
      timeEndPeriod(1);
    }

    [DllImport("winmm.dll")] static extern int timeBeginPeriod(int period);
    [DllImport("winmm.dll")] static extern int timeEndPeriod(int period);
  }
}
