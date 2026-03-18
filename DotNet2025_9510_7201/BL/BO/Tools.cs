namespace BO;

using Do;
using System.Reflection;

public static class Tools
{
    // פונקציית הרחבה (Extension Method) שעוברת על כל המאפיינים ומדפיסה אותם
    public static string ToStringProperty<T>(this T obj)
    {
        if (obj == null) return "";

        string str = "";
        // מעבר על כל ה-Properties של האובייקט בעזרת Reflection
        foreach (PropertyInfo item in obj.GetType().GetProperties())
        {
            var value = item.GetValue(obj, null);
            if (value is IEnumerable<object> list && !(value is string))
                str += $"{item.Name}: \n  " + string.Join("  ", list) + "\n";
            else
                str += $"{item.Name}: {value}\n";
            //str += "\n" + item.Name + ": " + item.GetValue(obj, null);
        }
        return str;
    }

    //// פונקציית המרה גנרית מטיפוס מקור לטיפוס יעד
    //// זה פותר את הדרישה להמרות בין DO ל-BO ולהיפך
    //public static TTarget CopyProperties<TSource, TTarget>(this TSource source, TTarget target)
    //{
    //    // מעבר על כל המאפיינים של אובייקט היעד
    //    foreach (var targetProp in typeof(TTarget).GetProperties())
    //    {
    //        // חיפוש מאפיין עם אותו שם בטיפוס המקור
    //        var sourceProp = typeof(TSource).GetProperty(targetProp.Name);

    //        // אם קיים מאפיין כזה וניתן לקרוא ממנו ולכתוב אליו
    //        if (sourceProp != null && sourceProp.CanRead && targetProp.CanWrite)
    //        {
    //            var value = sourceProp.GetValue(source);

    //            // טיפול מיוחד ב-Enums (כמו Category) - המרה אוטומטית ביניהם
    //            if (targetProp.PropertyType.IsEnum && value != null)
    //            {
    //                targetProp.SetValue(target, Enum.ToObject(targetProp.PropertyType, value));
    //            }
    //            else
    //            {
    //                targetProp.SetValue(target, value);
    //            }
    //        }
    //    }
    //    return target;
    //}
    public static BO.Product ToBO(this Do.Product doProd)
    {
        return new BO.Product
        {
            barcode = doProd.barcode,
            name = doProd.name,
            category = doProd.category,
            price = doProd.price,

            amount = doProd.amount,
        };
    }
    public static BO.Customer ToBO(this Do.Customer doCustomer)
    {
        return new BO.Customer
        {
            id = doCustomer.id,
            name = doCustomer.name,
            adress = doCustomer.adress,
            phoneNumber = doCustomer.phoneNumber,
        };
    }
    public static BO.Sale ToBO(this Do.Sale doSale)
    {
        return new BO.Sale
        {
            id = doSale.id,
            amountToGetSale = doSale.amountToGetSale,
            priceSale = doSale.priceSale,
            idProduct = doSale.idProduct,
            IsClubMemberOnly = doSale.IsClubMemberOnly,
            start = doSale.start,
            end = doSale.end,
        };
    }
}