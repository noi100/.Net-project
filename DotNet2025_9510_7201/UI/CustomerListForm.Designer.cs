namespace UI
{
    partial class CustomerListForm
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
            DataGridViewCus = new DataGridView();
            textBoxCus = new TextBox();
            AddClientbutton = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridViewCus).BeginInit();
            SuspendLayout();
            // 
            // DataGridViewCus
            // 
            DataGridViewCus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewCus.Location = new Point(40, 173);
            DataGridViewCus.Name = "DataGridViewCus";
            DataGridViewCus.RowHeadersWidth = 51;
            DataGridViewCus.Size = new Size(282, 186);
            DataGridViewCus.TabIndex = 0;
            DataGridViewCus.CellDoubleClick += DataGridViewCus_CellDoubleClick;
            // 
            // textBoxCus
            // 
            textBoxCus.Location = new Point(40, 112);
            textBoxCus.Name = "textBoxCus";
            textBoxCus.Size = new Size(310, 27);
            textBoxCus.TabIndex = 1;
            textBoxCus.Text = "Enter customer's id";
            textBoxCus.TextChanged += textBoxCus_TextChanged;
            // 
            // AddClientbutton
            // 
            AddClientbutton.Location = new Point(539, 68);
            AddClientbutton.Name = "AddClientbutton";
            AddClientbutton.Size = new Size(158, 71);
            AddClientbutton.TabIndex = 2;
            AddClientbutton.Text = "Add Customer";
            AddClientbutton.UseVisualStyleBackColor = true;
            AddClientbutton.Click += AddClientbutton_Click;
            // 
            // CustomerListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddClientbutton);
            Controls.Add(textBoxCus);
            Controls.Add(DataGridViewCus);
            Name = "CustomerListForm";
            Text = "ClientListForm";
            ((System.ComponentModel.ISupportInitialize)DataGridViewCus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataGridViewCus;
        private TextBox textBoxCus;
        private Button AddClientbutton;
    }
}