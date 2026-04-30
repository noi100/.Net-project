namespace UI
{
    partial class SaleListFrom
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
            dataGridViewSales = new DataGridView();
            btnAddSale = new Button();
            textBoxSale = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSales
            // 
            dataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSales.Location = new Point(48, 181);
            dataGridViewSales.Name = "dataGridViewSales";
            dataGridViewSales.RowHeadersWidth = 51;
            dataGridViewSales.Size = new Size(268, 108);
            dataGridViewSales.TabIndex = 0;
            dataGridViewSales.CellDoubleClick += dataGridViewSales_CellDoubleClick;
            // 
            // btnAddSale
            // 
            btnAddSale.Location = new Point(540, 181);
            btnAddSale.Name = "btnAddSale";
            btnAddSale.Size = new Size(112, 54);
            btnAddSale.TabIndex = 1;
            btnAddSale.Text = "Add Sale";
            btnAddSale.UseVisualStyleBackColor = true;
            btnAddSale.Click += btnAddSale_Click;
            // 
            // textBoxSale
            // 
            textBoxSale.Location = new Point(48, 118);
            textBoxSale.Name = "textBoxSale";
            textBoxSale.Size = new Size(277, 27);
            textBoxSale.TabIndex = 2;
            textBoxSale.Text = "Enter sale's id";
            textBoxSale.TextChanged += textBoxSale_TextChanged;
            // 
            // SaleListFrom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxSale);
            Controls.Add(btnAddSale);
            Controls.Add(dataGridViewSales);
            Name = "SaleListFrom";
            Text = "SaleFrom";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewSales;
        private Button btnAddSale;
        private TextBox textBoxSale;
    }
}