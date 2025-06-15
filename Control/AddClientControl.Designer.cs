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
            txtId = new TextBox();
            lblId = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtMiddleName = new TextBox();
            lblMiddleName = new Label();
            txtTelegram = new TextBox();
            lblTelegram = new Label();
            txtComment = new TextBox();
            lblComment = new Label();
            chkUnlimited = new CheckBox();
            numSessions = new NumericUpDown();
            lblSessions = new Label();
            dtpEnd = new DateTimePicker();
            lblEnd = new Label();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numSessions).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(137, 15);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 1;
            txtId.TabStop = false;
            // 
            // lblId
            // 
            lblId.Location = new Point(20, 18);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 26);
            lblId.TabIndex = 2;
            lblId.Text = "ID:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(137, 47);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 27);
            txtLastName.TabIndex = 0;
            // 
            // lblLastName
            // 
            lblLastName.Location = new Point(20, 50);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(100, 23);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Фамилия:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(137, 77);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 27);
            txtFirstName.TabIndex = 2;
            // 
            // lblFirstName
            // 
            lblFirstName.Location = new Point(20, 80);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(100, 23);
            lblFirstName.TabIndex = 4;
            lblFirstName.Text = "Имя:";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(137, 106);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(200, 27);
            txtMiddleName.TabIndex = 2;
            // 
            // lblMiddleName
            // 
            lblMiddleName.Location = new Point(20, 110);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(100, 23);
            lblMiddleName.TabIndex = 5;
            lblMiddleName.Text = "Отчество:";
            // 
            // txtTelegram
            // 
            txtTelegram.Location = new Point(137, 137);
            txtTelegram.Name = "txtTelegram";
            txtTelegram.Size = new Size(200, 27);
            txtTelegram.TabIndex = 3;
            // 
            // lblTelegram
            // 
            lblTelegram.Location = new Point(20, 140);
            lblTelegram.Name = "lblTelegram";
            lblTelegram.Size = new Size(100, 23);
            lblTelegram.TabIndex = 6;
            lblTelegram.Text = "Telegram:";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(137, 170);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(200, 27);
            txtComment.TabIndex = 4;
            // 
            // lblComment
            // 
            lblComment.Location = new Point(20, 170);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(111, 23);
            lblComment.TabIndex = 7;
            lblComment.Text = "Комментарий:";
            // 
            // chkUnlimited
            // 
            chkUnlimited.Location = new Point(233, 207);
            chkUnlimited.Name = "chkUnlimited";
            chkUnlimited.Size = new Size(104, 24);
            chkUnlimited.TabIndex = 5;
            chkUnlimited.Text = "Безлимитный доступ";
            // 
            // numSessions
            // 
            numSessions.Location = new Point(137, 204);
            numSessions.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSessions.Name = "numSessions";
            numSessions.Size = new Size(60, 27);
            numSessions.TabIndex = 6;
            // 
            // lblSessions
            // 
            lblSessions.Location = new Point(20, 202);
            lblSessions.Name = "lblSessions";
            lblSessions.Size = new Size(100, 23);
            lblSessions.TabIndex = 8;
            lblSessions.Text = "Куплено посещений:";
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(137, 233);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(200, 27);
            dtpEnd.TabIndex = 7;
            // 
            // lblEnd
            // 
            lblEnd.Location = new Point(20, 236);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(100, 23);
            lblEnd.TabIndex = 9;
            lblEnd.Text = "Окончание абонемента:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(158, 296);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // AddClientControl
            // 
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtTelegram);
            Controls.Add(lblTelegram);
            Controls.Add(txtComment);
            Controls.Add(lblComment);
            Controls.Add(chkUnlimited);
            Controls.Add(lblSessions);
            Controls.Add(numSessions);
            Controls.Add(lblEnd);
            Controls.Add(dtpEnd);
            Controls.Add(btnSave);
            Name = "AddClientControl";
            Size = new Size(420, 340);
            ((System.ComponentModel.ISupportInitialize)numSessions).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
