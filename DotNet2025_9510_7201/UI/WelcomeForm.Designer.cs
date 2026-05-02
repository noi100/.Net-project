namespace UI
{
    partial class WelcomeForm
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
            ManagerFormButton = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // ManagerFormButton
            // 
            ManagerFormButton.Location = new Point(508, 77);
            ManagerFormButton.Name = "ManagerFormButton";
            ManagerFormButton.Size = new Size(163, 52);
            ManagerFormButton.TabIndex = 0;
            ManagerFormButton.Text = "Manager ";
            ManagerFormButton.UseVisualStyleBackColor = true;
            ManagerFormButton.Click += ManagerFormButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(201, 77);
            button2.Name = "button2";
            button2.Size = new Size(251, 52);
            button2.TabIndex = 1;
            button2.Text = "Placing an order / customer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(ManagerFormButton);
            Name = "WelcomeForm";
            Text = "WelcomeForm";
            ResumeLayout(false);
        }

        #endregion

        private Button ManagerFormButton;
        private Button button2;
    }
}