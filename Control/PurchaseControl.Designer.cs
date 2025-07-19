namespace TitanApp.Controls
{
    partial class PurchaseControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

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
            dgvPurchases = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).BeginInit();
            SuspendLayout();
            // 
            // dgvPurchases
            // 
            dgvPurchases.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //dgvPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchases.Location = new Point(16, 59);
            dgvPurchases.Name = "dgvPurchases";
            dgvPurchases.RowHeadersVisible = false;
            dgvPurchases.RowHeadersWidth = 51;
            dgvPurchases.RowTemplate.Height = 28;
            dgvPurchases.Size = new Size(760, 370);
            dgvPurchases.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(16, 16);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 32);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(142, 16);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 32);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(268, 16);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 32);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // PurchaseControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvPurchases);
            Name = "PurchaseControl";
            Size = new Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).EndInit();
            ResumeLayout(false);
        }
    }
}
