using System;
using System.Collections.Generic;
using System.Linq;
using Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using System.Collections;
using System.Data.Common;

namespace DalTest
{


    public static class Initialization
    {
        private static IDal s_dal = DalApi.Factory.Get;

        //private static List<int> productCodes = new List<int>();

        private static void createProducts()
        {
            s_dal.Product.Create(new Product(0, "glue", category.ArtAndCraft, 10, 50));
            s_dal.Product.Create(new Product(0, "ball", category.Outdoor, 40, 60));
            s_dal.Product.Create(new Product(0, "magnet ball", category.BoardGames, 60, 20));
            s_dal.Product.Create(new Product(0, "Clicks", category.BuildingToys, 10, 120));
            s_dal.Product.Create(new Product(0, "soft doll", category.Dols, 30, 20));
        }

        private static void createSales()
        {
            //int id,int amountToGetSale,int priceSale, int idSale, bool IsClubMemberOnly, DateTime start,DateTime end
            s_dal.Sale.Create(new Sale(0, 1, 8, 30, false, DateTime.Now, DateTime.Now.AddDays(7)));
            s_dal.Sale.Create(new Sale(0, 5, 180, 21, true, DateTime.Now, DateTime.Now.AddDays(7)));
            s_dal.Sale.Create(new Sale(0, 2, 100, 10, true, DateTime.Now, DateTime.Now.AddDays(30)));
            s_dal.Sale.Create(new Sale(0, 1, 110, 15, false, DateTime.Now, DateTime.Now.AddDays(7)));
            s_dal.Sale.Create(new Sale(0, 3, 80, 40, true, DateTime.Now, DateTime.Now.AddDays(7)));
        }

        private static void createCustomer()
        {
            //int id, string name, string adress, int phoneNumber
            s_dal.Customer.Create(new Customer(4,"Mosh Choen","Zit street",0528687741));
            s_dal.Customer.Create(new Customer(521,"Michal Levi", "Tamar street", 0504187741));
            s_dal.Customer.Create(new Customer(09562,"Thila Caz", "Rimon street", 0533687741));
            s_dal.Customer.Create(new Customer(50,"Yonatan Yahakobov", "Gefen street", 0527108664));
            s_dal.Customer.Create(new Customer(630,"Hevyatar Lavi", "Thena street", 0544487741));
            s_dal.Customer.Create(new Customer(45520,"Sara Yizchak", "Chita street", 0588683141));
        }

        public static void Initialize()
        {

            createProducts();
            createSales();
            createCustomer();
        }
    }
}
