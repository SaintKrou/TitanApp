namespace TitanApp.Controls
{
    partial class SubscriptionReportControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.ComboBox cbPurchase;
        private System.Windows.Forms.ComboBox cbPayment;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.FlowLayoutPanel panelFilters;
        private System.Windows.Forms.Panel bottomPanel;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            panelFilters = new FlowLayoutPanel();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            cbPurchase = new ComboBox();
            cbPayment = new ComboBox();
            dgvRecords = new DataGridView();
            bottomPanel = new Panel();
            lblSummary = new Label();
            btnExport = new Button();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(dtpFrom);
            panelFilters.Controls.Add(dtpTo);
            panelFilters.Controls.Add(cbPurchase);
            panelFilters.Controls.Add(cbPayment);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(0, 0);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(5);
            panelFilters.Size = new Size(800, 40);
            panelFilters.TabIndex = 2;
            panelFilters.WrapContents = false;
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(8, 8);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 23);
            dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(134, 8);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 23);
            dtpTo.TabIndex = 1;
            // 
            // cbPurchase
            // 
            cbPurchase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPurchase.Location = new Point(260, 8);
            cbPurchase.Name = "cbPurchase";
            cbPurchase.Size = new Size(160, 23);
            cbPurchase.TabIndex = 2;
            // 
            // cbPayment
            // 
            cbPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPayment.Location = new Point(426, 8);
            cbPayment.Name = "cbPayment";
            cbPayment.Size = new Size(160, 23);
            cbPayment.TabIndex = 3;
            // 
            // dgvRecords
            // 
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.AllowUserToDeleteRows = false;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.ColumnHeadersHeight = 29;
            dgvRecords.Dock = DockStyle.Fill;
            dgvRecords.Location = new Point(0, 40);
            dgvRecords.Name = "dgvRecords";
            dgvRecords.ReadOnly = true;
            dgvRecords.RowHeadersWidth = 51;
            dgvRecords.Size = new Size(800, 420);
            dgvRecords.TabIndex = 0;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(lblSummary);
            bottomPanel.Controls.Add(btnExport);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 460);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(5);
            bottomPanel.Size = new Size(800, 40);
            bottomPanel.TabIndex = 1;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Dock = DockStyle.Left;
            lblSummary.Location = new Point(5, 5);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(0, 15);
            lblSummary.TabIndex = 0;
            lblSummary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnExport
            // 
            btnExport.AutoSize = true;
            btnExport.Dock = DockStyle.Right;
            btnExport.Location = new Point(720, 5);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 30);
            btnExport.TabIndex = 1;
            btnExport.Text = "Экспорт";
            btnExport.Click += BtnExport_Click;
            // 
            // SubscriptionReportControl
            // 
            Controls.Add(dgvRecords);
            Controls.Add(bottomPanel);
            Controls.Add(panelFilters);
            Name = "SubscriptionReportControl";
            Size = new Size(800, 500);
            panelFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
