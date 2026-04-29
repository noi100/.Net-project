namespace UI
{
    partial class SaleForm
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
            btnSave = new Button();
            btnDelete = new Button();
            idLableS = new Label();
            priceLableS = new Label();
            amountLableS = new Label();
            clubLableS = new Label();
            startLableS = new Label();
            endLableS = new Label();
            txtAmountS = new TextBox();
            txtPriceS = new TextBox();
            txtIDs = new TextBox();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            checkBoxClub = new CheckBox();
            ProductIDLableS = new Label();
            txtProductS = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(400, 122);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 56);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(636, 363);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(138, 62);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete this sale";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // idLableS
            // 
            idLableS.AutoSize = true;
            idLableS.Location = new Point(41, 30);
            idLableS.Name = "idLableS";
            idLableS.Size = new Size(27, 20);
            idLableS.TabIndex = 2;
            idLableS.Text = "ID:";
            // 
            // priceLableS
            // 
            priceLableS.AutoSize = true;
            priceLableS.Location = new Point(41, 91);
            priceLableS.Name = "priceLableS";
            priceLableS.Size = new Size(44, 20);
            priceLableS.TabIndex = 3;
            priceLableS.Text = "Price:";
            // 
            // amountLableS
            // 
            amountLableS.AutoSize = true;
            amountLableS.Location = new Point(41, 158);
            amountLableS.Name = "amountLableS";
            amountLableS.Size = new Size(118, 20);
            amountLableS.TabIndex = 4;
            amountLableS.Text = "Amount for sale:";
            // 
            // clubLableS
            // 
            clubLableS.AutoSize = true;
            clubLableS.Location = new Point(41, 220);
            clubLableS.Name = "clubLableS";
            clubLableS.Size = new Size(42, 20);
            clubLableS.TabIndex = 5;
            clubLableS.Text = "Club:";
            // 
            // startLableS
            // 
            startLableS.AutoSize = true;
            startLableS.Location = new Point(41, 280);
            startLableS.Name = "startLableS";
            startLableS.Size = new Size(43, 20);
            startLableS.TabIndex = 6;
            startLableS.Text = "Start:";
            // 
            // endLableS
            // 
            endLableS.AutoSize = true;
            endLableS.Location = new Point(41, 339);
            endLableS.Name = "endLableS";
            endLableS.Size = new Size(37, 20);
            endLableS.TabIndex = 7;
            endLableS.Text = "End:";
            // 
            // txtAmountS
            // 
            txtAmountS.Location = new Point(175, 151);
            txtAmountS.Name = "txtAmountS";
            txtAmountS.Size = new Size(102, 27);
            txtAmountS.TabIndex = 8;
            // 
            // txtPriceS
            // 
            txtPriceS.Location = new Point(106, 84);
            txtPriceS.Name = "txtPriceS";
            txtPriceS.Size = new Size(107, 27);
            txtPriceS.TabIndex = 9;
            // 
            // txtIDs
            // 
            txtIDs.Location = new Point(106, 23);
            txtIDs.Name = "txtIDs";
            txtIDs.Size = new Size(107, 27);
            txtIDs.TabIndex = 13;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(119, 273);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(241, 27);
            dateTimePickerStart.TabIndex = 14;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(119, 332);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(241, 27);
            dateTimePickerEnd.TabIndex = 15;
            // 
            // checkBoxClub
            // 
            checkBoxClub.AutoSize = true;
            checkBoxClub.Location = new Point(106, 223);
            checkBoxClub.Name = "checkBoxClub";
            checkBoxClub.Size = new Size(18, 17);
            checkBoxClub.TabIndex = 16;
            checkBoxClub.UseVisualStyleBackColor = true;
            // 
            // ProductIDLableS
            // 
            ProductIDLableS.AutoSize = true;
            ProductIDLableS.Location = new Point(222, 52);
            ProductIDLableS.Name = "ProductIDLableS";
            ProductIDLableS.Size = new Size(77, 20);
            ProductIDLableS.TabIndex = 17;
            ProductIDLableS.Text = "Product id";
            // 
            // txtProductS
            // 
            txtProductS.Location = new Point(467, 41);
            txtProductS.Name = "txtProductS";
            txtProductS.Size = new Size(132, 27);
            txtProductS.TabIndex = 18;
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtProductS);
            Controls.Add(ProductIDLableS);
            Controls.Add(checkBoxClub);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(txtIDs);
            Controls.Add(txtPriceS);
            Controls.Add(txtAmountS);
            Controls.Add(endLableS);
            Controls.Add(startLableS);
            Controls.Add(clubLableS);
            Controls.Add(amountLableS);
            Controls.Add(priceLableS);
            Controls.Add(idLableS);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Name = "SaleForm";
            Text = "SaleFrom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnDelete;
        private Label idLableS;
        private Label priceLableS;
        private Label amountLableS;
        private Label clubLableS;
        private Label startLableS;
        private Label endLableS;
        private TextBox txtAmountS;
        private TextBox txtPriceS;
        private TextBox txtIDs;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private CheckBox checkBoxClub;
        private Label ProductIDLableS;
        private TextBox txtProductS;
    }
}