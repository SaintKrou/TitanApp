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
        lblClientInfo = new Label();
        lblSubscription = new Label();
        comboBoxSubscriptions = new ComboBox();
        lblPayment = new Label();
        comboBoxPayment = new ComboBox();
        lblPrice = new Label();
        lblPriceVal = new Label();
        lblDuration = new Label();
        lblDurationVal = new Label();
        lblSessions = new Label();
        lblSessionsVal = new Label();
        lblEndDate = new Label();
        lblEndDateVal = new Label();
        btnApply = new Button();
        btnApplyAndMark = new Button();
        SuspendLayout();
        // 
        // lblClientInfo
        // 
        lblClientInfo.AutoSize = true;
        lblClientInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblClientInfo.Location = new Point(23, 20);
        lblClientInfo.Name = "lblClientInfo";
        lblClientInfo.Size = new Size(174, 23);
        lblClientInfo.TabIndex = 0;
        lblClientInfo.Text = "ID: 0, Фамилия: ----";
        // 
        // lblSubscription
        // 
        lblSubscription.AutoSize = true;
        lblSubscription.Location = new Point(23, 67);
        lblSubscription.Name = "lblSubscription";
        lblSubscription.Size = new Size(91, 20);
        lblSubscription.TabIndex = 1;
        lblSubscription.Text = "Абонемент:";
        // 
        // comboBoxSubscriptions
        // 
        comboBoxSubscriptions.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSubscriptions.FormattingEnabled = true;
        comboBoxSubscriptions.Location = new Point(148, 59);
        comboBoxSubscriptions.Margin = new Padding(3, 4, 3, 4);
        comboBoxSubscriptions.Name = "comboBoxSubscriptions";
        comboBoxSubscriptions.Size = new Size(285, 28);
        comboBoxSubscriptions.TabIndex = 2;
        // 
        // lblPayment
        // 
        lblPayment.AutoSize = true;
        lblPayment.Location = new Point(23, 113);
        lblPayment.Name = "lblPayment";
        lblPayment.Size = new Size(119, 20);
        lblPayment.TabIndex = 3;
        lblPayment.Text = "Способ оплаты:";
        // 
        // comboBoxPayment
        // 
        comboBoxPayment.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxPayment.FormattingEnabled = true;
        comboBoxPayment.Location = new Point(148, 110);
        comboBoxPayment.Margin = new Padding(3, 4, 3, 4);
        comboBoxPayment.Name = "comboBoxPayment";
        comboBoxPayment.Size = new Size(285, 28);
        comboBoxPayment.TabIndex = 4;
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(23, 160);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(48, 20);
        lblPrice.TabIndex = 5;
        lblPrice.Text = "Цена:";
        // 
        // lblPriceVal
        // 
        lblPriceVal.AutoSize = true;
        lblPriceVal.Location = new Point(174, 160);
        lblPriceVal.Name = "lblPriceVal";
        lblPriceVal.Size = new Size(36, 20);
        lblPriceVal.TabIndex = 6;
        lblPriceVal.Text = "0.00";
        // 
        // lblDuration
        // 
        lblDuration.AutoSize = true;
        lblDuration.Location = new Point(23, 193);
        lblDuration.Name = "lblDuration";
        lblDuration.Size = new Size(108, 20);
        lblDuration.TabIndex = 7;
        lblDuration.Text = "Длительность:";
        // 
        // lblDurationVal
        // 
        lblDurationVal.AutoSize = true;
        lblDurationVal.Location = new Point(182, 193);
        lblDurationVal.Name = "lblDurationVal";
        lblDurationVal.Size = new Size(15, 20);
        lblDurationVal.TabIndex = 8;
        lblDurationVal.Text = "-";
        // 
        // lblSessions
        // 
        lblSessions.AutoSize = true;
        lblSessions.Location = new Point(23, 227);
        lblSessions.Name = "lblSessions";
        lblSessions.Size = new Size(145, 20);
        lblSessions.TabIndex = 9;
        lblSessions.Text = "Кол-во посещений:";
        // 
        // lblSessionsVal
        // 
        lblSessionsVal.AutoSize = true;
        lblSessionsVal.Location = new Point(182, 227);
        lblSessionsVal.Name = "lblSessionsVal";
        lblSessionsVal.Size = new Size(15, 20);
        lblSessionsVal.TabIndex = 10;
        lblSessionsVal.Text = "-";
        // 
        // lblEndDate
        // 
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(23, 260);
        lblEndDate.Name = "lblEndDate";
        lblEndDate.Size = new Size(157, 20);
        lblEndDate.TabIndex = 11;
        lblEndDate.Text = "Окончание действия:";
        // 
        // lblEndDateVal
        // 
        lblEndDateVal.AutoSize = true;
        lblEndDateVal.Location = new Point(182, 260);
        lblEndDateVal.Name = "lblEndDateVal";
        lblEndDateVal.Size = new Size(15, 20);
        lblEndDateVal.TabIndex = 12;
        lblEndDateVal.Text = "-";
        // 
        // btnApply
        // 
        btnApply.Location = new Point(23, 307);
        btnApply.Margin = new Padding(3, 4, 3, 4);
        btnApply.Name = "btnApply";
        btnApply.Size = new Size(171, 40);
        btnApply.TabIndex = 13;
        btnApply.Text = "Применить";
        btnApply.UseVisualStyleBackColor = true;
        btnApply.Click += btnApply_Click;
        // 
        // btnApplyAndMark
        // 
        btnApplyAndMark.Location = new Point(217, 307);
        btnApplyAndMark.Margin = new Padding(3, 4, 3, 4);
        btnApplyAndMark.Name = "btnApplyAndMark";
        btnApplyAndMark.Size = new Size(229, 40);
        btnApplyAndMark.TabIndex = 14;
        btnApplyAndMark.Text = "Применить и отметить";
        btnApplyAndMark.UseVisualStyleBackColor = true;
        btnApplyAndMark.Click += btnApplyAndMark_Click;
        // 
        // ApplySubscriptionControl
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(lblClientInfo);
        Controls.Add(lblSubscription);
        Controls.Add(comboBoxSubscriptions);
        Controls.Add(lblPayment);
        Controls.Add(comboBoxPayment);
        Controls.Add(lblPrice);
        Controls.Add(lblPriceVal);
        Controls.Add(lblDuration);
        Controls.Add(lblDurationVal);
        Controls.Add(lblSessions);
        Controls.Add(lblSessionsVal);
        Controls.Add(lblEndDate);
        Controls.Add(lblEndDateVal);
        Controls.Add(btnApply);
        Controls.Add(btnApplyAndMark);
        Margin = new Padding(3, 4, 3, 4);
        Name = "ApplySubscriptionControl";
        Size = new Size(480, 373);
        ResumeLayout(false);
        PerformLayout();
    }
}
