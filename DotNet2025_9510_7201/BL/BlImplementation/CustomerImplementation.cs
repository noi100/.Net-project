using BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class CustomerImplementation : BlApi.ICustomer
    {
        // גישה לשכבת הנתונים דרך ה-Factory
        //הוספתי readonly
        private readonly DalApi.IDal _dal = DalApi.Factory.Get;

        //יצירת רשימה של הלקוחות מסוג BO, ע"י שיממוש בפונקציה TOBO 
        public IEnumerable<BO.Customer> GetList()
        {
            return from doCust in _dal.Customer.ReadAll()
                   select doCust.ToBO();
        }

        /// מחזיר לקוח ספציפי לפי תעודת זהות
        public BO.Customer Get(int id)
        {
            if (id <= 0)
                throw new BO.BLInvalidInputException("תעודת זהות חייבת להיות מספר חיובי.");

            Do.Customer? doCust;
            try
            {
                doCust = _dal.Customer.Read(id);
                if (doCust == null)
                    throw new BO.BLDoesNotExistException($"לקוח עם תעודת זהות {id} לא נמצא.");
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException("שגיאה בשליפת נתוני לקוח", ex);
            }

            return doCust.ToBO();
        }

        /// <summary>
        /// הוספת לקוח חדש למערכת
        /// </summary>
        public void Add(BO.Customer customer)
        {
            // בדיקות תקינות קלט (שלב 8)
            if (customer.id <= 0)
                throw new BO.BLInvalidInputException("תעודת זהות אינה תקינה.");
            if (string.IsNullOrWhiteSpace(customer.name))
                throw new BO.BLInvalidInputException("שם לקוח חובה.");

            try
            {
                // יצירת DO מה-BO (ה-record ב-Do משתמש ב-adress עם s אחת לפי הקובץ שלך)
                Do.Customer doCust = new Do.Customer(
                    customer.id,
                    customer.name!,
                    customer.address ?? "",
                    customer.phoneNumber ?? 0
                );

                _dal.Customer.Create(doCust);
            }
            catch (Exception ex)
            {
                throw new BO.BLAlreadyExistsException($"לקוח עם תעודת זהות {customer.id} כבר קיים.", ex);
            }
        }

        /// עדכון נתוני לקוח קיים
        public void Update(BO.Customer customer)
        {
            try
            {
                // (BO יצירת אוביקט מסוג דו על פי הנתונים שהתקבלו בפונקציה(אובייקט מסוג
                Do.Customer doCust = new Do.Customer(
                    customer.id,
                    customer.name!,
                    customer.address ?? "",
                    customer.phoneNumber ?? 0
                );

                //עדכון הלקוח באמצעות הפרטים מהאובייקט החדש
                _dal.Customer.Update(doCust);
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException($"עדכון נכשל: לקוח {customer.id} לא נמצא.", ex);
            }
        }

        /// מחיקת לקוח מהמערכת
        public void Delete(int id)
        {
            try
            {
                _dal.Customer.Delete(id);
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException($"מחיקה נכשלה: לקוח {id} לא נמצא.", ex);
            }
        }


        /// בדיקה האם לקוח קיים במערכת
        public bool ExistingCustomer(int id)
        {
            return _dal.Customer.Read(id) != null;
        }
    }
}