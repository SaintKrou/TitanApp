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
            dgvClients = new DataGridView();
            btnAddClient = new Button();
            btnEditClient = new Button();
            btnDeleteClient = new Button();
            btnMarkAttendance = new Button();
            btnApplySubscription = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(10, 10);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(760, 350);
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.TabIndex = 0;
            // 
            // btnAddClient
            // 
            btnAddClient.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddClient.Location = new Point(10, 370);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(110, 30);
            btnAddClient.TabIndex = 1;
            btnAddClient.Text = "Добавить";
            btnAddClient.UseVisualStyleBackColor = true;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // btnEditClient
            // 
            btnEditClient.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditClient.Location = new Point(130, 370);
            btnEditClient.Name = "btnEditClient";
            btnEditClient.Size = new Size(132, 30);
            btnEditClient.TabIndex = 2;
            btnEditClient.Text = "Редактировать";
            btnEditClient.UseVisualStyleBackColor = true;
            btnEditClient.Click += btnEditClient_Click;
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteClient.Location = new Point(268, 370);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new Size(110, 30);
            btnDeleteClient.TabIndex = 3;
            btnDeleteClient.Text = "Удалить";
            btnDeleteClient.UseVisualStyleBackColor = true;
            btnDeleteClient.Click += btnDeleteClient_Click;
            // 
            // btnMarkAttendance
            // 
            btnMarkAttendance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnMarkAttendance.Location = new Point(409, 370);
            btnMarkAttendance.Name = "btnMarkAttendance";
            btnMarkAttendance.Size = new Size(169, 30);
            btnMarkAttendance.TabIndex = 4;
            btnMarkAttendance.Text = "Отметить посещение";
            btnMarkAttendance.UseVisualStyleBackColor = true;
            btnMarkAttendance.Click += btnMarkAttendance_Click;
            // 
            // btnApplySubscription
            // 
            btnApplySubscription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnApplySubscription.Location = new Point(584, 370);
            btnApplySubscription.Name = "btnApplySubscription";
            btnApplySubscription.Size = new Size(186, 30);
            btnApplySubscription.TabIndex = 5;
            btnApplySubscription.Text = "Применить абонемент";
            btnApplySubscription.UseVisualStyleBackColor = true;
            btnApplySubscription.Click += btnApplySubscription_Click;
            // 
            // ClientListControl
            // 
            Controls.Add(dgvClients);
            Controls.Add(btnAddClient);
            Controls.Add(btnEditClient);
            Controls.Add(btnDeleteClient);
            Controls.Add(btnMarkAttendance);
            Controls.Add(btnApplySubscription);
            Name = "ClientListControl";
            Size = new Size(780, 420);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);


        }
    }
}
