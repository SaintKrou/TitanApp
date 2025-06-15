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
            this.txtName = new System.Windows.Forms.TextBox();
            this.nudSessions = new System.Windows.Forms.NumericUpDown();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.nudMonths = new System.Windows.Forms.NumericUpDown();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSessions = new System.Windows.Forms.Label();
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudSessions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            this.SuspendLayout();

            // txtName
            this.txtName.Location = new System.Drawing.Point(160, 20);
            this.txtName.Size = new System.Drawing.Size(200, 27);

            // lblName
            this.lblName.Text = "Название:";
            this.lblName.Location = new System.Drawing.Point(20, 22);
            this.lblName.Size = new System.Drawing.Size(120, 23);

            // nudSessions
            this.nudSessions.Location = new System.Drawing.Point(160, 60);
            this.nudSessions.Maximum = 100;
            this.nudSessions.Minimum = 0;

            // lblSessions
            this.lblSessions.Text = "Кол-во занятий:";
            this.lblSessions.Location = new System.Drawing.Point(20, 62);
            this.lblSessions.Size = new System.Drawing.Size(120, 23);

            // chkUnlimited
            this.chkUnlimited.Text = "Безлимитный";
            this.chkUnlimited.Location = new System.Drawing.Point(160, 95);
            this.chkUnlimited.Size = new System.Drawing.Size(120, 24);

            // nudMonths
            this.nudMonths.Location = new System.Drawing.Point(160, 130);
            this.nudMonths.Maximum = 12;
            this.nudMonths.Minimum = 1;

            // lblMonths
            this.lblMonths.Text = "Длительность (мес):";
            this.lblMonths.Location = new System.Drawing.Point(20, 132);
            this.lblMonths.Size = new System.Drawing.Size(140, 23);

            // nudCost
            this.nudCost.Location = new System.Drawing.Point(160, 170);
            this.nudCost.Maximum = 100000;

            // lblCost
            this.lblCost.Text = "Цена (руб):";
            this.lblCost.Location = new System.Drawing.Point(20, 172);
            this.lblCost.Size = new System.Drawing.Size(120, 23);

            // btnSave
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(80, 220);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(200, 220);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // PurchaseEditForm
            this.ClientSize = new System.Drawing.Size(400, 270);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.nudSessions);
            this.Controls.Add(this.chkUnlimited);
            this.Controls.Add(this.nudMonths);
            this.Controls.Add(this.nudCost);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSessions);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.lblCost);
            this.Name = "PurchaseEditForm";
            this.Text = "Редактирование абонемента";

            ((System.ComponentModel.ISupportInitialize)(this.nudSessions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
