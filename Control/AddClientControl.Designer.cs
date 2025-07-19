using System;
using System.Drawing;
using System.Windows.Forms;

namespace TitanApp.Controls
{
    partial class AddClientControl
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtId;
        private Label lblId;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private TextBox txtMiddleName;
        private Label lblMiddleName;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtTelegram;
        private Label lblTelegram;
        private TextBox txtComment;
        private Label lblComment;
        private CheckBox chkUnlimited;
        private NumericUpDown numSessions;
        private Label lblSessions;
        private DateTimePicker dtpEnd;
        private Label lblEnd;
        private Button btnSave;
        private Label lblVisits;
        private ListBox lstVisits;
        private Button btnAddVisit;
        private Button btnRemoveVisit;
        private DateTimePicker dtpVisit;

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
            txtPhone = new TextBox();
            lblPhone = new Label();
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
            lblVisits = new Label();
            lstVisits = new ListBox();
            btnAddVisit = new Button();
            btnRemoveVisit = new Button();
            dtpVisit = new DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)numSessions).BeginInit();
            SuspendLayout();

            // txtId
            txtId.Location = new Point(137, 13);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 1;
            txtId.TabStop = false;

            // lblId
            lblId.Location = new Point(20, 18);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 26);
            lblId.TabIndex = 2;
            lblId.Text = "ID:";

            // txtLastName
            txtLastName.Location = new Point(137, 46);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 27);
            txtLastName.TabIndex = 0;

            // lblLastName
            lblLastName.Location = new Point(20, 50);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(100, 23);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Фамилия:";

            // txtFirstName
            txtFirstName.Location = new Point(137, 77);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 27);
            txtFirstName.TabIndex = 2;

            // lblFirstName
            lblFirstName.Location = new Point(20, 80);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(100, 23);
            lblFirstName.TabIndex = 4;
            lblFirstName.Text = "Имя:";

            // txtMiddleName
            txtMiddleName.Location = new Point(137, 107);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(200, 27);
            txtMiddleName.TabIndex = 3;

            // lblMiddleName
            lblMiddleName.Location = new Point(20, 110);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(100, 23);
            lblMiddleName.TabIndex = 5;
            lblMiddleName.Text = "Отчество:";

            // txtPhone
            txtPhone.Location = new Point(137, 137);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 27);
            txtPhone.TabIndex = 4;

            // lblPhone
            lblPhone.Location = new Point(20, 140);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Телефон:";

            // txtTelegram
            txtTelegram.Location = new Point(137, 168);
            txtTelegram.Name = "txtTelegram";
            txtTelegram.Size = new Size(200, 27);
            txtTelegram.TabIndex = 5;

            // lblTelegram
            lblTelegram.Location = new Point(20, 170);
            lblTelegram.Name = "lblTelegram";
            lblTelegram.Size = new Size(100, 23);
            lblTelegram.TabIndex = 7;
            lblTelegram.Text = "Telegram:";

            // txtComment
            txtComment.Location = new Point(137, 198);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(200, 27);
            txtComment.TabIndex = 6;

            // lblComment
            lblComment.Location = new Point(20, 200);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(111, 23);
            lblComment.TabIndex = 8;
            lblComment.Text = "Комментарий:";

            // chkUnlimited
            chkUnlimited.Location = new Point(267, 232);
            chkUnlimited.Name = "chkUnlimited";
            chkUnlimited.Size = new Size(150, 24);
            chkUnlimited.TabIndex = 7;
            chkUnlimited.Text = "Безлимитный доступ";

            // numSessions
            numSessions.Location = new Point(187, 230);
            numSessions.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSessions.Name = "numSessions";
            numSessions.Size = new Size(60, 27);
            numSessions.TabIndex = 8;

            // lblSessions
            lblSessions.Location = new Point(20, 232);
            lblSessions.Name = "lblSessions";
            lblSessions.Size = new Size(161, 23);
            lblSessions.TabIndex = 9;
            lblSessions.Text = "Куплено посещений:";

            // dtpEnd
            dtpEnd.Location = new Point(205, 264);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(200, 27);
            dtpEnd.TabIndex = 9;

            // lblEnd
            lblEnd.Location = new Point(20, 264);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(179, 23);
            lblEnd.TabIndex = 10;
            lblEnd.Text = "Окончание абонемента:";

            // btnSave
            btnSave.Location = new Point(158, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            // lblVisits
            lblVisits.Location = new Point(423, 21);
            lblVisits.Name = "lblVisits";
            lblVisits.Size = new Size(180, 23);
            lblVisits.TabIndex = 11;
            lblVisits.Text = "Посещения:";

            // lstVisits
            lstVisits.Location = new Point(423, 46);
            lstVisits.Name = "lstVisits";
            lstVisits.Size = new Size(180, 160);
            lstVisits.TabIndex = 12;

            // dtpVisit
            dtpVisit.Location = new Point(423, 210);
            dtpVisit.Name = "dtpVisit";
            dtpVisit.Size = new Size(180, 27);
            dtpVisit.TabIndex = 13;

            // btnAddVisit
            btnAddVisit.Location = new Point(423, 243);
            btnAddVisit.Name = "btnAddVisit";
            btnAddVisit.Size = new Size(85, 30);
            btnAddVisit.TabIndex = 14;
            btnAddVisit.Text = "Добавить";
            btnAddVisit.Click += btnAddVisit_Click;

            // btnRemoveVisit
            btnRemoveVisit.Location = new Point(518, 243);
            btnRemoveVisit.Name = "btnRemoveVisit";
            btnRemoveVisit.Size = new Size(85, 30);
            btnRemoveVisit.TabIndex = 15;
            btnRemoveVisit.Text = "Удалить";
            btnRemoveVisit.Click += btnRemoveVisit_Click;

            // AddClientControl
            Controls.AddRange(new Control[]
            {
                txtId, lblId, txtLastName, lblLastName, txtFirstName, lblFirstName,
                txtMiddleName, lblMiddleName, txtPhone, lblPhone, txtTelegram, lblTelegram,
                txtComment, lblComment, chkUnlimited, numSessions, lblSessions, dtpEnd, lblEnd,
                btnSave, lblVisits, lstVisits, dtpVisit, btnAddVisit, btnRemoveVisit
            });

            Name = "AddClientControl";
            Size = new Size(674, 360);

            ((System.ComponentModel.ISupportInitialize)numSessions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
