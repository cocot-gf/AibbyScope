
namespace AibbyScopeViewer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.grpMode = new System.Windows.Forms.GroupBox();
      this.modeFft = new System.Windows.Forms.RadioButton();
      this.modeWave = new System.Windows.Forms.RadioButton();
      this.L_samplingRate = new System.Windows.Forms.Label();
      this.rateDouble = new System.Windows.Forms.Button();
      this.rateHalf = new System.Windows.Forms.Button();
      this.sampleSize = new System.Windows.Forms.ComboBox();
      this.L_sampleSize = new System.Windows.Forms.Label();
      this.L_qFormat = new System.Windows.Forms.Label();
      this.grpWindow = new System.Windows.Forms.GroupBox();
      this.winHann = new System.Windows.Forms.RadioButton();
      this.winRect = new System.Windows.Forms.RadioButton();
      this.L_uart = new System.Windows.Forms.Label();
      this.L_spi = new System.Windows.Forms.Label();
      this.uartList = new System.Windows.Forms.ComboBox();
      this.spiList = new System.Windows.Forms.ComboBox();
      this.L_dotClock = new System.Windows.Forms.Label();
      this.L_vSync = new System.Windows.Forms.Label();
      this.imgUpdate = new System.ComponentModel.BackgroundWorker();
      this.x0 = new System.Windows.Forms.Label();
      this.x10 = new System.Windows.Forms.Label();
      this.x1 = new System.Windows.Forms.Label();
      this.x3 = new System.Windows.Forms.Label();
      this.x2 = new System.Windows.Forms.Label();
      this.x7 = new System.Windows.Forms.Label();
      this.x6 = new System.Windows.Forms.Label();
      this.x5 = new System.Windows.Forms.Label();
      this.x4 = new System.Windows.Forms.Label();
      this.xUnit = new System.Windows.Forms.Label();
      this.x8 = new System.Windows.Forms.Label();
      this.x9 = new System.Windows.Forms.Label();
      this.pictWave = new System.Windows.Forms.PictureBox();
      this.curFreq = new System.Windows.Forms.Label();
      this.connSpi = new System.Windows.Forms.Button();
      this.connUart = new System.Windows.Forms.Button();
      this.refreshSpi = new System.Windows.Forms.Button();
      this.refreshUart = new System.Windows.Forms.Button();
      this.grpDraw = new System.Windows.Forms.GroupBox();
      this.drawLine = new System.Windows.Forms.RadioButton();
      this.drawBar = new System.Windows.Forms.RadioButton();
      this.xDelta = new System.Windows.Forms.Label();
      this.logPlot = new System.Windows.Forms.CheckBox();
      this.y4 = new System.Windows.Forms.Label();
      this.y0 = new System.Windows.Forms.Label();
      this.y2 = new System.Windows.Forms.Label();
      this.y1 = new System.Windows.Forms.Label();
      this.y3 = new System.Windows.Forms.Label();
      this.fps = new System.Windows.Forms.Label();
      this.fpsNotify = new System.Windows.Forms.Timer(this.components);
      this.useGap = new System.Windows.Forms.CheckBox();
      this.vSync = new AibbyScopeViewer.NumericUpDownFix();
      this.dotClock = new AibbyScopeViewer.NumericUpDownFix();
      this.qFormat = new AibbyScopeViewer.NumericUpDownFix();
      this.samplingRate = new AibbyScopeViewer.NumericUpDownFix();
      this.grpMode.SuspendLayout();
      this.grpWindow.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictWave)).BeginInit();
      this.grpDraw.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.vSync)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dotClock)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.qFormat)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.samplingRate)).BeginInit();
      this.SuspendLayout();
      // 
      // grpMode
      // 
      this.grpMode.Controls.Add(this.modeFft);
      this.grpMode.Controls.Add(this.modeWave);
      this.grpMode.Location = new System.Drawing.Point(11, 6);
      this.grpMode.Name = "grpMode";
      this.grpMode.Size = new System.Drawing.Size(96, 46);
      this.grpMode.TabIndex = 0;
      this.grpMode.TabStop = false;
      this.grpMode.Text = "Mode";
      // 
      // modeFft
      // 
      this.modeFft.Appearance = System.Windows.Forms.Appearance.Button;
      this.modeFft.Checked = true;
      this.modeFft.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.modeFft.Location = new System.Drawing.Point(54, 18);
      this.modeFft.Name = "modeFft";
      this.modeFft.Size = new System.Drawing.Size(36, 22);
      this.modeFft.TabIndex = 1;
      this.modeFft.TabStop = true;
      this.modeFft.Text = "FFT";
      this.modeFft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.modeFft.UseVisualStyleBackColor = true;
      this.modeFft.CheckedChanged += new System.EventHandler(this.modeFft_CheckedChanged);
      // 
      // modeWave
      // 
      this.modeWave.Appearance = System.Windows.Forms.Appearance.Button;
      this.modeWave.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.modeWave.Location = new System.Drawing.Point(6, 18);
      this.modeWave.Name = "modeWave";
      this.modeWave.Size = new System.Drawing.Size(42, 22);
      this.modeWave.TabIndex = 0;
      this.modeWave.Text = "Wave";
      this.modeWave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.modeWave.UseVisualStyleBackColor = true;
      this.modeWave.CheckedChanged += new System.EventHandler(this.modeWave_CheckedChanged);
      // 
      // L_samplingRate
      // 
      this.L_samplingRate.AutoSize = true;
      this.L_samplingRate.Location = new System.Drawing.Point(118, 10);
      this.L_samplingRate.Name = "L_samplingRate";
      this.L_samplingRate.Size = new System.Drawing.Size(79, 12);
      this.L_samplingRate.TabIndex = 1;
      this.L_samplingRate.Text = "Sampling Rate";
      // 
      // rateDouble
      // 
      this.rateDouble.Location = new System.Drawing.Point(203, 8);
      this.rateDouble.Name = "rateDouble";
      this.rateDouble.Size = new System.Drawing.Size(21, 19);
      this.rateDouble.TabIndex = 3;
      this.rateDouble.Text = "×";
      this.rateDouble.UseVisualStyleBackColor = true;
      this.rateDouble.Click += new System.EventHandler(this.rateDouble_Click);
      // 
      // rateHalf
      // 
      this.rateHalf.Location = new System.Drawing.Point(203, 33);
      this.rateHalf.Name = "rateHalf";
      this.rateHalf.Size = new System.Drawing.Size(21, 19);
      this.rateHalf.TabIndex = 4;
      this.rateHalf.Text = "÷";
      this.rateHalf.UseVisualStyleBackColor = true;
      this.rateHalf.Click += new System.EventHandler(this.rateHalf_Click);
      // 
      // sampleSize
      // 
      this.sampleSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.sampleSize.FormattingEnabled = true;
      this.sampleSize.Items.AddRange(new object[] {
            "1024",
            "512",
            "256",
            "128",
            "64",
            "32",
            "16",
            "8",
            "4"});
      this.sampleSize.Location = new System.Drawing.Point(236, 32);
      this.sampleSize.Name = "sampleSize";
      this.sampleSize.Size = new System.Drawing.Size(65, 20);
      this.sampleSize.TabIndex = 6;
      this.sampleSize.SelectedIndexChanged += new System.EventHandler(this.sampleSize_SelectedIndexChanged);
      // 
      // L_sampleSize
      // 
      this.L_sampleSize.AutoSize = true;
      this.L_sampleSize.Location = new System.Drawing.Point(236, 10);
      this.L_sampleSize.Name = "L_sampleSize";
      this.L_sampleSize.Size = new System.Drawing.Size(67, 12);
      this.L_sampleSize.TabIndex = 5;
      this.L_sampleSize.Text = "Sample Size";
      // 
      // L_qFormat
      // 
      this.L_qFormat.Location = new System.Drawing.Point(314, 6);
      this.L_qFormat.Name = "L_qFormat";
      this.L_qFormat.Size = new System.Drawing.Size(59, 24);
      this.L_qFormat.TabIndex = 7;
      this.L_qFormat.Text = "Attenuator\r\n0 dB";
      this.L_qFormat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // grpWindow
      // 
      this.grpWindow.Controls.Add(this.winHann);
      this.grpWindow.Controls.Add(this.winRect);
      this.grpWindow.Location = new System.Drawing.Point(381, 6);
      this.grpWindow.Name = "grpWindow";
      this.grpWindow.Size = new System.Drawing.Size(98, 46);
      this.grpWindow.TabIndex = 9;
      this.grpWindow.TabStop = false;
      this.grpWindow.Text = "Window";
      // 
      // winHann
      // 
      this.winHann.Appearance = System.Windows.Forms.Appearance.Button;
      this.winHann.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.winHann.Location = new System.Drawing.Point(51, 18);
      this.winHann.Name = "winHann";
      this.winHann.Size = new System.Drawing.Size(41, 22);
      this.winHann.TabIndex = 1;
      this.winHann.Text = "Hann";
      this.winHann.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.winHann.UseVisualStyleBackColor = true;
      this.winHann.CheckedChanged += new System.EventHandler(this.winHann_CheckedChanged);
      // 
      // winRect
      // 
      this.winRect.Appearance = System.Windows.Forms.Appearance.Button;
      this.winRect.Checked = true;
      this.winRect.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.winRect.Location = new System.Drawing.Point(6, 18);
      this.winRect.Name = "winRect";
      this.winRect.Size = new System.Drawing.Size(39, 22);
      this.winRect.TabIndex = 0;
      this.winRect.TabStop = true;
      this.winRect.Text = "Rect";
      this.winRect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.winRect.UseVisualStyleBackColor = true;
      this.winRect.CheckedChanged += new System.EventHandler(this.winRect_CheckedChanged);
      // 
      // L_uart
      // 
      this.L_uart.AutoSize = true;
      this.L_uart.Location = new System.Drawing.Point(639, 11);
      this.L_uart.Name = "L_uart";
      this.L_uart.Size = new System.Drawing.Size(36, 12);
      this.L_uart.TabIndex = 13;
      this.L_uart.Text = "UART";
      // 
      // L_spi
      // 
      this.L_spi.AutoSize = true;
      this.L_spi.Location = new System.Drawing.Point(640, 36);
      this.L_spi.Name = "L_spi";
      this.L_spi.Size = new System.Drawing.Size(22, 12);
      this.L_spi.TabIndex = 17;
      this.L_spi.Text = "SPI";
      // 
      // uartList
      // 
      this.uartList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.uartList.DropDownWidth = 271;
      this.uartList.FormattingEnabled = true;
      this.uartList.Location = new System.Drawing.Point(681, 7);
      this.uartList.Name = "uartList";
      this.uartList.Size = new System.Drawing.Size(200, 20);
      this.uartList.TabIndex = 14;
      // 
      // spiList
      // 
      this.spiList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.spiList.DropDownWidth = 271;
      this.spiList.FormattingEnabled = true;
      this.spiList.Location = new System.Drawing.Point(681, 33);
      this.spiList.Name = "spiList";
      this.spiList.Size = new System.Drawing.Size(200, 20);
      this.spiList.TabIndex = 18;
      // 
      // L_dotClock
      // 
      this.L_dotClock.AutoSize = true;
      this.L_dotClock.Location = new System.Drawing.Point(962, 7);
      this.L_dotClock.Name = "L_dotClock";
      this.L_dotClock.Size = new System.Drawing.Size(52, 12);
      this.L_dotClock.TabIndex = 21;
      this.L_dotClock.Text = "DotClock";
      // 
      // L_vSync
      // 
      this.L_vSync.AutoSize = true;
      this.L_vSync.Location = new System.Drawing.Point(962, 26);
      this.L_vSync.Name = "L_vSync";
      this.L_vSync.Size = new System.Drawing.Size(44, 12);
      this.L_vSync.TabIndex = 23;
      this.L_vSync.Text = "V-Sync";
      // 
      // imgUpdate
      // 
      this.imgUpdate.WorkerSupportsCancellation = true;
      this.imgUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.imgUpdate_DoWork);
      this.imgUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.imgUpdate_RunWorkerCompleted);
      // 
      // x0
      // 
      this.x0.BackColor = System.Drawing.Color.Black;
      this.x0.ForeColor = System.Drawing.Color.Lime;
      this.x0.Location = new System.Drawing.Point(39, 331);
      this.x0.Name = "x0";
      this.x0.Size = new System.Drawing.Size(11, 12);
      this.x0.TabIndex = 31;
      this.x0.Text = "0";
      // 
      // x10
      // 
      this.x10.BackColor = System.Drawing.Color.Black;
      this.x10.ForeColor = System.Drawing.Color.Lime;
      this.x10.Location = new System.Drawing.Point(1033, 331);
      this.x10.Name = "x10";
      this.x10.Size = new System.Drawing.Size(45, 12);
      this.x10.TabIndex = 43;
      this.x10.Text = "10";
      this.x10.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // x1
      // 
      this.x1.BackColor = System.Drawing.Color.Black;
      this.x1.ForeColor = System.Drawing.Color.Lime;
      this.x1.Location = new System.Drawing.Point(125, 331);
      this.x1.Name = "x1";
      this.x1.Size = new System.Drawing.Size(45, 12);
      this.x1.TabIndex = 33;
      this.x1.Text = "1";
      this.x1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // x3
      // 
      this.x3.BackColor = System.Drawing.Color.Black;
      this.x3.ForeColor = System.Drawing.Color.Lime;
      this.x3.Location = new System.Drawing.Point(330, 331);
      this.x3.Name = "x3";
      this.x3.Size = new System.Drawing.Size(45, 12);
      this.x3.TabIndex = 35;
      this.x3.Text = "3";
      this.x3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // x2
      // 
      this.x2.BackColor = System.Drawing.Color.Black;
      this.x2.ForeColor = System.Drawing.Color.Lime;
      this.x2.Location = new System.Drawing.Point(227, 331);
      this.x2.Name = "x2";
      this.x2.Size = new System.Drawing.Size(45, 12);
      this.x2.TabIndex = 34;
      this.x2.Text = "2";
      this.x2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // x7
      // 
      this.x7.BackColor = System.Drawing.Color.Black;
      this.x7.ForeColor = System.Drawing.Color.Lime;
      this.x7.Location = new System.Drawing.Point(739, 331);
      this.x7.Name = "x7";
      this.x7.Size = new System.Drawing.Size(45, 12);
      this.x7.TabIndex = 39;
      this.x7.Text = "7";
      this.x7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // x6
      // 
      this.x6.BackColor = System.Drawing.Color.Black;
      this.x6.ForeColor = System.Drawing.Color.Lime;
      this.x6.Location = new System.Drawing.Point(637, 331);
      this.x6.Name = "x6";
      this.x6.Size = new System.Drawing.Size(45, 12);
      this.x6.TabIndex = 38;
      this.x6.Text = "6";
      this.x6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // x5
      // 
      this.x5.BackColor = System.Drawing.Color.Black;
      this.x5.ForeColor = System.Drawing.Color.Lime;
      this.x5.Location = new System.Drawing.Point(535, 331);
      this.x5.Name = "x5";
      this.x5.Size = new System.Drawing.Size(45, 12);
      this.x5.TabIndex = 37;
      this.x5.Text = "5";
      this.x5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // x4
      // 
      this.x4.BackColor = System.Drawing.Color.Black;
      this.x4.ForeColor = System.Drawing.Color.Lime;
      this.x4.Location = new System.Drawing.Point(432, 331);
      this.x4.Name = "x4";
      this.x4.Size = new System.Drawing.Size(45, 12);
      this.x4.TabIndex = 36;
      this.x4.Text = "4";
      this.x4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // xUnit
      // 
      this.xUnit.BackColor = System.Drawing.Color.Black;
      this.xUnit.ForeColor = System.Drawing.Color.Lime;
      this.xUnit.Location = new System.Drawing.Point(1003, 331);
      this.xUnit.Name = "xUnit";
      this.xUnit.Size = new System.Drawing.Size(35, 12);
      this.xUnit.TabIndex = 42;
      this.xUnit.Text = "Hz";
      this.xUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // x8
      // 
      this.x8.BackColor = System.Drawing.Color.Black;
      this.x8.ForeColor = System.Drawing.Color.Lime;
      this.x8.Location = new System.Drawing.Point(842, 331);
      this.x8.Name = "x8";
      this.x8.Size = new System.Drawing.Size(45, 12);
      this.x8.TabIndex = 40;
      this.x8.Text = "8";
      this.x8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // x9
      // 
      this.x9.BackColor = System.Drawing.Color.Black;
      this.x9.ForeColor = System.Drawing.Color.Lime;
      this.x9.Location = new System.Drawing.Point(944, 331);
      this.x9.Name = "x9";
      this.x9.Size = new System.Drawing.Size(45, 12);
      this.x9.TabIndex = 41;
      this.x9.Text = "9";
      this.x9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // pictWave
      // 
      this.pictWave.BackColor = System.Drawing.Color.Black;
      this.pictWave.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictWave.Location = new System.Drawing.Point(8, 62);
      this.pictWave.Name = "pictWave";
      this.pictWave.Size = new System.Drawing.Size(1072, 285);
      this.pictWave.TabIndex = 21;
      this.pictWave.TabStop = false;
      this.pictWave.Tag = "0";
      this.pictWave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictWave_MouseDown);
      this.pictWave.MouseLeave += new System.EventHandler(this.pictWave_MouseLeave);
      this.pictWave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictWave_MouseMove);
      // 
      // curFreq
      // 
      this.curFreq.AutoSize = true;
      this.curFreq.BackColor = System.Drawing.Color.Black;
      this.curFreq.ForeColor = System.Drawing.Color.Lime;
      this.curFreq.Location = new System.Drawing.Point(657, 48);
      this.curFreq.Name = "curFreq";
      this.curFreq.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.curFreq.Size = new System.Drawing.Size(18, 14);
      this.curFreq.TabIndex = 44;
      this.curFreq.Text = "Hz";
      this.curFreq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.curFreq.Visible = false;
      // 
      // connSpi
      // 
      this.connSpi.Image = global::AibbyScopeViewer.Properties.Resources.conn;
      this.connSpi.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.connSpi.Location = new System.Drawing.Point(923, 33);
      this.connSpi.Name = "connSpi";
      this.connSpi.Size = new System.Drawing.Size(29, 20);
      this.connSpi.TabIndex = 20;
      this.connSpi.Tag = "0";
      this.connSpi.UseVisualStyleBackColor = true;
      this.connSpi.Click += new System.EventHandler(this.connSpi_Click);
      // 
      // connUart
      // 
      this.connUart.Image = global::AibbyScopeViewer.Properties.Resources.conn;
      this.connUart.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.connUart.Location = new System.Drawing.Point(923, 7);
      this.connUart.Name = "connUart";
      this.connUart.Size = new System.Drawing.Size(29, 20);
      this.connUart.TabIndex = 16;
      this.connUart.UseVisualStyleBackColor = true;
      this.connUart.Click += new System.EventHandler(this.connUart_Click);
      // 
      // refreshSpi
      // 
      this.refreshSpi.Image = global::AibbyScopeViewer.Properties.Resources.refresh;
      this.refreshSpi.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.refreshSpi.Location = new System.Drawing.Point(887, 33);
      this.refreshSpi.Name = "refreshSpi";
      this.refreshSpi.Size = new System.Drawing.Size(29, 20);
      this.refreshSpi.TabIndex = 19;
      this.refreshSpi.UseVisualStyleBackColor = true;
      this.refreshSpi.Click += new System.EventHandler(this.refreshSpi_Click);
      // 
      // refreshUart
      // 
      this.refreshUart.Image = global::AibbyScopeViewer.Properties.Resources.refresh;
      this.refreshUart.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.refreshUart.Location = new System.Drawing.Point(887, 7);
      this.refreshUart.Name = "refreshUart";
      this.refreshUart.Size = new System.Drawing.Size(29, 20);
      this.refreshUart.TabIndex = 15;
      this.refreshUart.UseVisualStyleBackColor = true;
      this.refreshUart.Click += new System.EventHandler(this.refreshUart_Click);
      // 
      // grpDraw
      // 
      this.grpDraw.Controls.Add(this.drawLine);
      this.grpDraw.Controls.Add(this.drawBar);
      this.grpDraw.Location = new System.Drawing.Point(486, 6);
      this.grpDraw.Name = "grpDraw";
      this.grpDraw.Size = new System.Drawing.Size(93, 46);
      this.grpDraw.TabIndex = 10;
      this.grpDraw.TabStop = false;
      this.grpDraw.Text = "Draw Type";
      // 
      // drawLine
      // 
      this.drawLine.Appearance = System.Windows.Forms.Appearance.Button;
      this.drawLine.Checked = true;
      this.drawLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.drawLine.Location = new System.Drawing.Point(6, 18);
      this.drawLine.Name = "drawLine";
      this.drawLine.Size = new System.Drawing.Size(39, 22);
      this.drawLine.TabIndex = 0;
      this.drawLine.TabStop = true;
      this.drawLine.Text = "Line";
      this.drawLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.drawLine.UseVisualStyleBackColor = true;
      // 
      // drawBar
      // 
      this.drawBar.Appearance = System.Windows.Forms.Appearance.Button;
      this.drawBar.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.drawBar.Location = new System.Drawing.Point(51, 18);
      this.drawBar.Name = "drawBar";
      this.drawBar.Size = new System.Drawing.Size(36, 22);
      this.drawBar.TabIndex = 1;
      this.drawBar.Text = "Bar";
      this.drawBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.drawBar.UseVisualStyleBackColor = true;
      // 
      // xDelta
      // 
      this.xDelta.BackColor = System.Drawing.Color.Black;
      this.xDelta.ForeColor = System.Drawing.Color.Lime;
      this.xDelta.Location = new System.Drawing.Point(55, 331);
      this.xDelta.Name = "xDelta";
      this.xDelta.Size = new System.Drawing.Size(75, 12);
      this.xDelta.TabIndex = 32;
      this.xDelta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // logPlot
      // 
      this.logPlot.Appearance = System.Windows.Forms.Appearance.Button;
      this.logPlot.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.logPlot.Location = new System.Drawing.Point(589, 33);
      this.logPlot.Name = "logPlot";
      this.logPlot.Size = new System.Drawing.Size(41, 20);
      this.logPlot.TabIndex = 12;
      this.logPlot.Text = "Log";
      this.logPlot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.logPlot.UseVisualStyleBackColor = true;
      this.logPlot.CheckedChanged += new System.EventHandler(this.logPlot_CheckedChanged);
      // 
      // y4
      // 
      this.y4.BackColor = System.Drawing.Color.Black;
      this.y4.ForeColor = System.Drawing.Color.Lime;
      this.y4.Location = new System.Drawing.Point(10, 66);
      this.y4.Name = "y4";
      this.y4.Size = new System.Drawing.Size(30, 12);
      this.y4.TabIndex = 26;
      this.y4.Text = "255";
      this.y4.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // y0
      // 
      this.y0.BackColor = System.Drawing.Color.Black;
      this.y0.ForeColor = System.Drawing.Color.Lime;
      this.y0.Location = new System.Drawing.Point(10, 319);
      this.y0.Name = "y0";
      this.y0.Size = new System.Drawing.Size(30, 12);
      this.y0.TabIndex = 30;
      this.y0.Tag = "";
      this.y0.Text = "0";
      this.y0.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // y2
      // 
      this.y2.BackColor = System.Drawing.Color.Black;
      this.y2.ForeColor = System.Drawing.Color.Lime;
      this.y2.Location = new System.Drawing.Point(11, 192);
      this.y2.Name = "y2";
      this.y2.Size = new System.Drawing.Size(30, 12);
      this.y2.TabIndex = 28;
      this.y2.Text = "128";
      this.y2.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // y1
      // 
      this.y1.BackColor = System.Drawing.Color.Black;
      this.y1.ForeColor = System.Drawing.Color.Lime;
      this.y1.Location = new System.Drawing.Point(10, 235);
      this.y1.Name = "y1";
      this.y1.Size = new System.Drawing.Size(30, 12);
      this.y1.TabIndex = 29;
      this.y1.Text = "-48";
      this.y1.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.y1.Visible = false;
      // 
      // y3
      // 
      this.y3.BackColor = System.Drawing.Color.Black;
      this.y3.ForeColor = System.Drawing.Color.Lime;
      this.y3.Location = new System.Drawing.Point(10, 150);
      this.y3.Name = "y3";
      this.y3.Size = new System.Drawing.Size(30, 12);
      this.y3.TabIndex = 27;
      this.y3.Text = "-24";
      this.y3.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.y3.Visible = false;
      // 
      // fps
      // 
      this.fps.BackColor = System.Drawing.SystemColors.Window;
      this.fps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.fps.Location = new System.Drawing.Point(1021, 44);
      this.fps.Name = "fps";
      this.fps.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.fps.Size = new System.Drawing.Size(53, 16);
      this.fps.TabIndex = 25;
      this.fps.Text = "0 fps";
      this.fps.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // fpsNotify
      // 
      this.fpsNotify.Interval = 1000;
      this.fpsNotify.Tick += new System.EventHandler(this.fpsNotify_Tick);
      // 
      // useGap
      // 
      this.useGap.Appearance = System.Windows.Forms.Appearance.Button;
      this.useGap.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.useGap.Location = new System.Drawing.Point(589, 7);
      this.useGap.Name = "useGap";
      this.useGap.Size = new System.Drawing.Size(41, 20);
      this.useGap.TabIndex = 11;
      this.useGap.Text = "Gap";
      this.useGap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.useGap.UseVisualStyleBackColor = true;
      // 
      // vSync
      // 
      this.vSync.Location = new System.Drawing.Point(1021, 23);
      this.vSync.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
      this.vSync.Minimum = new decimal(new int[] {
            12500,
            0,
            0,
            0});
      this.vSync.Name = "vSync";
      this.vSync.Size = new System.Drawing.Size(58, 19);
      this.vSync.TabIndex = 24;
      this.vSync.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.vSync.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
      this.vSync.ValueChanged += new System.EventHandler(this.vSync_ValueChanged);
      // 
      // dotClock
      // 
      this.dotClock.Location = new System.Drawing.Point(1021, 2);
      this.dotClock.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.dotClock.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
      this.dotClock.Name = "dotClock";
      this.dotClock.Size = new System.Drawing.Size(58, 19);
      this.dotClock.TabIndex = 22;
      this.dotClock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.dotClock.Value = new decimal(new int[] {
            460,
            0,
            0,
            0});
      this.dotClock.ValueChanged += new System.EventHandler(this.dotClock_ValueChanged);
      // 
      // qFormat
      // 
      this.qFormat.Location = new System.Drawing.Point(316, 33);
      this.qFormat.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
      this.qFormat.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
      this.qFormat.Name = "qFormat";
      this.qFormat.Size = new System.Drawing.Size(53, 19);
      this.qFormat.TabIndex = 8;
      this.qFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.qFormat.ValueChanged += new System.EventHandler(this.qFormat_ValueChanged);
      // 
      // samplingRate
      // 
      this.samplingRate.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
      this.samplingRate.Location = new System.Drawing.Point(120, 33);
      this.samplingRate.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
      this.samplingRate.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
      this.samplingRate.Name = "samplingRate";
      this.samplingRate.Size = new System.Drawing.Size(77, 19);
      this.samplingRate.TabIndex = 2;
      this.samplingRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.samplingRate.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
      this.samplingRate.ValueChanged += new System.EventHandler(this.samplingRate_ValueChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1087, 352);
      this.Controls.Add(this.curFreq);
      this.Controls.Add(this.fps);
      this.Controls.Add(this.y3);
      this.Controls.Add(this.y1);
      this.Controls.Add(this.y2);
      this.Controls.Add(this.y0);
      this.Controls.Add(this.y4);
      this.Controls.Add(this.logPlot);
      this.Controls.Add(this.xDelta);
      this.Controls.Add(this.grpDraw);
      this.Controls.Add(this.x9);
      this.Controls.Add(this.x8);
      this.Controls.Add(this.xUnit);
      this.Controls.Add(this.x7);
      this.Controls.Add(this.x6);
      this.Controls.Add(this.x5);
      this.Controls.Add(this.x4);
      this.Controls.Add(this.x3);
      this.Controls.Add(this.x2);
      this.Controls.Add(this.x1);
      this.Controls.Add(this.x10);
      this.Controls.Add(this.x0);
      this.Controls.Add(this.pictWave);
      this.Controls.Add(this.vSync);
      this.Controls.Add(this.L_vSync);
      this.Controls.Add(this.dotClock);
      this.Controls.Add(this.L_dotClock);
      this.Controls.Add(this.connSpi);
      this.Controls.Add(this.connUart);
      this.Controls.Add(this.refreshSpi);
      this.Controls.Add(this.refreshUart);
      this.Controls.Add(this.spiList);
      this.Controls.Add(this.uartList);
      this.Controls.Add(this.L_spi);
      this.Controls.Add(this.L_uart);
      this.Controls.Add(this.grpWindow);
      this.Controls.Add(this.L_qFormat);
      this.Controls.Add(this.qFormat);
      this.Controls.Add(this.L_sampleSize);
      this.Controls.Add(this.sampleSize);
      this.Controls.Add(this.rateHalf);
      this.Controls.Add(this.rateDouble);
      this.Controls.Add(this.L_samplingRate);
      this.Controls.Add(this.samplingRate);
      this.Controls.Add(this.grpMode);
      this.Controls.Add(this.useGap);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Padding = new System.Windows.Forms.Padding(3);
      this.Text = "AibbyScopeViewer";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.grpMode.ResumeLayout(false);
      this.grpWindow.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictWave)).EndInit();
      this.grpDraw.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.vSync)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dotClock)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.qFormat)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.samplingRate)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMode;
        private AibbyScopeViewer.NumericUpDownFix samplingRate;
        private System.Windows.Forms.Label L_samplingRate;
        private System.Windows.Forms.Button rateDouble;
        private System.Windows.Forms.Button rateHalf;
        private System.Windows.Forms.ComboBox sampleSize;
        private System.Windows.Forms.Label L_sampleSize;
        private System.Windows.Forms.Label L_qFormat;
        private AibbyScopeViewer.NumericUpDownFix qFormat;
        private System.Windows.Forms.GroupBox grpWindow;
        private System.Windows.Forms.Label L_uart;
        private System.Windows.Forms.Label L_spi;
        private System.Windows.Forms.ComboBox uartList;
        private System.Windows.Forms.ComboBox spiList;
        private System.Windows.Forms.Button refreshSpi;
        private System.Windows.Forms.Button refreshUart;
        private System.Windows.Forms.Button connSpi;
        private System.Windows.Forms.Button connUart;
        private System.Windows.Forms.Label L_dotClock;
        private AibbyScopeViewer.NumericUpDownFix dotClock;
        private AibbyScopeViewer.NumericUpDownFix vSync;
        private System.Windows.Forms.Label L_vSync;
        private System.Windows.Forms.PictureBox pictWave;
        private System.Windows.Forms.RadioButton modeFft;
        private System.Windows.Forms.RadioButton modeWave;
        private System.Windows.Forms.RadioButton winHann;
        private System.Windows.Forms.RadioButton winRect;
        private System.ComponentModel.BackgroundWorker imgUpdate;
        private System.Windows.Forms.Label x0;
        private System.Windows.Forms.Label x10;
        private System.Windows.Forms.Label x1;
        private System.Windows.Forms.Label x3;
        private System.Windows.Forms.Label x2;
        private System.Windows.Forms.Label x7;
        private System.Windows.Forms.Label x6;
        private System.Windows.Forms.Label x5;
        private System.Windows.Forms.Label x4;
        private System.Windows.Forms.Label xUnit;
        private System.Windows.Forms.Label x8;
        private System.Windows.Forms.Label x9;
        private System.Windows.Forms.GroupBox grpDraw;
        private System.Windows.Forms.RadioButton drawLine;
        private System.Windows.Forms.RadioButton drawBar;
    private System.Windows.Forms.Label xDelta;
    private System.Windows.Forms.CheckBox logPlot;
    private System.Windows.Forms.Label y4;
    private System.Windows.Forms.Label y0;
    private System.Windows.Forms.Label y2;
    private System.Windows.Forms.Label y1;
    private System.Windows.Forms.Label y3;
    private System.Windows.Forms.Label fps;
    private System.Windows.Forms.Timer fpsNotify;
    private System.Windows.Forms.Label curFreq;
    private System.Windows.Forms.CheckBox useGap;
  }
}

