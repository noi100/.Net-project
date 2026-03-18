

using Do;

namespace Dal;

internal static class DataSource
{
    internal static List<Product?> Products = new List<Product?>();
    internal static List<Sale?> Sales = new List<Sale?>();
    internal static List<Customer> Customers = new List<Customer>();

    internal static class Config
    {
        internal const int MinBarcode= 100;
        internal const int MinIdSale = 0;

        private static int BarcodIndex = MinBarcode;
        private static int SaleIndex = MinIdSale;

        public static int barcode => BarcodIndex += 10;
        public static int idSale => SaleIndex +=1;

    }



}
