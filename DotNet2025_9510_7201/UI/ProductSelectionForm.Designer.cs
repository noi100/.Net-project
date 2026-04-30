namespace UI
{
    partial class ProductSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            dgvAllProducts = new DataGridView();
            btnSelect = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAllProducts).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(204, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 0;
            // 
            // dgvAllProducts
            // 
            dgvAllProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllProducts.Location = new Point(73, 100);
            dgvAllProducts.Name = "dgvAllProducts";
            dgvAllProducts.RowHeadersWidth = 51;
            dgvAllProducts.Size = new Size(300, 188);
            dgvAllProducts.TabIndex = 1;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(73, 387);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(182, 40);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "Select a product";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 18);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 3;
            label1.Text = "Search by name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 64);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 4;
            label2.Text = "To view all products";
            // 
            // ProductSelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSelect);
            Controls.Add(dgvAllProducts);
            Controls.Add(txtSearch);
            Name = "ProductSelectionForm";
            Text = "ProductSelectionForm";
            ((System.ComponentModel.ISupportInitialize)dgvAllProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private DataGridView dgvAllProducts;
        private Button btnSelect;
        private Label label1;
        private Label label2;
    }
}