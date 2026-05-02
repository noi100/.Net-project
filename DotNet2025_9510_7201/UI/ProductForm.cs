using BlApi;
using BO; // <-- הוספנו את זה
using Do;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UI
{
    public partial class ProductForm : Form
    {
        // 1. יצירת המופע של ה-BL (זה המנוע של המערכת)
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();

        private int _productBarcode;

        public ProductForm(int barcode = 0)
        {
            InitializeComponent();
            _productBarcode = barcode;

            cmbCategory.DataSource = Enum.GetValues(typeof(BO.Category));

            if (_productBarcode != 0) // מצב עדכון
            {
                LoadProductDetails();
                SaveButton.Visible = true;
                SaveButton.Text = "עדכן מוצר";
                DeleteProductButton1.Visible = true; // בעדכון מותר למחוק
            }
            else // מצב הוספה
            {
                SaveButton.Visible = true; // חייב להיות True כדי שנוכל לשמור!
                SaveButton.Text = "הוסף מוצר";
                DeleteProductButton1.Visible = false; // בהוספה באמת אין מה למחוק
                txtBarcode.ReadOnly = false;
            }
        }

        private void LoadProductDetails()
        {
            try
            {
                // עכשיו המחשב יזהה את _bl
                var product = _bl.Product.GetProduct(_productBarcode);

                txtBarcode.Text = product.barcode.ToString();
                txtName.Text = product.name;
                txtPrice.Text = product.price.ToString();
                txtAmount.Text = product.amount.ToString();
                cmbCategory.SelectedItem = product.category;
            }
            catch (Exception ex)
            {
                MessageBox.Show("לא הצלחתי לטעון את פרטי המוצר: " + ex.Message);
            }
        }

        //עדכון מוצר עי מנהל
        private void UpdateProductButton_Click(object sender, EventArgs e)
        {

        }



        //שמירת שינויים או הוספת מוצר עי מנהל

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                BO.Product productToSave = new BO.Product
                {
                    barcode = int.Parse(txtBarcode.Text),
                    name = txtName.Text,
                    price = double.Parse(txtPrice.Text),
                    amount = int.Parse(txtAmount.Text),
                    category = cmbCategory.SelectedItem != null
                    ? (Do.category)cmbCategory.SelectedItem
                     : default(Do.category)

                };

                // הבדיקה שמבדילה בין הוספה לעדכון
                if (_productBarcode == 0) // אם הברקוד המקורי איתו פתחנו את החלון הוא 0
                {
                    _bl.Product.Add(productToSave); // קריאה להוספה
                    MessageBox.Show("המוצר נוסף בהצלחה!", "הוספה");
                }
                else
                {
                    _bl.Product.Update(productToSave); // קריאה לעדכון
                    MessageBox.Show("המוצר עודכן בהצלחה!", "עדכון");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה: " + ex.Message);
            }
        }
        //מחיקת מוצר עי מנהל

        private void DeleteProductButton1_Click_1(object sender, EventArgs e)
        {
            // 1. קפיצת תיבת אישור - כדי למנוע טעויות
            var result = MessageBox.Show(
                "האם את בטוחה שברצונך למחוק את המוצר לצמיתות?",
                "אישור מחיקה",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // 2. אם המנהל לחץ על 'Yes'
            if (result == DialogResult.Yes)
            {
                try
                {
                    // 3. קריאה ל-BL למחיקת המוצר לפי הברקוד שלו
                    _bl.Product.Delete(_productBarcode);

                    // 4. הודעת הצלחה
                    MessageBox.Show("המוצר נמחק בהצלחה!", "מחיקה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. סגירת החלון וחזרה לטבלה (שתתרענן אוטומטית)
                    this.Close();
                }
                catch (Exception ex)
                {
                    // אם המחיקה נכשלה (למשל אם המוצר נמצא בהזמנה קיימת)
                    MessageBox.Show("לא ניתן למחוק את המוצר: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}