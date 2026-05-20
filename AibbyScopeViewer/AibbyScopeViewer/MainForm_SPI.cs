using LibMPSSE;
using System;
using System.Windows.Forms;

namespace AibbyScopeViewer {
  public partial class MainForm : Form {
    private int refreshSpiList() {
      FT_STATUS ft_stat = SPI.GetNumChannels(out uint numChannels);
      if (ft_stat != FT_STATUS.OK) {
        MessageBox.Show($"SPI_GetNumChannels failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        numChannels = 0;
      }

      spiList.Items.Clear();

      if (numChannels == 0) {
        spiList.Items.Add("No Device");
      }
      else {
        for (uint count = 0; count < numChannels; count++) {
          ft_stat = SPI.GetChannelInfo(count, out FT_DEVICE_LIST_INFO_NODE devInfo);
          if (ft_stat != FT_STATUS.OK) {
            MessageBox.Show($"SPI_GetChannelInfo failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            continue;
          }

          string menuText = $"SPI{count}：{devInfo.Description}";
          spiList.Items.Add(menuText);
        }
      }

      spiList.SelectedIndex = 0;
      connSpi.Enabled = numChannels > 0;
      return (int)numChannels;
    }

    private bool spiConnect() {
      connSpi.Enabled = false;
      spiList.Enabled = false;
      refreshSpi.Enabled = false;
      bool result = true;

      // チャネル番号妥当性チェック
      FT_STATUS ft_stat = SPI.GetNumChannels(out uint numChannels);
      if (ft_stat != FT_STATUS.OK) {
        MessageBox.Show($"SPI_GetNumChannels failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        result = false;
      }

      if (result && (uint)spiList.SelectedIndex >= numChannels) {
        MessageBox.Show($"ポート 'SPI{spiList.SelectedIndex}' は存在しません。", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        result = false;
      }

      // チャネルオープン
      if (result) {
        ft_stat = SPI.OpenChannel((uint)spiList.SelectedIndex, out ft_handle);
        if (ft_stat != FT_STATUS.OK) {
          MessageBox.Show($"SPI_OpenChannel failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          result = false;
        }
      }

      // 初期化
      if (result) {
        SPI.ChannelConfig cfg = new SPI.ChannelConfig(10000000, 1, 0);
        cfg.Options.SpiMode = SPI.SPIModes.Mode0;
        cfg.Options.CsPin = SPI.CSPins.DBUS3;
        cfg.Options.CsActiveLow = true;

        ft_stat = SPI.InitChannel(ft_handle, ref cfg);  // refの中身が書き換えられるがこのソフトでは問題なし
        if (ft_stat != FT_STATUS.OK) {
          MessageBox.Show($"SPI_InitChannel failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          result = false;
        }
      }

      if (result) {
        ft_stat = GPIO.WriteGPIO(ft_handle, 0, 0); // 全ピン入力、内部プルアップ
        if (ft_stat != FT_STATUS.OK) {
          MessageBox.Show($"FT_WriteGPIO failed ({ft_stat})", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          result = false;
        }
      }

      if (result) {
        connSpi.Image = AibbyScopeViewer.Properties.Resources.disconn;
        connSpi.Enabled = true;
      }
      else {
        spiForceDisconnect();
      }

      return result;
    }

    private void spiForceDisconnect() {
      // オープンされているチャネルをクローズしても、ハンドルはゼロクリアされない
      // 閉じられているハンドルをクローズするとFT_STATUS.OTHER_ERRORが返ってくる。
      // IntPtr.ZeroをクローズするとI2C_CloseChannel(): NULL expression encounteredが発生する。
      // ハンドルを指定してオープン済みか調べる術がない。I2C_GetChannelInfoはハンドルではなくチャネル番号が引数なので使えない。
      // 以上のことから、クローズした時はハンドルをIntPtr.Zeroに戻して、オープン済みかどうかを判定できるようにする。
      // オープンした状態でUSBケーブルを抜くと状態不一致で再オープンできないので、クローズでいったん閉じる事

      FT_STATUS ft_stat = FT_STATUS.OK;
      if (ft_handle != IntPtr.Zero) {
        ft_stat = SPI.CloseChannel(ft_handle);
        if (ft_stat != FT_STATUS.OK) {
          MessageBox.Show($"SPI_CloseChannel failed ({ft_stat})\r\n現在のデバイスハンドルを破棄しました。", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ft_handle = IntPtr.Zero;
      }

      connSpi.Image = AibbyScopeViewer.Properties.Resources.conn;
      connSpi.Enabled = true;
      spiList.Enabled = true;
      refreshSpi.Enabled = true;
    }
  }
}
