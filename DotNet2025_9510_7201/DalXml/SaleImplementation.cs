using DalApi;
using Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DalXml
{
    internal class SaleImplementation:ISale
    {
        public int Create(Sale item)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, "יצירת מכירה חדשה ב-XML");

            string filePath = @"..\xml\sales.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            List<Sale> salesList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                salesList = (List<Sale>)serializer.Deserialize(reader)!;
            }

            // יצירת מספר רץ
            int newId = Config.GetIdSale(); 
            Sale newItem = item with { id = newId };

            salesList.Add(newItem);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, salesList);
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום יצירת מכירה");

            return newId;
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            string filePath = @"..\xml\sales.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            List<Sale> salesList;
            using (StreamReader reader = new StreamReader(filePath))
            {
                salesList = (List<Sale>)serializer.Deserialize(reader)!;
            }
            //  חיפוש האיבר הראשון שמתאים לפונקציית הסינון
            Sale? result = salesList.FirstOrDefault(s => s != null && filter(s));
            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום קריאת מוצר לפי פילטר");

            return result;

        }
        public Sale? Read(int id)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"קריאת המבצע עם ID {barcode}");

            string filePath = @"..\xml\sales.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            List<Sale> salesList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                salesList = (List<Sale>)serializer.Deserialize(reader)!;
            }

            //  חיפוש מבצע עם מזהה המבוקש
            Sale? sale = salesList.FirstOrDefault(s=> s.id == id);
            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום קריאת מוצר");

            return sale;
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, "קריאת כל המוצרים מה-XML");

            string filePath = @"..\xml\sales.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            List<Sale> salesList;

            //  טעינת כל הרשימה מהקובץ
            using (StreamReader reader = new StreamReader(filePath))
            {
                salesList = (List<Sale>)serializer.Deserialize(reader)!;
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום טעינה");

            // אם לא נשלח פילטר (null) - נחזיר את כל הרשימה.
            // אם נשלח פילטר - נחזיר רק את האיברים שמתאימים לו.
            return filter == null ? salesList : salesList.Where(filter).ToList();
        }

        public void Update(Sale item)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"עדכון מוצר {item.barcode}");

            string filePath = @"..\xml\sales.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            List<Sale> salesList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                salesList = (List<Sale>)serializer.Deserialize(reader)!;
            }

            //  חיפוש המוצר הקיים ברשימה
            Sale? oldSale = salesList.FirstOrDefault(s => s.id == item.id);

            if (oldSale == null)
            {
                //LogManager.WriteError($"מוצר עם ברקוד {item.barcode} לא נמצא");
                throw new DalDoesNotExistException($"מבצע זה  {item.id} לא קיים במערכת");
            }

            //הסרץ הישן והוספת החדש
            salesList.Remove(oldSale);
            salesList.Add(item);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, salesList);
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום עדכון לקוח");
        }

        public void Delete(int id)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"מחיקת מוצר {barcode}");

            string filePath = @"..\xml\sales.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            List<Sale> salesList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                salesList = (List<Sale>)serializer.Deserialize(reader)!;
            }

            // חיפוש האיבר למחיקה
            Sale? saleToDelete = salesList.FirstOrDefault(s => s.id == id);

            if (saleToDelete == null)
            {
                //LogManager.WriteError($"ניסיון למחוק מוצר שלא קיים: {barcode}");
                throw new DalDoesNotExistException($"לא ניתן למחוק: מבצע זה {id} לא נמצא");
            }

            // מחיקה מהרשימה
            salesList.Remove(saleToDelete);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, salesList);
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום מחיקת מוצר");
        }
    }
}
