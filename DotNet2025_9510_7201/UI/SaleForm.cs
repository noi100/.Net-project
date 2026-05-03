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

        // הבנאי נקבל 0 או 1 כדח לדעת למה הגיע לפה בגלל עדכון או בגלל הוספה
        public SaleForm(int id = 0)
        {
            InitializeComponent();
            _saleId = id;

            if (_saleId != 0) // בעדכון, מילוי שדות אוטומטי
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
                    btnDelete.Enabled = true; // כפתור מחיקה , רק בעדכון
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה בטעינת נתוני המבצע: " + ex.Message);
                }
            }
            else // מצב הוספה  
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

        //שמירת האובייקט עם נתונים מהשדות

        private void btnSave_Click(object sender, EventArgs e)
        {
            //  בדיקת  ששדות חובה לא ריקים
            if (string.IsNullOrWhiteSpace(txtProductS.Text) || string.IsNullOrWhiteSpace(txtPriceS.Text))
            {
                MessageBox.Show("נא למלא קוד מוצר ומחיר מבצע");
                return;
            }

            try
            {
                // חיבור נתונים מהשדות לאובייקט חדש או מעודכן
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

                // בהתאם לערך שבמשתנה יתנהל כמחיקה או עדכון
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

        //מחיקת מבצע
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("האם את בטוחה שברצונך למחוק את המבצע לצמיתות?",
                                              "אישור מחיקה", MessageBoxButtons.YesNo);

            //לאחר האישור מהמשתמש
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    
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

        private void ProductIDLableS_Click(object sender, EventArgs e)
        {

        }
    }
}
