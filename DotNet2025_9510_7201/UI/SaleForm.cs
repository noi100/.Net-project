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
    public partial class SaleForm : Form
    {
        // חיבור לשכבת הלוגיקה
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();
        private int _saleId;

        // הבנאי - מקבל ID (0 להוספה, מספר אחר לעדכון)
        public SaleForm(int id = 0)
        {
            InitializeComponent();
            _saleId = id;

            if (_saleId != 0) // מצב עדכון - מילוי שדות אוטומטי
            {
                try
                {
                    var sale = _bl.Sale.GetProduct(_saleId);

                    // מילוי השדות מהאובייקט שנשלף מה-BL
                    txtIDs.Text = sale.id.ToString();
                    txtProductS.Text = sale.idProduct.ToString();
                    txtPriceS.Text = sale.priceSale.ToString();
                    txtAmountS.Text = sale.amountToGetSale.ToString();
                    checkBoxClub.Checked = sale.IsClubMemberOnly;
                    dateTimePickerStart.Value = sale.start;
                    dateTimePickerEnd.Value = sale.end;

                    txtIDs.ReadOnly = true; // אי אפשר לשנות ID קיים
                    btnDelete.Enabled = true; // כפתור מחיקה פעיל רק בעדכון
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה בטעינת נתוני המבצע: " + ex.Message);
                }
            }
            else // מצב הוספה - שדות ריקים/ברירת מחדל
            {
                txtIDs.Text = "אוטומטי";
                txtIDs.ReadOnly = true;
                btnDelete.Enabled = false; // אי אפשר למחוק מבצע שעדיין לא קיים

                // איפוס שדות
                txtProductS.Text = "";
                txtPriceS.Text = "";
                txtAmountS.Text = "";
                checkBoxClub.Checked = false;
                dateTimePickerStart.Value = DateTime.Now;
                dateTimePickerEnd.Value = DateTime.Now.AddDays(7);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. בדיקת חסימה - ודאי ששדות חובה לא ריקים
            if (string.IsNullOrWhiteSpace(txtProductS.Text) || string.IsNullOrWhiteSpace(txtPriceS.Text))
            {
                MessageBox.Show("נא למלא קוד מוצר ומחיר מבצע");
                return;
            }

            try
            {
                // 2. יצירת אובייקט BO חדש מהנתונים שהוזנו בטופס
                BO.Sale saleToSave = new BO.Sale
                {
                    id = _saleId,
                    idProduct = int.Parse(txtProductS.Text),
                    priceSale = int.Parse(txtPriceS.Text),
                    amountToGetSale = int.Parse(txtAmountS.Text),
                    IsClubMemberOnly = checkBoxClub.Checked,
                    start = dateTimePickerStart.Value,
                    end = dateTimePickerEnd.Value
                };

                // 3. שליחה ל-BL לפי המצב (הוספה או עדכון)
                if (_saleId == 0)
                {
                    _bl.Sale.Add(saleToSave);
                    MessageBox.Show("המבצע נוסף בהצלחה למערכת");
                }
                else
                {
                    _bl.Sale.Update(saleToSave);
                    MessageBox.Show("נתוני המבצע עודכנו בהצלחה");
                }

                this.Close(); // סגירת החלון וחזרה לרשימה
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בתהליך השמירה: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("האם את בטוחה שברצונך למחוק את המבצע לצמיתות?",
                                              "אישור מחיקה", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // מחיקה מהשכבות (ה-BL קורא ל-DAL ומסיר מהרשימות)
                    _bl.Sale.Delete(_saleId);
                    MessageBox.Show("המבצע נמחק בהצלחה מכל השכבות");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("לא ניתן למחוק את המבצע: " + ex.Message);
                }
            }
        }
    }
}
