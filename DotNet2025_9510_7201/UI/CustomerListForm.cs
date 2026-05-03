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
                //  קבלת כל הלקוחות מה-BL
                var allCustomers = _bl.Customer.GetList();

                //הכנסת הערך שהוכנס לשורת החיפוש למשתנה
                string searchText = textBoxCus.Text;

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    // סינון הלקוחות על פי שורת החיפוש
                    allCustomers = allCustomers.Where(c => c.id.ToString().Contains(searchText));
                }

                // הצגת הלקוחות בטבלה לאחר הסינון
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
            // בדיקה שלא לחצו על שורת הכותרת 
            if (e.RowIndex >= 0)
            {
                //שמירת ה ID של הלקוח והכנסתו למשתנה
                var idValue = DataGridViewCus.Rows[e.RowIndex].Cells["ID"].Value;

                //אם לחצנו על לקוח ויש לו ID נפתח חלון הפרטים שלו
                if (idValue != null)
                {
                    int selectedId = (int)idValue;

                    
                    CustomerForm customerDetails = new CustomerForm(selectedId);

                    // הצגת החלון עם פרטי לקוח
                    customerDetails.ShowDialog();

                   
                    LoadData();
                }
            }
        }

        //הוספת לקוח חדש
        private void AddClientbutton_Click(object sender, EventArgs e)
        {
            // פתיחת חלון למילוי הפרטים
            CustomerForm addForm = new CustomerForm(0);

            //
            addForm.ShowDialog();

            //ריענון נתוני הטבלה לאחר הוספת לקוח חדש
            LoadData();
        }
    }
}
