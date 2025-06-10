namespace TitanApp.Controls
{
    partial class ClientListControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnMarkAttendance;
        private System.Windows.Forms.Button btnApplySubscription;
        private System.Windows.Forms.Button btnManagePurchases;
        private System.Windows.Forms.Button btnViewLogs;

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
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnMarkAttendance = new System.Windows.Forms.Button();
            this.btnApplySubscription = new System.Windows.Forms.Button();
            this.btnManagePurchases = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvClients
            // 
            this.dgvClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(10, 10);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(760, 350);
            this.dgvClients.TabIndex = 0;

            // 
            // btnAddClient
            // 
            this.btnAddClient.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnAddClient.Location = new System.Drawing.Point(10, 370);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(110, 30);
            this.btnAddClient.TabIndex = 1;
            this.btnAddClient.Text = "Добавить";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);

            // 
            // btnEditClient
            // 
            this.btnEditClient.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnEditClient.Location = new System.Drawing.Point(130, 370);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(110, 30);
            this.btnEditClient.TabIndex = 2;
            this.btnEditClient.Text = "Редактировать";
            this.btnEditClient.UseVisualStyleBackColor = true;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);

            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnDeleteClient.Location = new System.Drawing.Point(250, 370);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteClient.TabIndex = 3;
            this.btnDeleteClient.Text = "Удалить";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);

            // 
            // btnMarkAttendance
            // 
            this.btnMarkAttendance.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnMarkAttendance.Location = new System.Drawing.Point(370, 370);
            this.btnMarkAttendance.Name = "btnMarkAttendance";
            this.btnMarkAttendance.Size = new System.Drawing.Size(110, 30);
            this.btnMarkAttendance.TabIndex = 4;
            this.btnMarkAttendance.Text = "Отметить посещение";
            this.btnMarkAttendance.UseVisualStyleBackColor = true;
            this.btnMarkAttendance.Click += new System.EventHandler(this.btnMarkAttendance_Click);

            // 
            // btnApplySubscription
            // 
            this.btnApplySubscription.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnApplySubscription.Location = new System.Drawing.Point(490, 370);
            this.btnApplySubscription.Name = "btnApplySubscription";
            this.btnApplySubscription.Size = new System.Drawing.Size(140, 30);
            this.btnApplySubscription.TabIndex = 5;
            this.btnApplySubscription.Text = "Применить абонемент";
            this.btnApplySubscription.UseVisualStyleBackColor = true;
            this.btnApplySubscription.Click += new System.EventHandler(this.btnApplySubscription_Click);

            // 
            // btnManagePurchases
            // 
            this.btnManagePurchases.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnManagePurchases.Location = new System.Drawing.Point(640, 370);
            this.btnManagePurchases.Name = "btnManagePurchases";
            this.btnManagePurchases.Size = new System.Drawing.Size(130, 30);
            this.btnManagePurchases.TabIndex = 6;
            this.btnManagePurchases.Text = "Управление покупками";
            this.btnManagePurchases.UseVisualStyleBackColor = true;
            this.btnManagePurchases.Click += new System.EventHandler(this.btnManagePurchases_Click);

            // 
            // btnViewLogs
            // 
            this.btnViewLogs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnViewLogs.Location = new System.Drawing.Point(10, 410);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(150, 30);
            this.btnViewLogs.TabIndex = 7;
            this.btnViewLogs.Text = "Просмотр журнала";
            this.btnViewLogs.UseVisualStyleBackColor = true;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);

            // 
            // ClientListControl
            // 
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.btnEditClient);
            this.Controls.Add(this.btnDeleteClient);
            this.Controls.Add(this.btnMarkAttendance);
            this.Controls.Add(this.btnApplySubscription);
            this.Controls.Add(this.btnManagePurchases);
            this.Controls.Add(this.btnViewLogs);
            this.Name = "ClientListControl";
            this.Size = new System.Drawing.Size(780, 450);

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
