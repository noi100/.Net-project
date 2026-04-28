using BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class ProductImplementation : BlApi.IProduct
    {
        // גישה לשכבת הנתונים
        private readonly DalApi.IDal _dal = DalApi.Factory.Get;

        //יצירת רשימה של מוצרים מסוג BO, ע"י שיממוש בפונקציה TOBO
        public IEnumerable<BO.Product> GetList()
        {
            return from doProd in _dal.Product.ReadAll()
                   select doProd.ToBO();
        }

        /// קבלת מוצר ספציפי לפי הברקוד שלו
        public BO.Product GetProduct(int id)
        {
            //יצירת מופע
            Do.Product? doProd;
            try
            {
                doProd = _dal.Product.Read(id);
                if (doProd == null)
                    throw new BO.BLDoesNotExistException($"מוצר עם ברקוד {id} לא נמצא.");
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException("שגיאה בשליפת מוצר מה-DAL", ex);
            }
            //הפיכת המוצר מסוג DO ל BO
            var boProd = doProd.ToBO();

            // טעינת המבצעים עבור המוצר (לפי לוגיקה בסיסית - למשל ללקוח רגיל)
            //? FALSE
            boProd.listSale = GetSalesForProduct(id, false);

            return boProd;
        }

        /// הוספת מוצר חדש למערכת
        public void Add(BO.Product product)
        {
            // בדיקות תקינות בסיסיות (שלב 8)
            if (product == null)
                throw new BO.BLInvalidInputException("לא התקבלו נתוני מוצר.");
            if (product.barcode <= 0)
                throw new BO.BLInvalidInputException("ברקוד חייב להיות מספר חיובי.");
            if (string.IsNullOrWhiteSpace(product.name))
                throw new BO.BLInvalidInputException("שם מוצר אינו יכול להיות ריק.");
            if (product.price < 0)
                throw new BO.BLInvalidInputException("מחיר אינו יכול להיות שלילי.");

            try
            {
                // יצירת אובייקט חדש מסוג DO    
                Do.Product doProd = new Do.Product(
                    product.barcode,
                    product.name,
                    (Do.category)product.category,
                    product.price,
                    product.amount
                );

                // יצירת האובייקט והוספתו ל DAL 
                _dal.Product.Create(doProd);
            }
            catch (Exception ex)
            {
                throw new BO.BLAlreadyExistsException($"מוצר עם ברקוד {product.barcode} כבר קיים במערכת.", ex);
            }
        }

        /// עדכון נתוני מוצר קיים
        public void Update(BO.Product product)
        {
            try
            {
                //,DO עם הנתונים שהתקבלו בפונקציה יצירת אובייקט חדש מסוג 
                Do.Product doProd = new Do.Product(
                    product.barcode,
                    product.name,
                    (Do.category)product.category,
                    product.price,
                    product.amount
                );
                //עדכון המוצרים
                _dal.Product.Update(doProd);
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException($"לא ניתן לעדכן: מוצר {product.barcode} לא נמצא.", ex);
            }
        }

        /// מחיקת מוצר
        public void Delete(int id)
        {
            try
            {
                // חיפוש המוצר ושימוש בפונקציית המחיקה מ DAL 
                _dal.Product.Delete(id);
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException($"מחיקה נכשלה: מוצר {id} לא נמצא.", ex);
            }
        }

        ///  עדכון רשימת המבצעים למוצר
        public IEnumerable<BO.SaleInProduct> allSales(int productId, bool ifFavorite)
        {
            if (_dal.Product.Read(productId) == null)
                throw new BO.BLDoesNotExistException($"לא ניתן לשלוף מבצעים: מוצר {productId} לא קיים.");
            //שליחת הפרמטרים של המוצר לפונקציה שמחזירה רשימה של המבצעים של המוצר
           return  GetSalesForProduct(productId, ifFavorite);
     
        }

        /// פונקציית עזר פנימית לשליפת מבצעים רלוונטיים מה-DAL למוצר
        private List<BO.SaleInProduct> GetSalesForProduct(int productId, bool ifFavorite)
        {
            return _dal.Sale.ReadAll(s => s.idProduct == productId)
                .Where(s => DateTime.Now >= s.start && DateTime.Now <= s.end) // רק מה שבתוקף
                .Where(s => !s.IsClubMemberOnly || ifFavorite) // בדיקת מועדון
                .Select(s => new BO.SaleInProduct
                {
                    idSale = s.id,
                    amountSale = s.amountToGetSale,
                    priceSale = s.priceSale,
                    isFor = s.IsClubMemberOnly
                }).ToList();//יצירת רשימה עם המבצעים הרלוונטים למוצר
        }
    }
}