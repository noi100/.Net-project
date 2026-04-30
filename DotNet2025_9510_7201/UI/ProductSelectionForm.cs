using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BlApi;

namespace UI
{
    public partial class ProductSelectionForm : Form
    {
        // מאפיין לשמירת ה-ID שנבחר כדי שהטופס המזמין יוכל לגשת אליו
        public int SelectedProductId { get; set; }

        public ProductSelectionForm()
        {
            InitializeComponent();

            // טעינת רשימת המוצרים מה-BL והצגתם בטבלה
            try
            {
                dgvAllProducts.DataSource = Factory.Get().Product.GetList().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // בדיקה שנבחרה שורה בטבלה
            if (dgvAllProducts.CurrentRow != null)
            {
                // שליפת ה-ID מתוך תא בשורה הנבחרת
                // הערה: וודא שב-Designer הגדרת את ה-DataPropertyName של העמודה ל-"ID" או "ProductID"
                SelectedProductId = (int)dgvAllProducts.CurrentRow.Cells["colProductID"].Value;

                // החזרת תשובה חיובית וסגירת החלון
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a product from the list first.");
            }
        }
    }
}