namespace UI
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtProductId = new TextBox();
            btnAddProduct = new Button();
            btnOpenList = new Button();
            dgvCurrentOrder = new DataGridView();
            colProductID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPQuantity = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colTotalPrice = new DataGridViewTextBoxColumn();
            lblTotalPrice = new Label();
            btnDoOrder = new Button();
            label1 = new Label();
            numQuantity = new NumericUpDown();
            lblQuantityTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentOrder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(38, 91);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(125, 27);
            txtProductId.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(169, 91);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(94, 29);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "Add to cart";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnOpenList
            // 
            btnOpenList.Location = new Point(444, 147);
            btnOpenList.Name = "btnOpenList";
            btnOpenList.Size = new Size(241, 29);
            btnOpenList.TabIndex = 2;
            btnOpenList.Text = "select from list";
            btnOpenList.UseVisualStyleBackColor = true;
            btnOpenList.Click += btnOpenList_Click;
            // 
            // dgvCurrentOrder
            // 
            dgvCurrentOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentOrder.Columns.AddRange(new DataGridViewColumn[] { colProductID, colName, colPQuantity, colPrice, colTotalPrice });
            dgvCurrentOrder.Location = new Point(12, 207);
            dgvCurrentOrder.Name = "dgvCurrentOrder";
            dgvCurrentOrder.RowHeadersWidth = 51;
            dgvCurrentOrder.Size = new Size(673, 188);
            dgvCurrentOrder.TabIndex = 3;
            // 
            // colProductID
            // 
            colProductID.DataPropertyName = "ProductID";
            colProductID.HeaderText = "Product ID";
            colProductID.MinimumWidth = 6;
            colProductID.Name = "colProductID";
            colProductID.Width = 125;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Product Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.Width = 125;
            // 
            // colPQuantity
            // 
            colPQuantity.DataPropertyName = "Amount";
            colPQuantity.HeaderText = "Quantity";
            colPQuantity.MinimumWidth = 6;
            colPQuantity.Name = "colPQuantity";
            colPQuantity.Width = 125;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.Width = 125;
            // 
            // colTotalPrice
            // 
            colTotalPrice.DataPropertyName = "TotalPrice";
            colTotalPrice.HeaderText = "Total Price";
            colTotalPrice.MinimumWidth = 6;
            colTotalPrice.Name = "colTotalPrice";
            colTotalPrice.Width = 125;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(528, 413);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(118, 20);
            lblTotalPrice.TabIndex = 4;
            lblTotalPrice.Text = "Total to be paid:";
            // 
            // btnDoOrder
            // 
            btnDoOrder.Location = new Point(267, 409);
            btnDoOrder.Name = "btnDoOrder";
            btnDoOrder.Size = new Size(236, 29);
            btnDoOrder.TabIndex = 5;
            btnDoOrder.Text = "Place a final order";
            btnDoOrder.UseVisualStyleBackColor = true;
            btnDoOrder.Click += btnDoOrder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 52);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 6;
            label1.Text = "Enter product code";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(335, 91);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(150, 27);
            numQuantity.TabIndex = 7;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // lblQuantityTitle
            // 
            lblQuantityTitle.AutoSize = true;
            lblQuantityTitle.Location = new Point(403, 52);
            lblQuantityTitle.Name = "lblQuantityTitle";
            lblQuantityTitle.Size = new Size(65, 20);
            lblQuantityTitle.TabIndex = 8;
            lblQuantityTitle.Text = "Quantity";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblQuantityTitle);
            Controls.Add(numQuantity);
            Controls.Add(label1);
            Controls.Add(btnDoOrder);
            Controls.Add(lblTotalPrice);
            Controls.Add(dgvCurrentOrder);
            Controls.Add(btnOpenList);
            Controls.Add(btnAddProduct);
            Controls.Add(txtProductId);
            Name = "OrderForm";
            Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)dgvCurrentOrder).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProductId;
        private Button btnAddProduct;
        private Button btnOpenList;
        private DataGridView dgvCurrentOrder;
        private Label lblTotalPrice;
        private Button btnDoOrder;
        private Label label1;
        private NumericUpDown numQuantity;
        private Label lblQuantityTitle;
        private DataGridViewTextBoxColumn colProductID;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPQuantity;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colTotalPrice;
    }
}