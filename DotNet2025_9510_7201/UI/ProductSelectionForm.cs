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
        public int SelectedProductId { get; set; }

        public ProductSelectionForm()
        {
            InitializeComponent();

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
            // בדיקה שנבחרה שורה ושהיא לא השורה הריקה החדשה
            if (dgvAllProducts.CurrentRow != null && !dgvAllProducts.CurrentRow.IsNewRow)
            {
                try
                {
                    // שליפת האובייקט המקורי שקשור לשורה (Product)
                    var selectedProduct = dgvAllProducts.CurrentRow.DataBoundItem as BO.Product;

                    if (selectedProduct != null)
                    {
                        SelectedProductId = selectedProduct.barcode;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // אם DataBoundItem לא עובד, נסי לשלוף לפי אינדקס העמודה (למשל עמודה מספר 1)
                        SelectedProductId = (int)dgvAllProducts.CurrentRow.Cells[1].Value;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("נא לוודא שבחרת מוצר תקין מהרשימה.");
                }
            }
        }
        //private void btnSelect_Click(object sender, EventArgs e)
        //{
        //    if (dgvAllProducts.CurrentRow != null)
        //    {
        //        try
        //        {
        //            // גישה גמישה: אם העמודה colProductID לא נמצאה, ננסה לשלוף ישירות מהאובייקט
        //            var selectedRow = dgvAllProducts.CurrentRow.DataBoundItem;
        //            if (selectedRow != null)
        //            {
        //                SelectedProductId = ((dynamic)selectedRow).ID;
        //            }
        //            else
        //            {
        //                SelectedProductId = (int)dgvAllProducts.CurrentRow.Cells["colProductID"].Value;
        //            }

        //            this.DialogResult = DialogResult.OK;
        //            this.Close();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("נא לוודא שבחרת מוצר תקין מהרשימה.");
        //        }
        //    }

        //}
        private void dgvAllProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}