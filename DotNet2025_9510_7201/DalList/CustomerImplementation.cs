using Do;
using DalApi;
using static Dal.DataSource;
using Tools;
using System.Xml;
using System.Reflection;

namespace Dal;

public class CustomerImplementation : ICustomer
{
    // יצירת לקוח חדש
    public int Create(Customer item)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName,MethodBase.GetCurrentMethod().Name, "Create Customer");
        if (Customers.Any(c => c.id == item.id))
            throw new DalAlreadyExistsException($"Customer with Barcode {item.id} already exists.");
        Customers.Add(item);
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Create Customer");
        return item.id;

    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //שינוי

    // קריאת נתוני לקוח לפי תנאי כלשהוא
    public Customer? Read(Func<Customer, bool> filter)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read Customer");
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Read Customer");


        return Customers.FirstOrDefault(filter);
    }

    public Customer? Read(int barcode)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read Customer by Barcode");
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Read Customer by Barcode");
        return Customers.FirstOrDefault(c => c.id == barcode);
    }
    // החזרת רשימת הלקוחות - עם אפשרות לסינון
    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll Customer");

        // אם לא נשלח פילטר, נחזיר את כל הרשימה כפי שהיה קודם
        if (filter == null)
        {
            return new List<Customer>(Customers);
        }

        // שימוש ב-LINQ (Query Syntax) כדי לסנן את הרשימה לפי הפילטר
        var result = from item in Customers
                     where filter(item)
                     select item;
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish ReadAll Customer");

        // LINQ מחזיר משהו שנקרא IEnumerable, לכן חייבים להפוך אותו ל-List בסוף
        return result.ToList();
    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // עדכון נתוני לקוח קיים
    public void Update(Customer item)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update Customer");

        Customer? existing = Customers.FirstOrDefault(c => c.id == item.id);
        if (existing == null)
            throw new DalDoesNotExistException($"Customer with Barcode {item.id} not found for update.");

        Customers.Remove(existing);
        Customers.Add(item);
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Update Customer");

    }

    // מחיקת לקוח 
    public void Delete(int barcode)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");

        Customer? existing = Customers.FirstOrDefault(c => c.id == barcode);
        if (existing == null)
            throw new DalDoesNotExistException($"Customer with Barcode {barcode} not found for deletion.");

        Customers.Remove(existing);
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Delete Customer");
    }
}