using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Customer
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? adress { get; set; }
        public int? phoneNumber { get; set; }

        public override string ToString() => this.ToStringProperty();
    }
}