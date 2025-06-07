namespace TitanApp
{
    partial class AddClientForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtTelegram;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.NumericUpDown numSessions;
        private System.Windows.Forms.CheckBox chkUnlimited;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstClientLogs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtTelegram = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.numSessions = new System.Windows.Forms.NumericUpDown();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstClientLogs = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSessions)).BeginInit();
            this.SuspendLayout();

            // txtId
            this.txtId.Location = new System.Drawing.Point(12, 12);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 23);
            this.txtId.TabIndex = 0;
            this.txtId.PlaceholderText = "ID клиента";

            // txtLastName (Фамилия теперь раньше)
            this.txtLastName.Location = new System.Drawing.Point(12, 43);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderText = "Фамилия";
            this.txtLastName.Size = new System.Drawing.Size(200, 23);
            this.txtLastName.TabIndex = 1;

            // txtFirstName (Имя теперь ниже фамилии)
            this.txtFirstName.Location = new System.Drawing.Point(12, 72);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderText = "Имя";
            this.txtFirstName.Size = new System.Drawing.Size(200, 23);
            this.txtFirstName.TabIndex = 2;

            // txtMiddleName
            this.txtMiddleName.Location = new System.Drawing.Point(12, 101);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.PlaceholderText = "Отчество";
            this.txtMiddleName.Size = new System.Drawing.Size(200, 23);
            this.txtMiddleName.TabIndex = 3;

            // txtTelegram
            this.txtTelegram.Location = new System.Drawing.Point(12, 130);
            this.txtTelegram.Name = "txtTelegram";
            this.txtTelegram.PlaceholderText = "Telegram";
            this.txtTelegram.Size = new System.Drawing.Size(200, 23);
            this.txtTelegram.TabIndex = 4;

            // txtComment
            this.txtComment.Location = new System.Drawing.Point(12, 159);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.PlaceholderText = "Комментарий";
            this.txtComment.Size = new System.Drawing.Size(200, 60);
            this.txtComment.TabIndex = 5;

            // numSessions
            this.numSessions.Location = new System.Drawing.Point(12, 225);
            this.numSessions.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numSessions.Name = "numSessions";
            this.numSessions.Size = new System.Drawing.Size(120, 23);
            this.numSessions.TabIndex = 6;

            // chkUnlimited
            this.chkUnlimited.Location = new System.Drawing.Point(12, 254);
            this.chkUnlimited.Name = "chkUnlimited";
            this.chkUnlimited.Size = new System.Drawing.Size(120, 24);
            this.chkUnlimited.Text = "Безлимитный";
            this.chkUnlimited.TabIndex = 7;
            this.chkUnlimited.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(12, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.TabIndex = 8;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // lstClientLogs
            this.lstClientLogs.FormattingEnabled = true;
            this.lstClientLogs.HorizontalScrollbar = true;
            this.lstClientLogs.Location = new System.Drawing.Point(230, 12);
            this.lstClientLogs.Name = "lstClientLogs";
            this.lstClientLogs.Size = new System.Drawing.Size(400, 302);
            this.lstClientLogs.TabIndex = 9;

            // AddClientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 326);
            this.Controls.Add(this.lstClientLogs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkUnlimited);
            this.Controls.Add(this.numSessions);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtTelegram);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Клиент";
            ((System.ComponentModel.ISupportInitialize)(this.numSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
