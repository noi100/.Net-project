using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;


namespace UI
{
    public partial class OrderForm : Form
    {
        // יצירת אובייקט הזמנה חדש (לפי השם שבחרת)
        BO.Order currentOrder = new BO.Order { Items = new List<BO.ProductInOrder>(), endPrice = 0 };

        //public int SelectedProductId { get; set; }

        public OrderForm()
        {
            InitializeComponent();
            //dgvProducts.DataSource = Factory.Get().Product.().ToList();
        }

        private void btnOpenList_Click(object sender, EventArgs e)
        {
            // יצירת מופע של הדף השני
            ProductSelectionForm listForm = new ProductSelectionForm();

            // הצגת הדף כחלון דיאלוג (חוסם את הדף הראשי עד שנסגר)
            if (listForm.ShowDialog() == DialogResult.OK)
            {
                // עדכון תיבת הטקסט ב-ID שנבחר מהחלון השני
                txtProductId.Text = listForm.SelectedProductId.ToString();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductId.Text, out int pId))
                {
                    // שליפת הכמות מהפקד החדש שהוספנו
                    int amount = (int)numQuantity.Value;

                    // עדכון הפונקציה כך שתשלח את ה-pId והכמות (amount)
                    var updatedItems = Factory.Get().Order.AddProductToOrder(currentOrder, pId, amount);

                    // עדכון הנתונים בטבלה
                    dgvCurrentOrder.DataSource = null;
                    dgvCurrentOrder.DataSource = updatedItems;

                    // חישוב ועדכון המחיר
                    Factory.Get().Order.CalcTotalPrice(currentOrder);
                    lblTotalPrice.Text = $"Total to be paid: ${currentOrder.endPrice}";

                    txtProductId.Clear();
                    numQuantity.Value = 1; // איפוס הכמות ל-1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder.Items == null || !currentOrder.Items.Any())
            {
                MessageBox.Show("The cart is empty.");
                return;
            }
            try
            {
                // ביצוע ההזמנה הסופי בבסיס הנתונים
                Factory.Get().Order.DoOrder(currentOrder);

                MessageBox.Show("The order has been placed successfully!");
                this.Close(); // סגירת המסך בסיום
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to place order: " + ex.Message);
            }
        }
        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
