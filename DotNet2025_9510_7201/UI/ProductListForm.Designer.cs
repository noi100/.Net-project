namespace UI
{
    partial class ProductListForm
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
            AddingNewProductbutton = new Button();
            dataGridView1 = new DataGridView();
            FilterCategoryLable = new Label();
            cmbCategoryFilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // AddingNewProductbutton
            // 
            AddingNewProductbutton.Location = new Point(524, 387);
            AddingNewProductbutton.Name = "AddingNewProductbutton";
            AddingNewProductbutton.Size = new Size(200, 51);
            AddingNewProductbutton.TabIndex = 0;
            AddingNewProductbutton.Text = "Adding a new product";
            AddingNewProductbutton.UseVisualStyleBackColor = true;
            AddingNewProductbutton.Click += AddingNewProductbutton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 109);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(704, 260);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // FilterCategoryLable
            // 
            FilterCategoryLable.AutoSize = true;
            FilterCategoryLable.Location = new Point(34, 64);
            FilterCategoryLable.Name = "FilterCategoryLable";
            FilterCategoryLable.Size = new Size(129, 20);
            FilterCategoryLable.TabIndex = 5;
            FilterCategoryLable.Text = "Filter by Category:";
            FilterCategoryLable.Click += FilterCategoryLable_Click;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(206, 64);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(151, 28);
            cmbCategoryFilter.TabIndex = 6;
            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
            // 
            // ProductListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbCategoryFilter);
            Controls.Add(FilterCategoryLable);
            Controls.Add(dataGridView1);
            Controls.Add(AddingNewProductbutton);
            Name = "ProductListForm";
            Text = "ProductListForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddingNewProductbutton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStock;
        private Label FilterCategoryLable;
        private ComboBox cmbCategoryFilter;
    }
}