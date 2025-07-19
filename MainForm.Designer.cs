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
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblNetworkStatus;
        private System.Windows.Forms.Label lblNotifications;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnPurchases = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblNetworkStatus = new System.Windows.Forms.Label();
            this.lblNotifications = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Location = new System.Drawing.Point(14, 67);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1097, 787);
            this.tabControlMain.TabIndex = 0;
            // 
            // btnClients
            // 
            this.btnClients.Location = new System.Drawing.Point(14, 16);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(103, 40);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Клиенты";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnPurchases
            // 
            this.btnPurchases.Location = new System.Drawing.Point(123, 16);
            this.btnPurchases.Name = "btnPurchases";
            this.btnPurchases.Size = new System.Drawing.Size(119, 40);
            this.btnPurchases.TabIndex = 2;
            this.btnPurchases.Text = "Абонементы";
            this.btnPurchases.UseVisualStyleBackColor = true;
            this.btnPurchases.Click += new System.EventHandler(this.btnPurchases_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(248, 16);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(103, 40);
            this.btnLogs.TabIndex = 3;
            this.btnLogs.Text = "Журнал";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(358, 16);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(183, 40);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Отчёт по абонементам";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(547, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(144, 40);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Экспорт клиентов";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(697, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(132, 40);
            this.btnImport.TabIndex = 11;
            this.btnImport.Text = "Импорт JSON";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnExit.Location = new System.Drawing.Point(1008, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 40);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblNetworkStatus
            // 
            this.lblNetworkStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblNetworkStatus.AutoSize = true;
            this.lblNetworkStatus.Location = new System.Drawing.Point(14, 867);
            this.lblNetworkStatus.Name = "lblNetworkStatus";
            this.lblNetworkStatus.Size = new System.Drawing.Size(179, 20);
            this.lblNetworkStatus.TabIndex = 6;
            this.lblNetworkStatus.Text = "Соединение: неизвестно";
            // 
            // lblNotifications
            // 
            this.lblNotifications.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.lblNotifications.AutoSize = true;
            this.lblNotifications.Location = new System.Drawing.Point(671, 867);
            this.lblNotifications.Name = "lblNotifications";
            this.lblNotifications.Size = new System.Drawing.Size(185, 20);
            this.lblNotifications.TabIndex = 9;
            this.lblNotifications.Text = "Уведомления: ожидание";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 908);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblNotifications);
            this.Controls.Add(this.lblNetworkStatus);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.btnPurchases);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1140, 944);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Титан";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
