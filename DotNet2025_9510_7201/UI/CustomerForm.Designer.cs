namespace UI
{
    partial class CustomerForm
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
            IDCusLable = new Label();
            NameCusLable = new Label();
            AddressCusLable = new Label();
            PhoneCusLable = new Label();
            txtIdCus = new TextBox();
            txtNameCus = new TextBox();
            txtAddressCus = new TextBox();
            txtPhoneCus = new TextBox();
            btnDeleteCus = new Button();
            btnSaveCus = new Button();
            SuspendLayout();
            // 
            // IDCusLable
            // 
            IDCusLable.AutoSize = true;
            IDCusLable.Location = new Point(41, 54);
            IDCusLable.Name = "IDCusLable";
            IDCusLable.Size = new Size(24, 20);
            IDCusLable.TabIndex = 0;
            IDCusLable.Text = "ID";
            // 
            // NameCusLable
            // 
            NameCusLable.AutoSize = true;
            NameCusLable.Location = new Point(41, 109);
            NameCusLable.Name = "NameCusLable";
            NameCusLable.Size = new Size(52, 20);
            NameCusLable.TabIndex = 1;
            NameCusLable.Text = "Name:";
            // 
            // AddressCusLable
            // 
            AddressCusLable.AutoSize = true;
            AddressCusLable.Location = new Point(41, 168);
            AddressCusLable.Name = "AddressCusLable";
            AddressCusLable.Size = new Size(65, 20);
            AddressCusLable.TabIndex = 2;
            AddressCusLable.Text = "Address:";
            // 
            // PhoneCusLable
            // 
            PhoneCusLable.AutoSize = true;
            PhoneCusLable.Location = new Point(41, 222);
            PhoneCusLable.Name = "PhoneCusLable";
            PhoneCusLable.Size = new Size(105, 20);
            PhoneCusLable.TabIndex = 3;
            PhoneCusLable.Text = "Phone number";
            // 
            // txtIdCus
            // 
            txtIdCus.Location = new Point(110, 47);
            txtIdCus.Name = "txtIdCus";
            txtIdCus.Size = new Size(133, 27);
            txtIdCus.TabIndex = 4;
            // 
            // txtNameCus
            // 
            txtNameCus.Location = new Point(110, 102);
            txtNameCus.Name = "txtNameCus";
            txtNameCus.Size = new Size(148, 27);
            txtNameCus.TabIndex = 5;
            // 
            // txtAddressCus
            // 
            txtAddressCus.Location = new Point(117, 161);
            txtAddressCus.Name = "txtAddressCus";
            txtAddressCus.Size = new Size(141, 27);
            txtAddressCus.TabIndex = 6;
            // 
            // txtPhoneCus
            // 
            txtPhoneCus.Location = new Point(161, 215);
            txtPhoneCus.Name = "txtPhoneCus";
            txtPhoneCus.Size = new Size(133, 27);
            txtPhoneCus.TabIndex = 7;
            // 
            // btnDeleteCus
            // 
            btnDeleteCus.Location = new Point(623, 352);
            btnDeleteCus.Name = "btnDeleteCus";
            btnDeleteCus.Size = new Size(139, 73);
            btnDeleteCus.TabIndex = 8;
            btnDeleteCus.Text = "Delete this customer";
            btnDeleteCus.UseVisualStyleBackColor = true;
            btnDeleteCus.Click += btnDeleteCus_Click;
            // 
            // btnSaveCus
            // 
            btnSaveCus.Location = new Point(333, 102);
            btnSaveCus.Name = "btnSaveCus";
            btnSaveCus.Size = new Size(158, 76);
            btnSaveCus.TabIndex = 9;
            btnSaveCus.Text = "Save";
            btnSaveCus.UseVisualStyleBackColor = true;
            btnSaveCus.Click += btnSaveCus_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSaveCus);
            Controls.Add(btnDeleteCus);
            Controls.Add(txtPhoneCus);
            Controls.Add(txtAddressCus);
            Controls.Add(txtNameCus);
            Controls.Add(txtIdCus);
            Controls.Add(PhoneCusLable);
            Controls.Add(AddressCusLable);
            Controls.Add(NameCusLable);
            Controls.Add(IDCusLable);
            Name = "CustomerForm";
            Text = "CustomerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IDCusLable;
        private Label NameCusLable;
        private Label AddressCusLable;
        private Label PhoneCusLable;
        private TextBox txtIdCus;
        private TextBox txtNameCus;
        private TextBox txtAddressCus;
        private TextBox txtPhoneCus;
        private Button btnDeleteCus;
        private Button btnSaveCus;
    }
}