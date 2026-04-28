namespace UI
{
    partial class ManagerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProductManagementButton = new Button();
            ClientManagementButton = new Button();
            SaleManagementButton = new Button();
            SuspendLayout();
            // 
            // ProductManagementButton
            // 
            ProductManagementButton.Location = new Point(555, 72);
            ProductManagementButton.Name = "ProductManagementButton";
            ProductManagementButton.Size = new Size(208, 29);
            ProductManagementButton.TabIndex = 0;
            ProductManagementButton.Text = "Product Management";
            ProductManagementButton.UseVisualStyleBackColor = true;
            ProductManagementButton.Click += ProductManagementButton_Click;
            // 
            // ClientManagementButton
            // 
            ClientManagementButton.Location = new Point(555, 124);
            ClientManagementButton.Name = "ClientManagementButton";
            ClientManagementButton.Size = new Size(208, 29);
            ClientManagementButton.TabIndex = 1;
            ClientManagementButton.Text = "Client Management";
            ClientManagementButton.UseVisualStyleBackColor = true;
            ClientManagementButton.Click += ClientManagementButton_Click_1;
            // 
            // SaleManagementButton
            // 
            SaleManagementButton.Location = new Point(555, 173);
            SaleManagementButton.Name = "SaleManagementButton";
            SaleManagementButton.Size = new Size(208, 30);
            SaleManagementButton.TabIndex = 2;
            SaleManagementButton.Text = "Sale Management";
            SaleManagementButton.UseVisualStyleBackColor = true;
            SaleManagementButton.Click += SaleManagementButton_Click;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SaleManagementButton);
            Controls.Add(ClientManagementButton);
            Controls.Add(ProductManagementButton);
            Name = "ManagerForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button ProductManagementButton;
        private Button ClientManagementButton;
        private Button SaleManagementButton;
    }
}
