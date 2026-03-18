using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        public List<BO.SaleInProduct> listOperation { get; set; }
        public double endPrice { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
