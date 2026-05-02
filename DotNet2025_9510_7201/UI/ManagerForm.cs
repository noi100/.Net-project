using UI;
namespace UI
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        // לחיצה על ניהול מוצרים
        private void ProductManagementButton_Click(object sender, EventArgs e)
        {
            // הקוד לפתיחת החלון
            new ProductListForm().ShowDialog();
        }

        private void ClientManagementButton_Click_1(object sender, EventArgs e)
        {
            new CustomerListForm().ShowDialog();
        }

        private void SaleManagementButton_Click(object sender, EventArgs e)
        {
            new SaleListFrom().ShowDialog();
        }

    
    }
}
