using BlApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class SaleListFrom : Form
    {
        // חיבור לשכבת הלוגיקה 
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();

        public SaleListFrom()
        {
            InitializeComponent();
            LoadData(); // טעינת הנתונים בטעינת החלון 
        }

        // פונקציית טעינת נתונים המותאמת לשדות ה-BO שלך 
        private void LoadData()
        {
            try
            {
                var sales = _bl.Sale.GetList();

                // יצירת אובייקטים אנונימיים עם שמות העמודות שיוצגו בטבלה 
                dataGridViewSales.DataSource = sales.Select(s => new
                {
                    ID = s.id,                             // קוד מבצע
                    ProductID = s.idProduct,               // קוד מוצר
                    Price = s.priceSale,                   // מחיר מבצע
                    MinAmount = s.amountToGetSale,         // כמות מינימלית
                    ClubOnly = s.IsClubMemberOnly ? "Yes" : "No", // מועדון בלבד
                    StartDate = s.start.ToShortDateString(), // תאריך התחלה
                    EndDate = s.end.ToShortDateString()      // תאריך סיום
                }).ToList();

                dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת המבצעים: " + ex.Message);
            }
        }

        // לחיצה כפולה על שורת מבצע לעדכון פרטים 
        private void dataGridViewSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var idValue = dataGridViewSales.Rows[e.RowIndex].Cells["ID"].Value;

                if (idValue != null)
                {
                    int selectedSaleId = (int)idValue;

                    // פתיחת חלון הפרטים עם ה-ID שנבחר (מצב עדכון) 
                    SaleForm f = new SaleForm(selectedSaleId);
                    f.ShowDialog();
                    LoadData(); // ריענון הטבלה לאחר סגירת החלון
                }
            }
        }

        // כפתור להוספת מבצע חדש 
        private void btnAddSale_Click(object sender, EventArgs e)
        {
            // פתיחת חלון הפרטים עם 0 (מצב הוספה - שדות ריקים) 
            SaleForm f = new SaleForm(0);
            f.ShowDialog();
            LoadData(); // ריענון הטבלה לאחר הוספה
        }

        //סינון לפי הID שהוכנס בתיבת הטקסט
        private void textBoxSale_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var allSales = _bl.Sale.GetList();
                string searchText = textBoxSale.Text;

                // סינון הרשימה לפי ה-ID שהוקלד
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    allSales = allSales.Where(s => s.id.ToString().Contains(searchText));
                }

                // עדכון המקור של הטבלה
                dataGridViewSales.DataSource = allSales.Select(s => new
                {
                    ID = s.id,
                    ProductID = s.idProduct,
                    Price = s.priceSale,
                    MinAmount = s.amountToGetSale,
                    ClubOnly = s.IsClubMemberOnly ? "Yes" : "No",
                    StartDate = s.start.ToShortDateString(),
                    EndDate = s.end.ToShortDateString()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בסינון: " + ex.Message);
            }
        }
    }
}