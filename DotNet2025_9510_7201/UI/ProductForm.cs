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
        //  יצירת מופע כדי שנוכל לגשת לBL
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();

        private int _productBarcode;

        //נשלח פרמרט כדי לבדוק האם לעדכן או להוסיף מוצר חדש
        public ProductForm(int barcode = 0)
        {
            InitializeComponent();
            _productBarcode = barcode;

            //טעינת רשימת הקטגוריות לתיבת הבחירה
            cmbCategory.DataSource = Enum.GetValues(typeof(BO.Category));

            if (_productBarcode != 0) // מצב עדכון
            {
                LoadProductDetails();//טוען את נתוני המוצר
                SaveButton.Visible = true;
                SaveButton.Text = "עדכן מוצר";
                DeleteProductButton1.Visible = true; // בעדכון אפשר למחוק
            }
            else // מצב הוספה
            {
                SaveButton.Visible = true; //כפתור שמירה גלוי
                SaveButton.Text = "הוסף מוצר";
                DeleteProductButton1.Visible = false; // בהוספה  אא למחוק
                txtBarcode.ReadOnly = false;//ניתן להגידר ברקוד
            }
        }

        //טעינת פרטי המוצר מהכבה BL
        private void LoadProductDetails()
        {
            try
            {
                //טעינה למשתנה
                var product = _bl.Product.GetProduct(_productBarcode);

                //המרה למחרוזות
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
                //יצירת אובייקט חדש ומילוי הפקדים עי קלט מהמשתמש
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
            // תיבת אישור לפני חיקה
            var result = MessageBox.Show(
                "האם את בטוחה שברצונך למחוק את המוצר לצמיתות?",
                "אישור מחיקה",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            //אם התקבל אישור ביצוע המחיקה
            if (result == DialogResult.Yes)
            {
                try
                {
                    // מחיקת המוצר לפי הברקוד שלו קריאה ל BL
                    _bl.Product.Delete(_productBarcode);

                    //הודעה כשהצליח
                    MessageBox.Show("המוצר נמחק בהצלחה!", "מחיקה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //סגירת החלון אוטומטית
                    this.Close();
                }
                catch (Exception ex)
                {
                    // אם המחיקה נכשלה
                    MessageBox.Show("לא ניתן למחוק את המוצר: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}