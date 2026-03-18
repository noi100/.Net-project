using DalApi;
using Do;
using System.Reflection;
using Tools;


namespace DalTest
{
    internal class Program
    {
        private static IDal s_dal = DalApi.Factory.Get;
        private static void Main(string[] args)
        {
            //Console.WriteLine("if you want to delet pars 1");
            //int num = int.Parse(Console.ReadLine());
            //if (num == 1)
            //    LogManager.DeletFiles();
            Initialization.Initialize();
            //??? האם להכניס את הטרי לתוך הוויל
            try
            {
                int select1 = PrintMainMenu();
                while (select1 != 0)
                {
                    switch (select1)
                    {
                        case 1:
                            Console.WriteLine("Product");
                            ProductMenu();
                            break;
                        case 2:
                            Console.WriteLine("Sale");
                            SaleMenu();
                            break;
                        case 3:
                            Console.WriteLine("Custemer");
                            CustomerMenu();
                            break;
                        //??
                        case 0:
                            Console.WriteLine("exist");
                            break;
                        default:
                            Console.WriteLine("Wrong selection!!! \n please select again");
                            break;
                    }
                    select1 = PrintMainMenu();
                }
            }
            //להשתמש בID?
            catch (DalDoesNotExistException e)
            {
                LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Error DalDoesNotExistException");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        private static void ProductMenu()
        {
            Console.WriteLine("enter for AddProduct 1, for UpdateProduct 2, for ReadAll 3, for Read 4 , for Delete 5");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        ReadAll(s_dal.Product);
                        break;
                    case 4:
                        Read(s_dal.Product);
                        break;
                    case 5:
                        Delete(s_dal.Product);
                        break;
                    default:
                        Console.WriteLine("try agen");
                        break;
                }
                Console.WriteLine("enter for AddProduct 1, for UpdateProduct 2, for ReadAll 3, for Read 4 , for Delete 5");
                x = int.Parse(Console.ReadLine());
            }
        }
        private static void SaleMenu()
        {
            Console.WriteLine("enter for AddSale 1, for UpdateSale 2, for ReadAll 3, for Read 4 , for Delete 5");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        AddSale();
                        break;
                    case 2:
                        UpdateSale();
                        break;
                    case 3:
                        ReadAll(s_dal.Sale);
                        break;
                    case 4:
                        Read(s_dal.Sale);
                        break;
                    case 5:
                        Delete(s_dal.Sale);
                        break;
                    default:
                        Console.WriteLine("try agen");
                        break;
                }
                Console.WriteLine("enter for AddSale 1, for UpdateSale 2, for ReadAll 3, for Read 4 , for Delete 5");
                x = int.Parse(Console.ReadLine());
            }
        }
        private static void CustomerMenu()
        {
            Console.WriteLine("enter for AddCustomer 1, for UpdateCustomer 2, for ReadAll 3, for Read 4 , for Delete 5");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        UpdateCustomer();
                        break;
                    case 3:
                        ReadAll(s_dal.Customer);
                        break;
                    case 4:
                        Read(s_dal.Customer);
                        break;
                    case 5:
                        Delete(s_dal.Customer);
                        break;
                    default:
                        Console.WriteLine("try agen");
                        break;
                }
                Console.WriteLine("enter for AddCustomer 1, for UpdateCustomer 2, for ReadAll 3, for Read 4 , for Delete 5");
                x = int.Parse(Console.ReadLine());
            }
        }
        private static Product AskProduct(int barcode = 0)
        {
            string name;
            category category;
            double price;
            int amount;

            Console.WriteLine("Enter the Name of the product");
            name = Console.ReadLine();

            Console.WriteLine("Enter the category: between 0 to 3 ");
            int cat;
            if (!int.TryParse(Console.ReadLine(), out cat)) category = 0;
            else
                category = (category)cat;

            Console.WriteLine("Enter Price");
            if (!double.TryParse(Console.ReadLine(), out price)) price = 10;

            Console.WriteLine("Enter count in stock");
            if (!int.TryParse(Console.ReadLine(), out amount)) amount = 0;

            return new Product(barcode, name, category, price, amount);
        }
        private static Sale AskSale(int id = 0)
        {
            int amountToGetSale;
            int priceSale;
            int idSale;
            bool IsClubMemberOnly;
            DateTime start;
            DateTime end;

            Console.WriteLine("Enter the amountToGetSale of the sale");
            amountToGetSale = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the priceSale ");
            priceSale = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter idProduct");
            idSale = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter if you are in member");
            IsClubMemberOnly = bool.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of start");
            start = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of end");
            end = DateTime.Parse(Console.ReadLine());

            return new Sale(id, amountToGetSale, priceSale, idSale, IsClubMemberOnly, start, end);
        }
        private static Customer AskCustomer(int id = 0)
        {
            string name;
            string adress;
            int phoneNumber;
            Console.WriteLine("Enter the Name of the customer");
            name = Console.ReadLine();
            Console.WriteLine("Enter the adress");
            adress = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            phoneNumber = int.Parse(Console.ReadLine());
            return new Customer(id, name, adress, phoneNumber);
        }
        private static void AddProduct()
        {
            Product p = AskProduct();
            int id = s_dal.Product.Create(p);
            p = p with { barcode = id };
            Console.WriteLine("success" + p);
        }
        private static void AddSale()
        {
            Sale s = AskSale();
            int id = s_dal.Sale.Create(s);
            s = s with { id = id };
            Console.WriteLine("success" + s);
        }
        private static void AddCustomer()
        {
            Customer c = AskCustomer();
            int id = s_dal.Customer.Create(c);
            c = c with { id = id };
            Console.WriteLine("success" + c);
        }
        private static void UpdateProduct()
        {
            try
            {
                int code;
                Console.WriteLine("Enter product code");
                code = int.Parse(Console.ReadLine());
                //if (!int.TryParse(Console.ReadLine(), out code))
                //code = 200;//איזה קוד?
                Product p = AskProduct(code);
                s_dal.Product.Update(p);
            }
            catch (DalDoesNotExistException e)
            {
                LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Error DalDoesNotExistException");
                Console.WriteLine(e.Message);
            }
        }
        private static void UpdateSale()
        {
            try
            {
                int code;
                Console.WriteLine("Enter Sale id");
                if (!int.TryParse(Console.ReadLine(), out code))
                    code = 0;//איזה קוד?
                             // code =int.Parse(Console.ReadLine());
                Sale s = AskSale(code);
                s_dal.Sale.Update(s);
            }
            catch (DalDoesNotExistException e) 
            {
                LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Error DalDoesNotExistException");
                Console.WriteLine(e.Message);
            }
        }
        private static void UpdateCustomer()
        {
            try
            {
                Console.WriteLine("Enter Custumer id");
                int code = int.Parse(Console.ReadLine());
                Customer c = AskCustomer(code);
                s_dal.Customer.Update(c);
            }
            catch (DalDoesNotExistException e)
            {
                LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Error DalDoesNotExistException");
                Console.WriteLine(e.Message); 
            }
        }
        private static void ReadAll<T>(ICrud<T> icrud)
        {
            var list = icrud.ReadAll();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void Read<T>(ICrud<T> icrud)
        {
            try
            {
                Console.WriteLine("Enter Code");
                int code = int.Parse(Console.ReadLine());
                //Console.WriteLine(icrud.Read(code));
            }
            catch (DalDoesNotExistException e)
            {
                LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Error DalDoesNotExistException");
                Console.WriteLine(e.Message);
            }
        }
        private static void Delete<T>(ICrud<T> icrud)
        {
            try
            {
                Console.WriteLine("enter id to delete");
                int id = int.Parse(Console.ReadLine());
                icrud.Delete(id);
                Console.WriteLine("deleted successfully");
            }
            catch (DalDoesNotExistException e)
            {
                LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Error DalDoesNotExistException");
                Console.WriteLine(e.Message);
            }
        }
        public static int PrintMainMenu()
        {
            Console.WriteLine("enter for Product 1 , for Sale 2  , for Customer 3");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:
                    ProductMenu();
                    break;
                case 2:
                    SaleMenu();
                    break;
                case 3:
                    CustomerMenu();
                    break;
                default:
                    Console.WriteLine("Try again");
                    break;
            }
            return x;
        }
        public static int PrintSubMenue(string item)
        {
            Console.WriteLine($"To read all {item} press 1");
            Console.WriteLine($"To read one {item} press 2");
            Console.WriteLine($"To add {item} press 3");
            Console.WriteLine($"To delete {item} press 4");
            Console.WriteLine($"To update {item} press 5");
            Console.WriteLine("To go back press 0");
            int select;
            select = int.Parse(Console.ReadLine());
            return select;
        }
    }

}

