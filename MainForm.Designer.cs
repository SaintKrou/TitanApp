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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnPurchases = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblNetworkStatus = new System.Windows.Forms.Label();
            this.lblNotifications = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // tabControlMain
            this.tabControlMain.Location = new System.Drawing.Point(12, 50);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(960, 600);
            this.tabControlMain.TabIndex = 0;

            // btnClients
            this.btnClients.Location = new System.Drawing.Point(12, 12);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(90, 30);
            this.btnClients.Text = "Клиенты";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);

            // btnPurchases
            this.btnPurchases.Location = new System.Drawing.Point(108, 12);
            this.btnPurchases.Name = "btnPurchases";
            this.btnPurchases.Size = new System.Drawing.Size(90, 30);
            this.btnPurchases.Text = "Покупки";
            this.btnPurchases.UseVisualStyleBackColor = true;
            this.btnPurchases.Click += new System.EventHandler(this.btnPurchases_Click);

            // btnLogs
            this.btnLogs.Location = new System.Drawing.Point(204, 12);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(90, 30);
            this.btnLogs.Text = "Журнал";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);

            // btnReport
            this.btnReport.Location = new System.Drawing.Point(300, 12);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(130, 30);
            this.btnReport.Text = "Отчёт по абонементам";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);

            // btnExit
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(882, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 30);
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // lblNetworkStatus
            this.lblNetworkStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNetworkStatus.AutoSize = true;
            this.lblNetworkStatus.Location = new System.Drawing.Point(12, 655);
            this.lblNetworkStatus.Name = "lblNetworkStatus";
            this.lblNetworkStatus.Size = new System.Drawing.Size(87, 15);
            this.lblNetworkStatus.Text = "Сеть: неизвестно";

            // lblNotifications
            this.lblNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotifications.AutoSize = true;
            this.lblNotifications.Location = new System.Drawing.Point(780, 655);
            this.lblNotifications.Name = "lblNotifications";
            this.lblNotifications.Size = new System.Drawing.Size(192, 15);
            this.lblNotifications.Text = "Уведомления: всё работает нормально";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 681);
            this.Controls.Add(this.lblNotifications);
            this.Controls.Add(this.lblNetworkStatus);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.btnPurchases);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "TitanApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
