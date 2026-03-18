using Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int barcode { get; set; }
        public string name { get; set; }
        public category category { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        public List<BO.SaleInProduct>? listSale { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
