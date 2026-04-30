using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BO;

namespace UI
{
    public partial class CustomerForm : Form
    {
        // חיבור ללוגיקה ומשתנה לשמירת ה-ID הנוכחי
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();
        private int _customerId;

        public CustomerForm(int id)
        {
            InitializeComponent();
            _customerId = id;

            if (_customerId != 0) // מצב עדכון
            {
                this.Text = "Update Customer";
                LoadCustomerData();
                txtIdCus.ReadOnly = true; // אסור לשנות ת"ז של לקוח קיים
                btnDeleteCus.Enabled = true; // אפשר למחוק רק לקוח קיים
            }
            else // מצב הוספה
            {
                this.Text = "Add New Customer";
                btnDeleteCus.Enabled = false; // אי אפשר למחוק לקוח שעוד לא נוצר
            }
        }

        // טעינת נתונים לתוך התיבות במקרה של עדכון
        private void LoadCustomerData()
        {
            try
            {
                var customer = _bl.Customer.Get(_customerId);
                txtIdCus.Text = customer.id.ToString();
                txtNameCus.Text = customer.name;
                txtAddressCus.Text = customer.address;
                txtPhoneCus.Text = customer.phoneNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הלקוח: " + ex.Message);
            }
        }
        //מחיקת הלקוח הנוכחי , אישור משתמש ובדיקה האם אפשר למחוק את הלקוח במידה ואין לו הזמנות פתוחות
        private void btnDeleteCus_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("האם את בטוחה שברצונך למחוק לקוח זה?", "אישור מחיקה", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _bl.Customer.Delete(_customerId);
                    MessageBox.Show("הלקוח נמחק בהצלחה");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("לא ניתן למחוק לקוח זה: " + ex.Message);
                }
            }
        }

        private void btnSaveCus_Click(object sender, EventArgs e)
        {
            // 1. בדיקת תקינות - זה השלב הראשון!
            if (string.IsNullOrWhiteSpace(txtIdCus.Text) ||
                string.IsNullOrWhiteSpace(txtNameCus.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneCus.Text))
            {
                MessageBox.Show("נא למלא את כל שדות החובה: תעודת זהות, שם ומספר טלפון.");
                return; // עוצר את הפונקציה כאן ולא ממשיך לשמירה
            }
            try
            {
                // יצירת אובייקט לקוח חדש מהנתונים בתיבות
                Customer customer = new Customer
                {
                    id = int.Parse(txtIdCus.Text),
                    name = txtNameCus.Text,
                    address = txtAddressCus.Text,
                    phoneNumber = int.Parse(txtPhoneCus.Text)
                };

                if (_customerId == 0) // הוספה
                {
                    _bl.Customer.Add(customer);
                    MessageBox.Show("הלקוח נוסף בהצלחה!");
                }
                else // עדכון
                {
                    _bl.Customer.Update(customer);
                    MessageBox.Show("פרטי הלקוח עודכנו!");
                }

                this.Close(); // סגירת החלון אחרי הצלחה
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בשמירה: " + ex.Message);
            }
        }
    }
}
