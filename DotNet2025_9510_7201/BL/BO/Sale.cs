using Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Sale
    {
        public int id { get; set; }
        public int amountToGetSale { get; set; }
        public int priceSale { get; set; }
        public int idProduct { get; set; }
        public bool IsClubMemberOnly { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
