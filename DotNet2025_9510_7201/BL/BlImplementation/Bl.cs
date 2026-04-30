using BlApi;
using System;

namespace BlImplementation
{

    internal class Bl : IBl
    {
        // מימוש התכונות כך שיחזירו מופעים חדשים של המחלקות המממשות

        // כאן אנחנו מחזירים את המימוש של הלקוח שעבדנו עליו קודם
        public ICustomer Customer => new CustomerImplementation();

        // כאן את צריכה להחזיר את המימושים של המוצר והמבצע 
        public IProduct Product => new ProductImplementation();

        public ISale Sale => new SaleImplementation();

        public IOrder Order => new OrderImplementation();
    }
}