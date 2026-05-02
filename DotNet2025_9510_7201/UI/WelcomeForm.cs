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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void ManagerFormButton_Click(object sender, EventArgs e)
        {
            // 1. יצירת מופע חדש של חלון המנהל
            ManagerForm managerWindow = new ManagerForm();

            // 2. הצגת חלון המנהל
            managerWindow.Show();

            // 3. אופציונלי: הסתרת חלון הכניסה הנוכחי כדי שלא יפריע
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // פתיחת חלון ההזמנות
            OrderForm orderWindow = new OrderForm();
            orderWindow.ShowDialog();
        }
    }
}
