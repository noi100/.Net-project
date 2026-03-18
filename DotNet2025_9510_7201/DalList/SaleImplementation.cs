using Do;
using DalApi;
using static Dal.DataSource;
using System.Reflection;
using Tools;

namespace Dal;

public class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Create Sale");

        // 1. מייצרים את ה-ID החדש מהקונפיג
        int newId = Config.idSale;

        // 2. יוצרים עותק של המכירה עם ה-ID החדש (שימוש ב-with עבור record)
        Sale newItem = item with { id = newId };

        // 3. מוסיפים לרשימה את האובייקט המעודכן
        Sales.Add(newItem);
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Create Sale");

        // 4. מחזירים את ה-ID החדש
        return newId;
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read Sale");
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Read Sale"); 
        // הוספת בדיקת null לפני הרצת הפילטר כדי למנוע קריסה
        return Sales.FirstOrDefault(s => s != null && filter(s));
    }
    public Sale? Read(int id)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read Sale by ID");
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Read Sale by ID");
        // הוספת בדיקת null לפני הרצת הפילטר כדי למנוע קריסה
        return Sales.FirstOrDefault(s => s != null && s.id == id);
    }
    //יש פה בעיה עם הסימן ?
    //ישן
    //public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    //{
    //    if (filter == null)
    //        return new List<Sale>(Sales);

    //    var result = from item in Sales
    //                 where filter(item)
    //                 select item;
    //    return result.ToList();
    //}
    //חדש
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll Sale");
        // 1. ניקוי הרשימה מ-nullים והפיכתה לטיפוס לא-nullable בעזרת !
        var nonNullSales = Sales.Where(s => s != null).Select(s => s!);

        // 2. אם אין פילטר, נחזיר את הרשימה הנקייה
        if (filter == null)
            return nonNullSales.ToList();

        // 3. שימוש ב-Query Syntax על הרשימה הנקייה
        var result = from item in nonNullSales
                     where filter(item)
                     select item;
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish ReadAll Sale");
        return result.ToList();
    }
    public void Update(Sale item)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update Sale");

        // החלפת ה-foreach ב-LINQ (מתודת הרחבה)
        Sale? existing = Sales.FirstOrDefault(s => s.id == item.id);

        if (existing == null)
            throw new DalDoesNotExistException($"Sale with ID {item.id} not found for update.");

        Sales.Remove(existing);
        Sales.Add(item);
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Update Sale");

    }
    public void Delete(int id)
    {
        LogManager.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Sale");

        Sale? c = Sales.FirstOrDefault(c => c.id == id);
        if (c == null)
            throw new DalDoesNotExistException($"Sale with Barcode {id} not found for deletion.");
        Sales.Remove(c);
        LogManager.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Delete Sale");

    }
}

