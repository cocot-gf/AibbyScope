using System;
using System.Data;
using System.IO.Ports;
using System.Management;
using System.Threading;
using System.Windows.Forms;

namespace AibbyScopeViewer {
  public partial class MainForm : Form {
    private int refreshUartmList() {
      // COMは順不同で列挙されるので、DataTableを使って番号でソートしてからリストに追加する。
      using (ManagementObjectSearcher query = new ManagementObjectSearcher("Select * from Win32_PNPEntity Where (Name like '%(COM%)')"))
      using (DataTable table = new DataTable()) {
        ManagementObjectCollection queryCollection = query.Get();
        table.Columns.Add("Number", typeof(int));
        table.Columns.Add("Name", typeof(String));

        if (queryCollection.Count == 0) {
          table.Rows.Add(0, "No Device");
        }
        else {
          String portName;
          int portNumStart, portNumEnd, portNum;

          foreach (ManagementObject mo in queryCollection) {
            portName = mo["Name"].ToString();
            portNumStart = portName.LastIndexOf(" (COM") + 5;
            portNumEnd = portName.IndexOf(")", portNumStart);
            portNum = int.Parse(portName.Substring(portNumStart, portNumEnd - portNumStart));
            table.Rows.Add(portNum, "COM" + portNum + "：" + portName.Substring(0, portNumStart - 5));
          }
        }

        using (DataView view = new DataView(table)) {
          uartList.Items.Clear();

          view.Sort = "Number";
          foreach (DataRowView row in view) {
            uartList.Items.Add(row["Name"].ToString());
          }
        }

        uartList.SelectedIndex = 0;
        connUart.Enabled = queryCollection.Count > 0;
        return queryCollection.Count;
      }
    }

    private bool uartConnect() {
      connUart.Enabled = false;
      uartList.Enabled = false;
      refreshUart.Enabled = false;
      bool result = true;

      string portName = uartList.SelectedItem.ToString();
      string comName = portName.Substring(0, portName.IndexOf("："));

      try {
        com = new SerialPort(comName, 115200, Parity.None, 8, StopBits.One);
        com.ReadTimeout = 200;
        com.Open();
        com.DiscardInBuffer();
        com.Write("x");
        if (com.ReadLine() != "Aibby\r") {
          MessageBox.Show("このポートはAibby以外の機器につながっています。", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          result = false;
        }
      }
      catch (TimeoutException) {
        MessageBox.Show("Aibbyの応答がありません。", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        result = false;
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        com?.Dispose();
        com = null;
        result = false;
      }

      if (result) {
        connUart.Image = AibbyScopeViewer.Properties.Resources.disconn;
        connUart.Enabled = true;
      }
      else {
        comForceDisconnect();
      }

      return result;
    }

    private void comForceDisconnect() {
      try {
        com?.Write("x");
      }
      catch (Exception) {
        // 無視
      }
      try {
        com?.Close();
      }
      catch (Exception) {
        // 無視
      }
      try {
        com?.Dispose();
      }
      catch (Exception) {
        // 無視
      }
      com = null;

      connUart.Image = AibbyScopeViewer.Properties.Resources.conn;
      connUart.Enabled = true;
      uartList.Enabled = true;
      refreshUart.Enabled = true;
    }

    private void sendCommand(string s) {
      if (noTransmit || com is null) {
        return;
      }

      for (int i = 0; i < s.Length; i++) {
        try {
          com.Write(s.Substring(i, 1));
        }
        catch (Exception ex) {
          MessageBox.Show($"{com.PortName}: {ex.Message}", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          comForceDisconnect();
          return;
        }
        Thread.Sleep(8);
      }
    }
  }
}
