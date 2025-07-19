using System;
using System.Drawing;
using System.Windows.Forms;

namespace TitanApp.Controls
{
    partial class ClientListControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvClients;
        private Button btnAddClient;
        private Button btnEditClient;
        private Button btnDeleteClient;
        private Button btnMarkAttendance;
        private Button btnApplySubscription;
        private MonthCalendar calendar;
        private ListBox lstAttendanceDates;
        private Label lblAttendanceDates;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
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
            calendar = new MonthCalendar();
            lstAttendanceDates = new ListBox();
            lblAttendanceDates = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(10, 10);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(760, 350);
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
            // calendar
            // 
            calendar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            calendar.Location = new Point(780, 10);
            calendar.Name = "calendar";
            calendar.TabIndex = 6;
            // 
            // lstAttendanceDates
            // 
            lstAttendanceDates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lstAttendanceDates.Location = new Point(780, 215);
            lstAttendanceDates.Name = "lstAttendanceDates";
            lstAttendanceDates.Size = new Size(192, 164);
            lstAttendanceDates.TabIndex = 7;
            // 
            // lblAttendanceDates
            // 
            lblAttendanceDates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAttendanceDates.Location = new Point(780, 190);
            lblAttendanceDates.Name = "lblAttendanceDates";
            lblAttendanceDates.Size = new Size(200, 23);
            lblAttendanceDates.TabIndex = 7;
            lblAttendanceDates.Text = "Даты посещений:";
            // 
            // ClientListControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvClients);
            Controls.Add(btnAddClient);
            Controls.Add(btnEditClient);
            Controls.Add(btnDeleteClient);
            Controls.Add(btnMarkAttendance);
            Controls.Add(btnApplySubscription);
            Controls.Add(calendar);
            Controls.Add(lblAttendanceDates);
            Controls.Add(lstAttendanceDates);
            Name = "ClientListControl";
            Size = new Size(1010, 420);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }
    }
}
