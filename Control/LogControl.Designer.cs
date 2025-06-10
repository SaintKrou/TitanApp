namespace TitanApp.Controls
{
    partial class LogControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.ReadOnly = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(600, 400);
            this.txtLog.TabIndex = 0;

            // 
            // LogControl
            // 
            this.Controls.Add(this.txtLog);
            this.Name = "LogControl";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
