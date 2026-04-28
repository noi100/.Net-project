using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ProductListForm : Form
    {
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();
        public ProductListForm()
        {
          
            InitializeComponent();

            // עכשיו ממלאים את הקטגוריות
            var categories = Enum.GetValues(typeof(BO.Category)).Cast<BO.Category>().ToList();
            cmbCategoryFilter.DataSource = categories;
            cmbCategoryFilter.SelectedIndex = -1; // ברירת מחדל: מציג הכל

            LoadData(); // קריאה לפונקציה שתטען את הנתונים
        }
        //טעינת נתונים
        //משתמשים בפונקציה GetList()  ב-ProductImplementation ומחברים אותה לטבלה.

        // עדכון הפונקציה לקבלת סינון אופציונלי
        private void LoadData(BO.Category? filter = null)
        {
            try
            {
                var products = _bl.Product.GetList();

                // אם נבחרה קטגוריה בסינון - נבצע Filter
                if (filter != null)
                {
                    products = products.Where(p => (BO.Category)p.category == filter);
                }

                dataGridView1.DataSource = products.Select(p => new
                {
                    ברקוד = p.barcode,
                    שם = p.name,
                    מחיר = p.price,
                    מלאי = p.amount,
                    קטגוריה = p.category
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הנתונים: " + ex.Message);
            }
        }

        // אירוע שמופעל בכל פעם שהמנהל בוחר קטגוריה בתיבה
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoryFilter.SelectedItem is BO.Category selected)
            {
                LoadData(selected); // טוען נתונים מסוננים
            }
        }

        private void AddingNewProductbutton_Click(object sender, EventArgs e)
        {
            // אנחנו פותחים את אותו חלון שבנינו, אבל שולחים לו ברקוד 0.
            // זה אומר לחלון: "אל תטען נתונים, תפתח דף ריק להוספה".
            ProductForm addForm = new ProductForm(0);

            // הצגת החלון כדו-שיח (עוצר את הרצת החלון הראשי עד שזה נסגר)
            addForm.ShowDialog();

            // אחרי שהמנהל סיים להוסיף וסגר את החלון - נרענן את הטבלה כדי לראות את המוצר החדש
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productDataGridView(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // בדיקה שלא לחצנו על שורת הכותרת
            if (e.RowIndex >= 0)
            {
                // חילוץ האובייקט שנבחר. שימי לב שאנחנו עושים Casting ל-BO.ProductDTO או BO.Product
                var selectedProduct = dataGridView1.Rows[e.RowIndex].DataBoundItem as BO.Product;

                if (selectedProduct != null)
                {
                    // פתיחת חלון המוצר (את צריכה ליצור חלון כזה שנקרא ProductForm)
                    // אנחנו שולחים לו את הברקוד של המוצר שנבחר
                    new ProductForm(selectedProduct.barcode).ShowDialog();

                    // ריענון הטבלה אחרי שהחלון נסגר
                    LoadData();
                }
            }
        }

   
    }
}
