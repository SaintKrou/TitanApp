namespace TitanApp.Controls
{
    partial class PurchaseEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown nudSessions;
        private System.Windows.Forms.CheckBox chkUnlimited;
        private System.Windows.Forms.NumericUpDown nudMonths;
        private System.Windows.Forms.NumericUpDown nudCost;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSessions;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblCost;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            nudSessions = new NumericUpDown();
            chkUnlimited = new CheckBox();
            nudMonths = new NumericUpDown();
            nudCost = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            lblSessions = new Label();
            lblMonths = new Label();
            lblCost = new Label();
            ((System.ComponentModel.ISupportInitialize)nudSessions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonths).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCost).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(174, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 27);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // nudSessions
            // 
            nudSessions.Location = new Point(174, 62);
            nudSessions.Name = "nudSessions";
            nudSessions.Size = new Size(120, 27);
            nudSessions.TabIndex = 1;
            //nudSessions.ValueChanged += this.nudSessions_ValueChanged;
            // 
            // chkUnlimited
            // 
            chkUnlimited.Location = new Point(174, 97);
            chkUnlimited.Name = "chkUnlimited";
            chkUnlimited.Size = new Size(120, 24);
            chkUnlimited.TabIndex = 2;
            chkUnlimited.Text = "Безлимитный";
            //chkUnlimited.CheckedChanged += this.chkUnlimited_CheckedChanged;
            // 
            // nudMonths
            // 
            nudMonths.Location = new Point(174, 132);
            nudMonths.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudMonths.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMonths.Name = "nudMonths";
            nudMonths.Size = new Size(120, 27);
            nudMonths.TabIndex = 3;
            nudMonths.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //nudMonths.ValueChanged += this.nudMonths_ValueChanged;
            // 
            // nudCost
            // 
            nudCost.Location = new Point(174, 172);
            nudCost.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCost.Name = "nudCost";
            nudCost.Size = new Size(120, 27);
            nudCost.TabIndex = 4;
            //nudCost.ValueChanged += this.nudCost_ValueChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(62, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(93, 38);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(240, 220);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 38);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(120, 23);
            lblName.TabIndex = 7;
            lblName.Text = "Название:";
            // 
            // lblSessions
            // 
            lblSessions.Location = new Point(20, 62);
            lblSessions.Name = "lblSessions";
            lblSessions.Size = new Size(120, 23);
            lblSessions.TabIndex = 8;
            lblSessions.Text = "Кол-во занятий:";
            // 
            // lblMonths
            // 
            lblMonths.Location = new Point(20, 132);
            lblMonths.Name = "lblMonths";
            lblMonths.Size = new Size(169, 23);
            lblMonths.TabIndex = 9;
            lblMonths.Text = "Длительность (мес):";
            // 
            // lblCost
            // 
            lblCost.Location = new Point(20, 172);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(120, 23);
            lblCost.TabIndex = 10;
            lblCost.Text = "Цена (руб):";
            // 
            // PurchaseEditForm
            // 
            ClientSize = new Size(400, 270);
            Controls.Add(txtName);
            Controls.Add(nudSessions);
            Controls.Add(chkUnlimited);
            Controls.Add(nudMonths);
            Controls.Add(nudCost);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(lblName);
            Controls.Add(lblSessions);
            Controls.Add(lblMonths);
            Controls.Add(lblCost);
            Name = "PurchaseEditForm";
            Text = "Редактирование абонемента";
            ((System.ComponentModel.ISupportInitialize)nudSessions).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonths).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
