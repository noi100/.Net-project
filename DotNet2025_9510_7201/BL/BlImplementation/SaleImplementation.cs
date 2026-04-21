using BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class SaleImplementation : BlApi.ISale
    {
        // גישה לשכבת הנתונים דרך ה-Factory
        private DalApi.IDal _dal = DalApi.Factory.Get;

        /// שליפת כל המבצעים הקיימים והמרתם לישויות לוגיות (BO)
        public IEnumerable<BO.Sale> GetList()
        {
            //הפונקציה מחזירה רשימה של כל הסיילים בסוג BO
            return from doSale in _dal.Sale.ReadAll()
                   select doSale.ToBO();
        }

        /// שליפת מבצע ספציפי לפי 
        public BO.Sale GetProduct(int id)
        {
            try
            {
                //משתנה שיחזיק את המבצע 
                Do.Sale? doSale = _dal.Sale.Read(id);
                if (doSale == null)
                    throw new BO.BLDoesNotExistException($"מבצע עם מזהה {id} לא נמצא.");
                //החזרת המבצע לאחר ההמרה ל BO
                return doSale.ToBO();
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException($"שגיאה בשליפת מבצע {id}", ex);
            }
        }

        // הוספת מבצע חדש למערכת
        public void Add(BO.Sale sale)
        {
            // בדיקות תקינות
            if (sale.amountToGetSale <= 0)
                throw new BO.BLInvalidInputException("כמות נדרשת למבצע חייבת להיות גדולה מ-0.");
            if (sale.priceSale < 0)
                throw new BO.BLInvalidInputException("מחיר מבצע אינו יכול להיות שלילי.");
            if (sale.start > sale.end)
                throw new BO.BLInvalidInputException("תאריך התחלה לא יכול להיות מאוחר מתאריך סיום.");

            try
            {
                // יצירת אובייקט מסוג DO 
                Do.Sale doSale = new Do.Sale(
                    sale.id,
                    sale.amountToGetSale,
                    sale.priceSale,
                    sale.idProduct,
                    sale.IsClubMemberOnly,
                    sale.start,
                    sale.end
                );

               
                //יצירת סייל חדש מסוג DO עי האובייקט שיצרנו 
                _dal.Sale.Create(doSale);
            }
            catch (Exception ex)
            {
                throw new BO.BLAlreadyExistsException($"מבצע {sale.id} כבר קיים במערכת.", ex);
            }
        }

        /// עדכון מבצע קיים
        public void Update(BO.Sale sale)
        {
            try
            {
                //יצירת אובייקט מסוג DO מהמבצע מסוג BO  שהתקבל
                Do.Sale doSale = new Do.Sale(
                    sale.id,
                    sale.amountToGetSale,
                    sale.priceSale,
                    sale.idProduct,
                    sale.IsClubMemberOnly,
                    sale.start,
                    sale.end
                );

                //שליחת האובייקט החד שלעדכון בשכבת ה DAL
                _dal.Sale.Update(doSale);
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException($"לא ניתן לעדכן: מבצע {sale.id} לא נמצא.", ex);
            }
        }

        // מחיקת מבצע מהמערכת
        public void Delete(int id)
        {
            try
            {
                _dal.Sale.Delete(id);
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException($"מחיקה נכשלה: מבצע {id} לא נמצא.", ex);
            }
        }
    }
}