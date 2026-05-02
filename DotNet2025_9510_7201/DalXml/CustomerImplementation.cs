using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Do;

namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {
        public int Create(Customer item)
        {
            // LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                      MethodBase.GetCurrentMethod()!.Name, "יצירת לקוח חדש ב-XML");

            string filePath = @"..\xml\customers.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            List<Customer> customersList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                customersList = (List<Customer>)serializer.Deserialize(reader)!;
            }

            // האם בלקחו קיים?
            if (customersList.Any(c => c.id == item.id))
            {
                // LogManager.WriteError("ניסיון להוסיף לקוח עם ת"ז קיימת");
                throw new DalAlreadyExistsException($"הלקוח  {item.id} כבר קיים במערכת");
            }

            customersList.Add(item);


            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, customersList);
            }

            // LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                    MethodBase.GetCurrentMethod()!.Name, "סיום יצירת לקוח בהצלחה");

            return item.id;
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            string filePath = @"..\xml\customers.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            List<Customer> customersList;
            using (StreamReader reader = new StreamReader(filePath))
            {
                customersList = (List<Customer>)serializer.Deserialize(reader)!;
            }
            //  חיפוש האיבר הראשון שמתאים לפונקציית הסינון
            Customer? result = customersList.FirstOrDefault(c => c != null && filter(c));
            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום קריאת מוצר לפי פילטר");

            return result;

        }
        public Customer? Read(int id)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"קריאת מוצר עם ברקוד {barcode}");

            string filePath = @"..\xml\customers.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            List<Customer> customersList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                customersList = (List<Customer>)serializer.Deserialize(reader)!;
            }

            //  חיפוש המוצר
            Customer? customer = customersList.FirstOrDefault(c => c.id == id);
            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום קריאת מוצר");

            return customer;
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, "קריאת כל המוצרים מה-XML");

            string filePath = @"..\xml\customers.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            List<Customer> customersList;

            //  טעינת כל הרשימה מהקובץ
            using (StreamReader reader = new StreamReader(filePath))
            {
                customersList = (List<Customer>)serializer.Deserialize(reader)!;
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום טעינה");

            // אם לא נשלח פילטר (null) - נחזיר את כל הרשימה.
            // אם נשלח פילטר - נחזיר רק את האיברים שמתאימים לו.
            return filter == null ? customersList : customersList.Where(filter).ToList();
        }

        public void Update(Customer item)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"עדכון מוצר {item.barcode}");

            string filePath = @"..\xml\customers.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            List<Customer> customersList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                customersList = (List<Customer>)serializer.Deserialize(reader)!;
            }

            //  חיפוש המוצר הקיים ברשימה
            Customer? oldCustomer = customersList.FirstOrDefault(p => p.id == item.id);

            if (oldCustomer == null)
            {
                //LogManager.WriteError($"מוצר עם ברקוד {item.barcode} לא נמצא");
                throw new DalDoesNotExistException($"לקוח זה  {item.id} לא קיים במערכת");
            }

            //הסרץ הישן והוספת החדש
            customersList.Remove(oldCustomer);
            customersList.Add(item);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, customersList);
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום עדכון לקוח");
        }

        public void Delete(int id)
        {
            //LogManager.WriteStart(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                     MethodBase.GetCurrentMethod()!.Name, $"מחיקת מוצר {barcode}");

            string filePath = @"..\xml\customers.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            List<Customer> customersList;

            using (StreamReader reader = new StreamReader(filePath))
            {
                customersList = (List<Customer>)serializer.Deserialize(reader)!;
            }

            // חיפוש האיבר למחיקה
            Customer? customerToDelete = customersList.FirstOrDefault(p => p.id == id);

            if (customerToDelete == null)
            {
                //LogManager.WriteError($"ניסיון למחוק מוצר שלא קיים: {barcode}");
                throw new DalDoesNotExistException($"לא ניתן למחוק: לקוח זה {id} לא נמצא");
            }

            // מחיקה מהרשימה
            customersList.Remove(customerToDelete);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, customersList);
            }

            //LogManager.WriteEnd(MethodBase.GetCurrentMethod()!.DeclaringType!.FullName,
            //                   MethodBase.GetCurrentMethod()!.Name, "סיום מחיקת מוצר");
        }
    }
}
