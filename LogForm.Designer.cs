namespace TitanApp
{
    partial class LogForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLog;

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

            // txtLog
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Multiline = true;
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 10F);

            // LogForm
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.txtLog);
            this.Name = "LogForm";
            this.Text = "Логи активности";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}