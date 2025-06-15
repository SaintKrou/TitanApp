namespace TitanApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnPurchases;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblNetworkStatus;
        private System.Windows.Forms.Label lblNotifications;
        private System.Windows.Forms.Label lblTelegramStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControlMain = new TabControl();
            btnClients = new Button();
            btnPurchases = new Button();
            btnLogs = new Button();
            btnReport = new Button();
            btnExit = new Button();
            lblNetworkStatus = new Label();
            lblNotifications = new Label();
            lblTelegramStatus = new Label();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlMain.Location = new Point(14, 67);
            tabControlMain.Margin = new Padding(3, 4, 3, 4);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1097, 787);
            tabControlMain.TabIndex = 0;
            // 
            // btnClients
            // 
            btnClients.Location = new Point(14, 16);
            btnClients.Margin = new Padding(3, 4, 3, 4);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(103, 40);
            btnClients.TabIndex = 1;
            btnClients.Text = "Клиенты";
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // btnPurchases
            // 
            btnPurchases.Location = new Point(123, 16);
            btnPurchases.Margin = new Padding(3, 4, 3, 4);
            btnPurchases.Name = "btnPurchases";
            btnPurchases.Size = new Size(119, 40);
            btnPurchases.TabIndex = 2;
            btnPurchases.Text = "Абонементы";
            btnPurchases.UseVisualStyleBackColor = true;
            btnPurchases.Click += btnPurchases_Click;
            // 
            // btnLogs
            // 
            btnLogs.Location = new Point(248, 16);
            btnLogs.Margin = new Padding(3, 4, 3, 4);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(103, 40);
            btnLogs.TabIndex = 3;
            btnLogs.Text = "Журнал";
            btnLogs.UseVisualStyleBackColor = true;
            btnLogs.Click += btnLogs_Click;
            // 
            // btnReport
            // 
            btnReport.Location = new Point(358, 16);
            btnReport.Margin = new Padding(3, 4, 3, 4);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(183, 40);
            btnReport.TabIndex = 4;
            btnReport.Text = "Отчёт по абонементам";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(1008, 16);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(103, 40);
            btnExit.TabIndex = 5;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblNetworkStatus
            // 
            lblNetworkStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblNetworkStatus.AutoSize = true;
            lblNetworkStatus.Location = new Point(14, 867);
            lblNetworkStatus.Name = "lblNetworkStatus";
            lblNetworkStatus.Size = new Size(127, 20);
            lblNetworkStatus.TabIndex = 6;
            lblNetworkStatus.Text = "Соединение: неизвестно";
            // 
            // lblNotifications
            // 
            lblNotifications.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblNotifications.AutoSize = true;
            lblNotifications.Location = new Point(671, 867);
            lblNotifications.Name = "lblNotifications";
            lblNotifications.Size = new Size(285, 20);
            lblNotifications.TabIndex = 9;
            lblNotifications.Text = "Уведомления: ожидание";
            // 
            // lblTelegramStatus
            // 
            lblTelegramStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTelegramStatus.AutoSize = true;
            lblTelegramStatus.Location = new Point(275, 867);
            lblTelegramStatus.Name = "lblTelegramStatus";
            lblTelegramStatus.Size = new Size(251, 20);
            lblTelegramStatus.TabIndex = 8;
            lblTelegramStatus.Text = "Telegram: запуск и инициализация";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 908);
            Controls.Add(lblTelegramStatus);
            Controls.Add(lblNotifications);
            Controls.Add(lblNetworkStatus);
            Controls.Add(btnExit);
            Controls.Add(btnReport);
            Controls.Add(btnLogs);
            Controls.Add(btnPurchases);
            Controls.Add(btnClients);
            Controls.Add(tabControlMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 944);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Титан";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
