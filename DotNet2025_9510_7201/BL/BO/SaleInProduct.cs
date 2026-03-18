using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int idSale { get; set; }
        public int amountSale { get; set; }
        public double priceSale { get; set; }
        public bool isFor { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
