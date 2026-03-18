using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Dal
{
    internal sealed class DalList:IDal
    {
        private DalList() { }
        static readonly DalList instance =new DalList();
        public static DalList Instance
        { get { return instance; } }

        public IProduct Product => new ProductImplementation();
        public ICustomer Customer => new CustomerImplementation();
        public ISale Sale => new SaleImplementation();

   }
}
