using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class ProductListForm : Form
    {
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();

        public ProductListForm()
        {
            InitializeComponent();

            // טעינת הקטגוריות לטבלה
            cmbCategoryFilter.DataSource = Enum.GetValues(typeof(BO.Category));
            cmbCategoryFilter.SelectedIndex = -1; // התחלה ללא סינון

            LoadData();
        }

        private void LoadData(BO.Category? filter = null)
        {
            try
            {
                //  קבלת כל המוצרים מה-BL
                var products = _bl.Product.GetList();

                //  סינון הרשימה במידה ונבחרה קטגוריה
                if (filter != null)
                {
                    products = products.Where(p => (BO.Category)p.category == filter);
                }

                //יצירת אובייקט מזמן ריצה אנונימי והצגת העמודות הרצויות בטבלה
                dataGridView1.DataSource = products.Select(p => new
                {
                    Barcode = p.barcode,
                    Name = p.name,
                    Category = p.category,
                    Price = p.price,
                    Amount = p.amount
                }).ToList();

                //עיצוב הטבלה כדי שתתאים לגודל התוכן
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הנתונים: " + ex.Message);
            }
        }

        // אירוע הסינון של הטבלה לפי קטגוריות
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoryFilter.SelectedItem is BO.Category selected)
            {
                LoadData(selected);
            }
        }

        //אירוע של הוספת פרויקט פתיחת העמוד למילוי נתונים
        private void AddingNewProductbutton_Click(object sender, EventArgs e)
        {
            ProductForm addForm = new ProductForm(0);
            addForm.ShowDialog();
            LoadData();
        }

        //אירוע של חיצה כפולה על שורה בטבלה הצגת פרטי המוצר עם אפשרותלשינוי או מחיקה
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //ניגש לשורה הנפרדת נשלוף טת הברקוד של המוצר שנמצא בשורה ונכניס למשתנה
               
                var barcodeValue = dataGridView1.Rows[e.RowIndex].Cells["Barcode"].Value;

                //כדי למנוע קריסה במידה והשורה ריקה
                //נכנס חקוד רק אם השורה מלאה
                if (barcodeValue != null)
                {
                    int selectedBarcode = (int)barcodeValue;
                    //פתיחת החלון של מוצר עם פרטי המוצר הנבחר
                    new ProductForm(selectedBarcode).ShowDialog();
                    LoadData();//עדכון הטבלה לאחר השינוי
                }
            }
        }
    }
}