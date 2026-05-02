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

            // טעינת הקטגוריות ל-ComboBox
            cmbCategoryFilter.DataSource = Enum.GetValues(typeof(BO.Category));
            cmbCategoryFilter.SelectedIndex = -1; // התחלה ללא סינון

            LoadData();
        }

        private void LoadData(BO.Category? filter = null)
        {
            try
            {
                // 1. קבלת כל המוצרים מה-BL
                var products = _bl.Product.GetList();

                // 2. סינון הרשימה במידה ונבחרה קטגוריה
                if (filter != null)
                {
                    products = products.Where(p => (BO.Category)p.category == filter);
                }

                // 3. עדכון הטבלה עם אובייקטים אנונימיים (כמו בלקוחות)
                dataGridView1.DataSource = products.Select(p => new
                {
                    Barcode = p.barcode,
                    Name = p.name,
                    Category = p.category,
                    Price = p.price,
                    Amount = p.amount
                }).ToList();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הנתונים: " + ex.Message);
            }
        }

        // אירוע שינוי בחירה ב-ComboBox[cite: 1]
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoryFilter.SelectedItem is BO.Category selected)
            {
                LoadData(selected);
            }
        }

        private void AddingNewProductbutton_Click(object sender, EventArgs e)
        {
            ProductForm addForm = new ProductForm(0);
            addForm.ShowDialog();
            LoadData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // כאן אנחנו שולפים לפי שם העמודה "Barcode" שהגדרנו ב-Select
                var barcodeValue = dataGridView1.Rows[e.RowIndex].Cells["Barcode"].Value;

                if (barcodeValue != null)
                {
                    int selectedBarcode = (int)barcodeValue;
                    new ProductForm(selectedBarcode).ShowDialog();
                    LoadData();
                }
            }
        }
    }
}