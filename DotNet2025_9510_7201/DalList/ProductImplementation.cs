using Do;
using DalApi;
using static Dal.DataSource;
using System.Reflection;
using Tools;
namespace Dal;

public class ProductImplementation:IProduct
{

    public int Create(Product item)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Create Product");

        // 1. קבלת ברקוד חדש מהקונפיג (לפי ה-Config שלך הוא יגדל ב-10)
        int newBarcode = Config.barcode;

        // 2. יצירת עותק של המוצר עם הברקוד החדש שנוצר
        Product newItem = item with { barcode = newBarcode };

        // 3. הוספה לרשימה
        Products.Add(newItem);

        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Create Product");

        // 4. החזרת הברקוד החדש
        return newBarcode;
    }
    public Product? Read(Func<Product, bool> filter)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read Product");
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Read Product");
        // אנחנו מוסיפים p != null כדי לוודא שהפילטר רץ רק על אובייקטים קיימים
        return Products.FirstOrDefault(p => p != null && filter(p));
    }
    public Product? Read(int barcode)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read Product by Barcode");
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Read Product by Barcode");
        // הוספת p != null כדי להגן מפני איברים ריקים ברשימה
        return Products.FirstOrDefault(p => p != null && p.barcode == barcode);
    }
    //ישן
    //public List<Product> ReadAll(Func<Product, bool>? filter = null)
    //{
    //   if(filter==null)
    //        return new List<Product>(Products);
    //    var result = from item in Products
    //                 where filter(item)
    //                 select item;
    //    return result.ToList();
    //}
    //חדש
    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll Product");
        var cleanList = Products.Where(p => p != null).Select(p => p!);

        if (filter == null)
            return cleanList.ToList();
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish ReadAll Product");

        return cleanList.Where(filter).ToList();
    }
    public void Update(Product item)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update Product");

        // חיפוש המוצר הקיים
        Product? c = Products.FirstOrDefault(p => p != null && p.barcode == item.barcode);

        if (c == null)
            throw new DalDoesNotExistException($"Product with Barcode {item.barcode} not found for update.");

        Products.Remove(c);
        Products.Add(item);
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Update Product");

    }
    public void Delete(int barcode)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Product");

        // הוספת c != null כדי להגן מפני איברים ריקים ברשימה
        Product? c = Products.FirstOrDefault(c => c != null && c.barcode == barcode);

        if (c == null)
            throw new DalDoesNotExistException($"Product with Barcode {barcode} not found for deletion.");

        Products.Remove(c);
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Delete Product");

    }
}

