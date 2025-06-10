namespace TitanApp.Controls
{
    partial class AddClientControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtTelegram = new System.Windows.Forms.TextBox();
            this.lblTelegram = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.numSessions = new System.Windows.Forms.NumericUpDown();
            this.lblSessions = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(120, 15);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 1;
            this.txtId.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(20, 18);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(100, 15);
            this.lblId.Text = "ID:";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(20, 50);
            this.lblLastName.Text = "Фамилия:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(120, 47);
            this.txtLastName.Size = new System.Drawing.Size(200, 23);
            this.txtLastName.TabIndex = 0;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(20, 80);
            this.lblFirstName.Text = "Имя:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(120, 77);
            this.txtFirstName.Size = new System.Drawing.Size(200, 23);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.Location = new System.Drawing.Point(20, 110);
            this.lblMiddleName.Text = "Отчество:";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(120, 107);
            this.txtMiddleName.Size = new System.Drawing.Size(200, 23);
            this.txtMiddleName.TabIndex = 2;
            // 
            // lblTelegram
            // 
            this.lblTelegram.Location = new System.Drawing.Point(20, 140);
            this.lblTelegram.Text = "Telegram:";
            // 
            // txtTelegram
            // 
            this.txtTelegram.Location = new System.Drawing.Point(120, 137);
            this.txtTelegram.Size = new System.Drawing.Size(200, 23);
            this.txtTelegram.TabIndex = 3;
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(20, 170);
            this.lblComment.Text = "Комментарий:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(120, 167);
            this.txtComment.Size = new System.Drawing.Size(200, 23);
            this.txtComment.TabIndex = 4;
            // 
            // chkUnlimited
            // 
            this.chkUnlimited.Location = new System.Drawing.Point(120, 197);
            this.chkUnlimited.Text = "Безлимитный доступ";
            this.chkUnlimited.TabIndex = 5;
            // 
            // lblSessions
            // 
            this.lblSessions.Location = new System.Drawing.Point(20, 225);
            this.lblSessions.Text = "Куплено посещений:";
            // 
            // numSessions
            // 
            this.numSessions.Location = new System.Drawing.Point(160, 223);
            this.numSessions.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numSessions.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numSessions.Size = new System.Drawing.Size(60, 23);
            this.numSessions.TabIndex = 6;
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(20, 255);
            this.lblEnd.Text = "Окончание абонемента:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(190, 252);
            this.dtpEnd.Size = new System.Drawing.Size(200, 23);
            this.dtpEnd.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 290);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.TabIndex = 8;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddClientControl
            // 
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.txtTelegram);
            this.Controls.Add(this.lblTelegram);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.chkUnlimited);
            this.Controls.Add(this.lblSessions);
            this.Controls.Add(this.numSessions);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.btnSave);
            this.Name = "AddClientControl";
            this.Size = new System.Drawing.Size(420, 340);
            ((System.ComponentModel.ISupportInitialize)(this.numSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtTelegram;
        private System.Windows.Forms.Label lblTelegram;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.CheckBox chkUnlimited;
        private System.Windows.Forms.NumericUpDown numSessions;
        private System.Windows.Forms.Label lblSessions;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Button btnSave;
    }
}
