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
        // אתחול אובייקט הזמנה חדש עם רשימת פריטים ריקה
        BO.Order currentOrder = new BO.Order { Items = new List<BO.ProductInOrder>(), endPrice = 0 };

        public OrderForm()
        {
            InitializeComponent();
        }

        private void btnOpenList_Click(object sender, EventArgs e)
        {
            // יצירת מופע של חלון בחירת המוצרים
            ProductSelectionForm listForm = new ProductSelectionForm();

            //if (listForm.ShowDialog() == DialogResult.OK)
            //{
            //    // עדכון תיבת הטקסט ב-ID שנבחר מהחלון השני
            //    txtProductId.Text = listForm.SelectedProductId.ToString();
            //}
            if (listForm.ShowDialog() == DialogResult.OK)
            {
                txtProductId.Text = listForm.SelectedProductId.ToString();

                // השורה שהוספנו להפעלה אוטומטית:
                HandleAddingProduct(listForm.SelectedProductId);
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductId.Text, out int pId))
                {
                    // כל הלוגיקה שהייתה כאן עברה לתוך הפונקציה הזו
                    HandleAddingProduct(pId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //private void btnAddProduct_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (int.TryParse(txtProductId.Text, out int pId))
        //        {

        //            int amount = (int)numQuantity.Value;

        //            // תיקון שגיאה CS0029:
        //            // במקום לנסות להציב את התוצאה לתוך currentOrder (שהוא BO.Order),
        //            // אנחנו מעדכנים רק את רשימת הפריטים בתוך האובייקט הקיים.
        //            var updatedItems = Factory.Get().Order.AddProductToOrder(currentOrder, pId, amount);

        //            // כאן את כותבת את הפתרון (שורה 49 המעודכנת):
        //            currentOrder.Items = updatedItems.Select(item => new BO.ProductInOrder
        //            {
        //                id = item.idSale,
        //                price = item.priceSale,
        //                amount = item.amountSale 
        //            }).ToList();

        //            // תיקון Warning CS8604:
        //            // בדיקה ש-updatedItems אינו null לפני הצבה לטבלה
        //            if (currentOrder.Items != null)
        //            {
        //                dgvCurrentOrder.DataSource = null;
        //                dgvCurrentOrder.DataSource = currentOrder.Items.ToList();
        //            }

        //            // עדכון המחיר
        //            lblTotalPrice.Text = $"Total to be paid: ${currentOrder.endPrice}";

        //            txtProductId.Clear();
        //            numQuantity.Value = 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}
        //private void btnAddProduct_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // בדיקה האם הוזן קוד מוצר תקין בתיבת הטקסט
        //        if (int.TryParse(txtProductId.Text, out int pId))
        //        {
        //            // שליפת הכמות מפקד ה-NumericUpDown
        //            int amount = (int)numQuantity.Value;

        //            // קריאה לשכבת ה-Logic להוספת המוצר להזמנה וקבלת האובייקט המעודכן
        //            currentOrder = Factory.Get().Order.AddProductToOrder(currentOrder, pId, amount);

        //            // עדכון התצוגה בטבלה (DataGridView)
        //            // ניקוי המקור הישן וחיבור הרשימה המעודכנת כ-List כדי להבטיח רענון ויזואלי
        //            dgvCurrentOrder.DataSource = null;
        //            dgvCurrentOrder.DataSource = currentOrder.Items.ToList();

        //            // עדכון המחיר הסופי לאחר ההוספה
        //            lblTotalPrice.Text = $"Total to be paid: ${currentOrder.endPrice}";

        //            // איפוס שדות הקלט עבור המוצר הבא
        //            txtProductId.Clear();
        //            numQuantity.Value = 1;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please enter a valid Product ID.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            // בדיקה אם העגלה ריקה לפני ביצוע הזמנה סופית
            if (currentOrder.Items == null || !currentOrder.Items.Any())
            {
                MessageBox.Show("The cart is empty.");
                return;
            }

            try
            {
                // שליחת ההזמנה המוכנה לביצוע סופי ב-Logic
                Factory.Get().Order.DoOrder(currentOrder);

                MessageBox.Show("The order has been placed successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to place order: " + ex.Message);
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            // ניתן להוסיף כאן לוגיקה לעדכון מחיר בזמן אמת אם נדרש
        }
        //private void HandleAddingProduct(int pId)
        //{
        //    try
        //    {
        //        int amount = (int)numQuantity.Value;

        //        // שליחה ללוגיקה
        //        var updatedItems = Factory.Get().Order.AddProductToOrder(currentOrder, pId, amount);

        //        currentOrder.Items = updatedItems.Select(item =>
        //        {
        //            // נסי להשתמש ב-Get או בפונקציה דומה שמצאת בשלב 1
        //            var product = Factory.Get().Product.GetProduct(item.idSale);

        //            return new BO.ProductInOrder
        //            {
        //                id = item.idSale,
        //                price = item.priceSale, // תיקון ל-priceSale בלי s
        //                amount = item.amountSale,
        //                name = product.name,
        //            };
        //        }).ToList();

        //        // רענון התצוגה בטבלה
        //        dgvCurrentOrder.DataSource = null;
        //        dgvCurrentOrder.DataSource = currentOrder.Items;

        //        // עדכון המחיר
        //        lblTotalPrice.Text = $"Total: ${currentOrder.endPrice}";
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}
        private void HandleAddingProduct(int pId)
        {
            try
            {
                // קבלת הכמות מהפקד בטופס
                int amount = (int)numQuantity.Value;

                // שליחה ל-BL - הוא מעדכן את הרשימה בתוך currentOrder ואת המחיר endPrice
                Factory.Get().Order.AddProductToOrder(currentOrder, pId, amount);

                // עדכון הטבלה - שימוש ב-ToList מבטיח שה-DataGridView יזהה שינויים
                dgvCurrentOrder.DataSource = null;
                if (currentOrder.Items != null)
                {
                    dgvCurrentOrder.DataSource = currentOrder.Items.ToList();
                }

                // עדכון המחיר הסופי שמוצג למשתמש
                lblTotalPrice.Text = $"Total: ${currentOrder.endPrice:F2}";

                // איפוס שדות הקלט לנוחות המשתמש
                txtProductId.Clear();
                numQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}