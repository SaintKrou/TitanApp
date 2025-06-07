namespace TitanApp
{
    partial class PurchaseAddForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numSessionsCount;
        private System.Windows.Forms.CheckBox chkUnlimited;
        private System.Windows.Forms.NumericUpDown numDurationMonths;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSessions;
        private System.Windows.Forms.Label lblUnlimited;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblCost;

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
            this.txtName = new System.Windows.Forms.TextBox();
            this.numSessionsCount = new System.Windows.Forms.NumericUpDown();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.numDurationMonths = new System.Windows.Forms.NumericUpDown();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSessions = new System.Windows.Forms.Label();
            this.lblUnlimited = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSessionsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            this.SuspendLayout();

            // lblName
            this.lblName.Text = "Название:";
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Size = new System.Drawing.Size(100, 23);

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 12);
            this.txtName.Size = new System.Drawing.Size(200, 23);

            // lblSessions
            this.lblSessions.Text = "Кол-во занятий:";
            this.lblSessions.Location = new System.Drawing.Point(12, 50);
            this.lblSessions.Size = new System.Drawing.Size(100, 23);

            // numSessionsCount
            this.numSessionsCount.Location = new System.Drawing.Point(120, 47);
            this.numSessionsCount.Maximum = 1000;

            // lblUnlimited
            this.lblUnlimited.Text = "Безлимит:";
            this.lblUnlimited.Location = new System.Drawing.Point(12, 85);
            this.lblUnlimited.Size = new System.Drawing.Size(100, 23);

            // chkUnlimited
            this.chkUnlimited.Location = new System.Drawing.Point(120, 82);

            // lblDuration
            this.lblDuration.Text = "Длительность (мес):";
            this.lblDuration.Location = new System.Drawing.Point(12, 120);
            this.lblDuration.Size = new System.Drawing.Size(100, 23);

            // numDurationMonths
            this.numDurationMonths.Location = new System.Drawing.Point(120, 117);
            this.numDurationMonths.Maximum = 60;

            // lblCost
            this.lblCost.Text = "Стоимость:";
            this.lblCost.Location = new System.Drawing.Point(12, 155);
            this.lblCost.Size = new System.Drawing.Size(100, 23);

            // numCost
            this.numCost.Location = new System.Drawing.Point(120, 152);
            this.numCost.Maximum = 1000000;
            this.numCost.DecimalPlaces = 2;
            this.numCost.Increment = 100;

            // btnSave
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(120, 190);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(220, 190);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // PurchaseForm
            this.ClientSize = new System.Drawing.Size(340, 240);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.numSessionsCount);
            this.Controls.Add(this.chkUnlimited);
            this.Controls.Add(this.numDurationMonths);
            this.Controls.Add(this.numCost);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSessions);
            this.Controls.Add(this.lblUnlimited);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblCost);
            this.Name = "PurchaseForm";
            this.Text = "Добавить/Редактировать покупку";
            ((System.ComponentModel.ISupportInitialize)(this.numSessionsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
