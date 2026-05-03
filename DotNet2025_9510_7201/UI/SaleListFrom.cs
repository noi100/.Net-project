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

        // טעינת הנתונים  מה BO ומילוי הטבלה 
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

        // עדכון פרטי המבצע בלחיצה כפולה על שורה בטבלה
        private void dataGridViewSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //בדיקה שהלחיצה הייתה על שורה מלאה בטבלה 
            if (e.RowIndex >= 0)
            {
                //שליפת ה ID של המבצע 
                var idValue = dataGridViewSales.Rows[e.RowIndex].Cells["ID"].Value;

                //בדיקה שאכן קיים
                if (idValue != null)
                {
                    int selectedSaleId = (int)idValue;

                    // יצרית מופע של הטופס עם פרטי המבצע במצב של עדכון
                    SaleForm f = new SaleForm(selectedSaleId);
                    //פתיחת החלון
                    f.ShowDialog();
                    LoadData(); // ריענון הטבלה 
                }
            }
        }

        // כפתור להוספת מבצע חדש 
        private void btnAddSale_Click(object sender, EventArgs e)
        {
            // יצרית מופע של הטופס עם פרטי המבצע במצב של מחיקה
            SaleForm f = new SaleForm(0);
            f.ShowDialog();
            LoadData(); // ריענון הטבלה לאחר הוספה
        }


        //סינון נתוני הטבלה על פי ערך מהמשתמש
        private void textBoxSale_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var allSales = _bl.Sale.GetList();
                string searchText = textBoxSale.Text;

                //סינון לפי הערך בשורת הסינון
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