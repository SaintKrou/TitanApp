namespace TitanApp.Controls
{
    partial class ApplySubscriptionControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            this.lblClient = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentSessions = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numAddSessions = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNewEndDate = new System.Windows.Forms.DateTimePicker();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAddSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(20, 20);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(54, 15);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Клиент:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClientName.Location = new System.Drawing.Point(90, 20);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(98, 15);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "[ФИО клиента]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Текущие занятия:";
            // 
            // txtCurrentSessions
            // 
            this.txtCurrentSessions.Location = new System.Drawing.Point(150, 57);
            this.txtCurrentSessions.Name = "txtCurrentSessions";
            this.txtCurrentSessions.ReadOnly = true;
            this.txtCurrentSessions.Size = new System.Drawing.Size(60, 23);
            this.txtCurrentSessions.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Добавить занятия:";
            // 
            // numAddSessions
            // 
            this.numAddSessions.Location = new System.Drawing.Point(150, 93);
            this.numAddSessions.Maximum = new decimal(new int[] {
            1000, 0, 0, 0});
            this.numAddSessions.Name = "numAddSessions";
            this.numAddSessions.Size = new System.Drawing.Size(60, 23);
            this.numAddSessions.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Окончание абон-та:";
            // 
            // dtpNewEndDate
            // 
            this.dtpNewEndDate.Location = new System.Drawing.Point(150, 127);
            this.dtpNewEndDate.Name = "dtpNewEndDate";
            this.dtpNewEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpNewEndDate.TabIndex = 7;
            // 
            // chkUnlimited
            // 
            this.chkUnlimited.AutoSize = true;
            this.chkUnlimited.Location = new System.Drawing.Point(150, 160);
            this.chkUnlimited.Name = "chkUnlimited";
            this.chkUnlimited.Size = new System.Drawing.Size(85, 19);
            this.chkUnlimited.TabIndex = 8;
            this.chkUnlimited.Text = "Безлимит";
            this.chkUnlimited.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(150, 200);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(90, 30);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ApplySubscriptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.chkUnlimited);
            this.Controls.Add(this.dtpNewEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numAddSessions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrentSessions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.lblClient);
            this.Name = "ApplySubscriptionControl";
            this.Size = new System.Drawing.Size(380, 250);
            ((System.ComponentModel.ISupportInitialize)(this.numAddSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentSessions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAddSessions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNewEndDate;
        private System.Windows.Forms.CheckBox chkUnlimited;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}
