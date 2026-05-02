using DalApi;
using Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dal
{
    internal class ProductImplementation:IProduct
    {
        public int Create(Product item)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, "יצירת מוצר חדש ב-XML");

            string filePath = @"..\xml\products.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> productsList;

            // קריאה מXML
            using (StreamReader reader = new StreamReader(filePath))
            {
                productsList = (List<Product>)serializer.Deserialize(reader)!;
            }

          
            if (productsList.Any(p => p.barcode == item.barcode))
            {
                //LogManager.WriteError("ניסיון להוסיף מוצר עם שם קיים");
                throw new DalAlreadyExistsException($"המוצר {item.name} כבר קיים במערכת");
            }

            // משתנה רץ
            int newBarcode = Config.getBrcode();
            Product newItem = item with { barcode = newBarcode };

            //הוספה לרשימה 
            productsList.Add(newItem);

            // שמירה
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, productsList);
            }

            //  לוג סיום פעולה
            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום יצירת מוצר בהצלחה");

            return newBarcode;
        }
        public Product? Read(Func<Product, bool> filter)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, "קריאת מוצר בודד לפי פילטר");

            string filePath = @"..\xml\products.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> productsList;


            using (StreamReader reader = new StreamReader(filePath))
            {
                productsList = (List<Product>)serializer.Deserialize(reader)!;
            }

            //  חיפוש האיבר הראשון שמתאים לפונקציית הסינון
            Product? result = productsList.FirstOrDefault(p => p != null && filter(p));

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום קריאת מוצר לפי פילטר");

            return result;
        }
        public Product? Read(int barcode)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"קריאת מוצר עם ברקוד {barcode}");

            string filePath = @"..\xml\products.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> productsList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                productsList = (List<Product>)serializer.Deserialize(reader)!;
            }

            //  חיפוש המוצר
            Product? product = productsList.FirstOrDefault(p => p.barcode == barcode);
            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום קריאת מוצר");

            return product;
        }
        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, "קריאת כל המוצרים מה-XML");

            string filePath = @"..\xml\products.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> productsList;

            //  טעינת כל הרשימה מהקובץ
            using (StreamReader reader = new StreamReader(filePath))
            {
                productsList = (List<Product>)serializer.Deserialize(reader)!;
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום טעינה");

            // אם לא נשלח פילטר (null) - נחזיר את כל הרשימה.
            // אם נשלח פילטר - נחזיר רק את האיברים שמתאימים לו.
            return filter == null ? productsList : productsList.Where(filter).ToList();
        }

        public void Update(Product item)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"עדכון מוצר {item.barcode}");

            string filePath = @"..\xml\products.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> productsList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                productsList = (List<Product>)serializer.Deserialize(reader)!;
            }

            //  חיפוש המוצר הקיים ברשימה
            Product? oldProduct = productsList.FirstOrDefault(p => p.barcode == item.barcode);

            if (oldProduct == null)
            {
                //LogManager.WriteError($"מוצר עם ברקוד {item.barcode} לא נמצא");
                throw new DalDoesNotExistException($"מוצר עם ברקוד {item.barcode} לא קיים במערכת");
            }

           //הסרץ הישן והוספת החדש
            productsList.Remove(oldProduct);
            productsList.Add(item);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, productsList);
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום עדכון מוצר");
        }
        public void Delete(int barcode)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"מחיקת מוצר {barcode}");

            string filePath = @"..\xml\products.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> productsList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                productsList = (List<Product>)serializer.Deserialize(reader)!;
            }

            // חיפוש האיבר למחיקה
            Product? productToDelete = productsList.FirstOrDefault(p => p.barcode == barcode);

            if (productToDelete == null)
            {
                //LogManager.WriteError($"ניסיון למחוק מוצר שלא קיים: {barcode}");
                throw new DalDoesNotExistException($"לא ניתן למחוק: מוצר {barcode} לא נמצא");
            }

            // מחיקה מהרשימה
            productsList.Remove(productToDelete);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, productsList);
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום מחיקת מוצר");
        }
    }
}
