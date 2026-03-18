using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool ifFavorite { get; set; }
        public List<BO.ProductInOrder>? Items { get; set; }
        public double endPrice { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
