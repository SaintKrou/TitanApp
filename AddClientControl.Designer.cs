namespace TitanApp.Controls
{
    partial class AddClientControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtTelegram;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.NumericUpDown numSessions;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox chkUnlimited;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Label lblTelegram;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblSessions;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblUnlimited;

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
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtTelegram = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.numSessions = new System.Windows.Forms.NumericUpDown();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblTelegram = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblSessions = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblUnlimited = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // Label and control setup
            // 
            int y = 20;
            int spacing = 30;
            int labelWidth = 100;
            int inputX = 120;

            // LastName
            this.lblLastName.Text = "Фамилия:";
            this.lblLastName.Location = new System.Drawing.Point(20, y);
            this.txtLastName.Location = new System.Drawing.Point(inputX, y);
            y += spacing;

            // FirstName
            this.lblFirstName.Text = "Имя:";
            this.lblFirstName.Location = new System.Drawing.Point(20, y);
            this.txtFirstName.Location = new System.Drawing.Point(inputX, y);
            y += spacing;

            // MiddleName
            this.lblMiddleName.Text = "Отчество:";
            this.lblMiddleName.Location = new System.Drawing.Point(20, y);
            this.txtMiddleName.Location = new System.Drawing.Point(inputX, y);
            y += spacing;

            // Telegram
            this.lblTelegram.Text = "Telegram:";
            this.lblTelegram.Location = new System.Drawing.Point(20, y);
            this.txtTelegram.Location = new System.Drawing.Point(inputX, y);
            y += spacing;

            // Comment
            this.lblComment.Text = "Комментарий:";
            this.lblComment.Location = new System.Drawing.Point(20, y);
            this.txtComment.Location = new System.Drawing.Point(inputX, y);
            this.txtComment.Size = new System.Drawing.Size(200, 20);
            y += spacing;

            // Sessions
            this.lblSessions.Text = "Посещений:";
            this.lblSessions.Location = new System.Drawing.Point(20, y);
            this.numSessions.Location = new System.Drawing.Point(inputX, y);
            y += spacing;

            // End date
            this.lblEnd.Text = "Окончание:";
            this.lblEnd.Location = new System.Drawing.Point(20, y);
            this.dtpEnd.Location = new System.Drawing.Point(inputX, y);
            y += spacing;

            // Unlimited
            this.lblUnlimited.Text = "Безлимит:";
            this.lblUnlimited.Location = new System.Drawing.Point(20, y);
            this.chkUnlimited.Location = new System.Drawing.Point(inputX, y);
            y += spacing;

            // Save button
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(inputX, y);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Add controls
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblLastName, txtLastName,
                lblFirstName, txtFirstName,
                lblMiddleName, txtMiddleName,
                lblTelegram, txtTelegram,
                lblComment, txtComment,
                lblSessions, numSessions,
                lblEnd, dtpEnd,
                lblUnlimited, chkUnlimited,
                btnSave
            });

            this.Size = new System.Drawing.Size(400, y + 50);
            ((System.ComponentModel.ISupportInitialize)(this.numSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}