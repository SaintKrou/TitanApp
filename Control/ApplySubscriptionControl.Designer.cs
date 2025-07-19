partial class ApplySubscriptionControl
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblClientInfo;
    private System.Windows.Forms.Label lblSubscription;
    private System.Windows.Forms.ComboBox comboBoxSubscriptions;
    private System.Windows.Forms.Label lblPayment;
    private System.Windows.Forms.ComboBox comboBoxPayment;
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.Label lblPriceVal;
    private System.Windows.Forms.Label lblDuration;
    private System.Windows.Forms.Label lblDurationVal;
    private System.Windows.Forms.Label lblSessions;
    private System.Windows.Forms.Label lblSessionsVal;
    private System.Windows.Forms.Label lblEndDate;
    private System.Windows.Forms.Label lblEndDateVal;
    private System.Windows.Forms.Button btnApply;
    private System.Windows.Forms.Button btnApplyAndMark;

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
        this.lblClientInfo = new System.Windows.Forms.Label();
        this.lblSubscription = new System.Windows.Forms.Label();
        this.comboBoxSubscriptions = new System.Windows.Forms.ComboBox();
        this.lblPayment = new System.Windows.Forms.Label();
        this.comboBoxPayment = new System.Windows.Forms.ComboBox();
        this.lblPrice = new System.Windows.Forms.Label();
        this.lblPriceVal = new System.Windows.Forms.Label();
        this.lblDuration = new System.Windows.Forms.Label();
        this.lblDurationVal = new System.Windows.Forms.Label();
        this.lblSessions = new System.Windows.Forms.Label();
        this.lblSessionsVal = new System.Windows.Forms.Label();
        this.lblEndDate = new System.Windows.Forms.Label();
        this.lblEndDateVal = new System.Windows.Forms.Label();
        this.btnApply = new System.Windows.Forms.Button();
        this.btnApplyAndMark = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // lblClientInfo
        // 
        this.lblClientInfo.AutoSize = true;
        this.lblClientInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblClientInfo.Location = new System.Drawing.Point(20, 15);
        this.lblClientInfo.Name = "lblClientInfo";
        this.lblClientInfo.Size = new System.Drawing.Size(160, 19);
        this.lblClientInfo.TabIndex = 0;
        this.lblClientInfo.Text = "ID: 0, Фамилия: ----";
        // 
        // lblSubscription
        // 
        this.lblSubscription.AutoSize = true;
        this.lblSubscription.Location = new System.Drawing.Point(20, 50);
        this.lblSubscription.Name = "lblSubscription";
        this.lblSubscription.Size = new System.Drawing.Size(70, 15);
        this.lblSubscription.TabIndex = 1;
        this.lblSubscription.Text = "Абонемент:";
        // 
        // comboBoxSubscriptions
        // 
        this.comboBoxSubscriptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxSubscriptions.FormattingEnabled = true;
        this.comboBoxSubscriptions.Location = new System.Drawing.Point(140, 46);
        this.comboBoxSubscriptions.Name = "comboBoxSubscriptions";
        this.comboBoxSubscriptions.Size = new System.Drawing.Size(250, 23);
        this.comboBoxSubscriptions.TabIndex = 2;
        // 
        // lblPayment
        // 
        this.lblPayment.AutoSize = true;
        this.lblPayment.Location = new System.Drawing.Point(20, 85);
        this.lblPayment.Name = "lblPayment";
        this.lblPayment.Size = new System.Drawing.Size(92, 15);
        this.lblPayment.TabIndex = 3;
        this.lblPayment.Text = "Способ оплаты:";
        // 
        // comboBoxPayment
        // 
        this.comboBoxPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxPayment.FormattingEnabled = true;
        this.comboBoxPayment.Location = new System.Drawing.Point(140, 81);
        this.comboBoxPayment.Name = "comboBoxPayment";
        this.comboBoxPayment.Size = new System.Drawing.Size(250, 23);
        this.comboBoxPayment.TabIndex = 4;
        // 
        // lblPrice
        // 
        this.lblPrice.AutoSize = true;
        this.lblPrice.Location = new System.Drawing.Point(20, 120);
        this.lblPrice.Name = "lblPrice";
        this.lblPrice.Size = new System.Drawing.Size(38, 15);
        this.lblPrice.TabIndex = 5;
        this.lblPrice.Text = "Цена:";
        // 
        // lblPriceVal
        // 
        this.lblPriceVal.AutoSize = true;
        this.lblPriceVal.Location = new System.Drawing.Point(140, 120);
        this.lblPriceVal.Name = "lblPriceVal";
        this.lblPriceVal.Size = new System.Drawing.Size(32, 15);
        this.lblPriceVal.TabIndex = 6;
        this.lblPriceVal.Text = "0.00";
        // 
        // lblDuration
        // 
        this.lblDuration.AutoSize = true;
        this.lblDuration.Location = new System.Drawing.Point(20, 145);
        this.lblDuration.Name = "lblDuration";
        this.lblDuration.Size = new System.Drawing.Size(93, 15);
        this.lblDuration.TabIndex = 7;
        this.lblDuration.Text = "Длительность:";
        // 
        // lblDurationVal
        // 
        this.lblDurationVal.AutoSize = true;
        this.lblDurationVal.Location = new System.Drawing.Point(140, 145);
        this.lblDurationVal.Name = "lblDurationVal";
        this.lblDurationVal.Size = new System.Drawing.Size(11, 15);
        this.lblDurationVal.TabIndex = 8;
        this.lblDurationVal.Text = "-";
        // 
        // lblSessions
        // 
        this.lblSessions.AutoSize = true;
        this.lblSessions.Location = new System.Drawing.Point(20, 170);
        this.lblSessions.Name = "lblSessions";
        this.lblSessions.Size = new System.Drawing.Size(112, 15);
        this.lblSessions.TabIndex = 9;
        this.lblSessions.Text = "Кол-во посещений:";
        // 
        // lblSessionsVal
        // 
        this.lblSessionsVal.AutoSize = true;
        this.lblSessionsVal.Location = new System.Drawing.Point(140, 170);
        this.lblSessionsVal.Name = "lblSessionsVal";
        this.lblSessionsVal.Size = new System.Drawing.Size(11, 15);
        this.lblSessionsVal.TabIndex = 10;
        this.lblSessionsVal.Text = "-";
        // 
        // lblEndDate
        // 
        this.lblEndDate.AutoSize = true;
        this.lblEndDate.Location = new System.Drawing.Point(20, 195);
        this.lblEndDate.Name = "lblEndDate";
        this.lblEndDate.Size = new System.Drawing.Size(114, 15);
        this.lblEndDate.TabIndex = 11;
        this.lblEndDate.Text = "Окончание действия:";
        // 
        // lblEndDateVal
        // 
        this.lblEndDateVal.AutoSize = true;
        this.lblEndDateVal.Location = new System.Drawing.Point(140, 195);
        this.lblEndDateVal.Name = "lblEndDateVal";
        this.lblEndDateVal.Size = new System.Drawing.Size(11, 15);
        this.lblEndDateVal.TabIndex = 12;
        this.lblEndDateVal.Text = "-";
        // 
        // btnApply
        // 
        this.btnApply.Location = new System.Drawing.Point(20, 230);
        this.btnApply.Name = "btnApply";
        this.btnApply.Size = new System.Drawing.Size(150, 30);
        this.btnApply.TabIndex = 13;
        this.btnApply.Text = "Применить";
        this.btnApply.UseVisualStyleBackColor = true;
        this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
        // 
        // btnApplyAndMark
        // 
        this.btnApplyAndMark.Location = new System.Drawing.Point(190, 230);
        this.btnApplyAndMark.Name = "btnApplyAndMark";
        this.btnApplyAndMark.Size = new System.Drawing.Size(200, 30);
        this.btnApplyAndMark.TabIndex = 14;
        this.btnApplyAndMark.Text = "Применить и отметить";
        this.btnApplyAndMark.UseVisualStyleBackColor = true;
        this.btnApplyAndMark.Click += new System.EventHandler(this.btnApplyAndMark_Click);
        // 
        // ApplySubscriptionControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.lblClientInfo);
        this.Controls.Add(this.lblSubscription);
        this.Controls.Add(this.comboBoxSubscriptions);
        this.Controls.Add(this.lblPayment);
        this.Controls.Add(this.comboBoxPayment);
        this.Controls.Add(this.lblPrice);
        this.Controls.Add(this.lblPriceVal);
        this.Controls.Add(this.lblDuration);
        this.Controls.Add(this.lblDurationVal);
        this.Controls.Add(this.lblSessions);
        this.Controls.Add(this.lblSessionsVal);
        this.Controls.Add(this.lblEndDate);
        this.Controls.Add(this.lblEndDateVal);
        this.Controls.Add(this.btnApply);
        this.Controls.Add(this.btnApplyAndMark);
        this.Name = "ApplySubscriptionControl";
        this.Size = new System.Drawing.Size(420, 280);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
