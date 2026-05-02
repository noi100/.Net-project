using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalXml:IDal
    {
        private DalXml() { }

        private static readonly DalXml instance = new DalXml();
        public static DalXml Instance { get { return instance; } }
        public IProduct Product { get; } = new ProductImplementation();

        public ICustomer Customer { get; } = new CustomerImplementation();

        public ISale Sale { get; } = new SaleImplementation();
    }
}
