using BlApi;
using BO;
using System.Reflection;

namespace BLTest2
{
    internal class Program
    {
        // יצירת הגישה לשכבת ה-BL דרך המפעל
        static readonly IBl s_bl = Factory.Get();

        static void Main(string[] args)
        {
            // אתחול נתונים - קריאה למחלקה שקיימת אצלך ב-DalTest
            Console.WriteLine("Do you want to initialize data? (Y/N)");
            string? answer = Console.ReadLine();
            if (answer?.ToUpper() == "Y")
            {
                // כאן אנחנו קוראים לאתחול שכתבת ב-DAL
                DalTest.Initialization.Initialize();
            }

            int select;
            do
            {
                try
                {
                    // תפריט ראשי
                    Console.WriteLine("\n--- Business Logic Test Menu ---");
                    Console.WriteLine("enter for Product 1, for Sale 2, for Customer 3, 0 to Exit");
                    if (!int.TryParse(Console.ReadLine(), out select)) select = -1;

                    if (select == 0) break;

                    switch (select)
                    {
                        //case 1: ProductMenu(); break;
                        //case 2: SaleMenu(); break;
                        case 3: CustomerMenu(); break;
                        default: Console.WriteLine("Wrong selection!"); break;
                    }
                }
                catch (Exception e)
                {
                    // תפיסת שגיאות לוגיות (כמו "לקוח לא נמצא") והדפסת הודעה
                    Console.WriteLine($"Error: {e.Message}");
                }
                Console.WriteLine("\nReturning to Main Menu...");
            } while (true);
        }

        // --- תפריט לקוחות ---
        private static void CustomerMenu()
        {
            Console.WriteLine("\nCustomer Actions: 1:Add, 2:Update, 3:ReadAll, 4:Read, 5:Delete, 0:Back");
            int x = int.Parse(Console.ReadLine()!);
            while (x != 0)
            {
                try
                {
                    switch (x)
                    {
                        case 1: AddCustomer(); break;
                        case 2: UpdateCustomer(); break;
                        case 3: // הצגת כולם - ב-BL קראנו לזה GetList
                            var list = s_bl.Customer.GetList();
                            foreach (var item in list) Console.WriteLine(item);
                            break;
                        case 4: // קריאת אחד - ב-BL קראנו לזה Get
                            Console.Write("Enter ID to Read: ");
                            int id = int.Parse(Console.ReadLine()!);
                            Console.WriteLine(s_bl.Customer.Get(id));
                            break;
                        case 5: // מחיקה
                            Console.Write("Enter ID to Delete: ");
                            s_bl.Customer.Delete(int.Parse(Console.ReadLine()!));
                            Console.WriteLine("Deleted successfully");
                            break;
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

                Console.WriteLine("\n1:Add, 2:Update, 3:ReadAll, 4:Read, 5:Delete, 0:Back");
                x = int.Parse(Console.ReadLine()!);
            }
        }

        // --- פונקציות עזר להוספה ועדכון (באמצעות ישויות BO) ---

        private static void AddCustomer()
        {
            Console.WriteLine("Enter ID, Name, Address, Phone:");
            Customer c = new Customer
            {
                id = int.Parse(Console.ReadLine()!),
                name = Console.ReadLine(),
                address = Console.ReadLine(),
                phoneNumber = int.Parse(Console.ReadLine()!) // שימי לב לשם השדה ב-BO
            };
            s_bl.Customer.Add(c); // ב-BL הפעולה נקראת Add
            Console.WriteLine("Success: " + c);
        }

        private static void UpdateCustomer()
        {
            Console.WriteLine("Enter ID to update:");
            int id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter New Name and Address:");
            Customer c = new Customer
            {
                id = id,
                name = Console.ReadLine(),
                address = Console.ReadLine()
            };
            s_bl.Customer.Update(c);
            Console.WriteLine("Updated successfully");
        }

        // כאן יוסיפו באותו מבנה את ProductMenu ו-SaleMenu...
    }
}
 

//namespace BlTest
//{
//    internal class Program
//    {
       
//    }
//}