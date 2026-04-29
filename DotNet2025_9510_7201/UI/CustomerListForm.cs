using BlApi;
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
    public partial class CustomerListForm : Form
    {
        //מה שמחבר ללוגיקה של BL
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();
        public CustomerListForm()
        {
            InitializeComponent();
            LoadData();
        }

        //טעינת נתונים ומילוי הטבלה
        private void LoadData()
        {
            try
            {
                var customers = _bl.Customer.GetList();

                // מילוי עמודות הטבלה עם נתוני הלקוחות
                DataGridViewCus.DataSource = customers.Select(c => new
                {
                    ID = c.id,                // עמודה ראשונה
                    Name = c.name,            // עמודה שנייה
                    Address = c.address,      // עמודה שלישית
                    Phone = c.phoneNumber     // עמודה רביעית
                }).ToList();

                // זה יגרום לעמודות להתפרס על כל רוחב הטבלה
                DataGridViewCus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void textBoxCus_TextChanged(object sender, EventArgs e)
        {

            try
            {
                // 1. קבלת כל הלקוחות מה-BL
                var allCustomers = _bl.Customer.GetList();

                // 2. בדיקה אם המשתמש הזין משהו בתיבת החיפוש
                string searchText = textBoxCus.Text;

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    // 3. סינון הרשימה: נציג רק לקוחות שה-ID שלהם מכיל את מה שהוקלד
                    allCustomers = allCustomers.Where(c => c.id.ToString().Contains(searchText));
                }

                // 4. עדכון הטבלה עם הרשימה המסוננת (או המלאה אם התיבה ריקה)
                DataGridViewCus.DataSource = allCustomers.Select(c => new
                {
                    ID = c.id,
                    Name = c.name,
                    Address = c.address,
                    Phone = c.phoneNumber
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בסינון הנתונים: " + ex.Message);
            }

        }

        //בעת לחיצה על שורה של לקוח פתיחת החלון עם הפרטים שלו
        private void DataGridViewCus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // בדיקה שלא לחצנו על שורת הכותרת (RowIndex -1)
            if (e.RowIndex >= 0)
            {
                // 1. שליפת ה-ID מהתא בעמודה שקראנו לה "ID" בשורה שנלחצה
                // חשוב: השם "ID" חייב להיות זהה לשם שנתת בתוך ה-Select ב-LoadData
                var idValue = DataGridViewCus.Rows[e.RowIndex].Cells["ID"].Value;

                if (idValue != null)
                {
                    int selectedId = (int)idValue;

                    // 2. יצירת מופע חדש של חלון פרטי הלקוח ושליחת ה-ID
                    CustomerForm customerDetails = new CustomerForm(selectedId);

                    // 3. הצגת החלון
                    customerDetails.ShowDialog();

                    // 4. ריענון הטבלה אחרי שהחלון נסגר (למקרה שהפרטים עודכנו)
                    LoadData();
                }
            }
        }

        private void AddClientbutton_Click(object sender, EventArgs e)
        {
            // פתיחת החלון עם ID = 0 (מסמן הוספה חדשה)
            CustomerForm addForm = new CustomerForm(0);

            // הצגת החלון כדו-שיח (עוצר את הרצת החלון הראשי עד שזה נסגר)
            addForm.ShowDialog();

            // אחרי שהמנהל סיים להוסיף וסגר את החלון - נרענן את הטבלה כדי לראות את הלקוח החדש
            LoadData();
        }
    }
}
