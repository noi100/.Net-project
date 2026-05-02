namespace UI
{
    partial class ProductForm
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
            BarcodeLabel1 = new Label();
            NameProductLabel1 = new Label();
            PriceProductLabel1 = new Label();
            InventoryLabel2 = new Label();
            CategoryLabel3 = new Label();
            txtBarcode = new TextBox();
            txtName = new TextBox();
            txtAmount = new TextBox();
            txtPrice = new TextBox();
            cmbCategory = new ComboBox();
            SaveButton = new Button();
            DeleteProductButton1 = new Button();
            SuspendLayout();
            // 
            // BarcodeLabel1
            // 
            BarcodeLabel1.AutoSize = true;
            BarcodeLabel1.Location = new Point(32, 26);
            BarcodeLabel1.Name = "BarcodeLabel1";
            BarcodeLabel1.Size = new Size(67, 20);
            BarcodeLabel1.TabIndex = 0;
            BarcodeLabel1.Text = "Barcode:";
            // 
            // NameProductLabel1
            // 
            NameProductLabel1.AutoSize = true;
            NameProductLabel1.Location = new Point(32, 70);
            NameProductLabel1.Name = "NameProductLabel1";
            NameProductLabel1.Size = new Size(52, 20);
            NameProductLabel1.TabIndex = 1;
            NameProductLabel1.Text = "Name:";
            // 
            // PriceProductLabel1
            // 
            PriceProductLabel1.AutoSize = true;
            PriceProductLabel1.Location = new Point(32, 119);
            PriceProductLabel1.Name = "PriceProductLabel1";
            PriceProductLabel1.Size = new Size(44, 20);
            PriceProductLabel1.TabIndex = 2;
            PriceProductLabel1.Text = "Price:";
            // 
            // InventoryLabel2
            // 
            InventoryLabel2.AutoSize = true;
            InventoryLabel2.Location = new Point(31, 169);
            InventoryLabel2.Name = "InventoryLabel2";
            InventoryLabel2.Size = new Size(65, 20);
            InventoryLabel2.TabIndex = 3;
            InventoryLabel2.Text = "Amount:";
            // 
            // CategoryLabel3
            // 
            CategoryLabel3.AutoSize = true;
            CategoryLabel3.Location = new Point(27, 225);
            CategoryLabel3.Name = "CategoryLabel3";
            CategoryLabel3.Size = new Size(72, 20);
            CategoryLabel3.TabIndex = 4;
            CategoryLabel3.Text = "Category:";
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(124, 23);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(125, 27);
            txtBarcode.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(124, 67);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 6;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(124, 166);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(125, 27);
            txtAmount.TabIndex = 8;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(124, 116);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 9;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(124, 222);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 12;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(124, 296);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(135, 66);
            SaveButton.TabIndex = 13;
            SaveButton.Text = "Save product";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DeleteProductButton1
            // 
            DeleteProductButton1.Location = new Point(346, 296);
            DeleteProductButton1.Name = "DeleteProductButton1";
            DeleteProductButton1.Size = new Size(152, 66);
            DeleteProductButton1.TabIndex = 14;
            DeleteProductButton1.Text = "Delete this product";
            DeleteProductButton1.UseVisualStyleBackColor = true;
            DeleteProductButton1.Click += DeleteProductButton1_Click_1;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DeleteProductButton1);
            Controls.Add(SaveButton);
            Controls.Add(cmbCategory);
            Controls.Add(txtPrice);
            Controls.Add(txtAmount);
            Controls.Add(txtName);
            Controls.Add(txtBarcode);
            Controls.Add(CategoryLabel3);
            Controls.Add(InventoryLabel2);
            Controls.Add(PriceProductLabel1);
            Controls.Add(NameProductLabel1);
            Controls.Add(BarcodeLabel1);
            Name = "ProductForm";
            Text = "ProductForm";
            Load += ProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BarcodeLabel1;
        private Label NameProductLabel1;
        private Label PriceProductLabel1;
        private Label InventoryLabel2;
        private Label CategoryLabel3;
        private TextBox txtBarcode;
        private TextBox txtName;
        private TextBox txtAmount;
        private TextBox txtPrice;
        private ComboBox cmbCategory;
        private Button SaveButton;
        private Button DeleteProductButton1;
    }
}