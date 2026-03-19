using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXml
{
    public class DalXml:IDal
    {
        public IProduct Product { get; } = new ProductImplementation();

        public ICustomer Customer { get; } = new CustomerImplementation();

        public ISale Sale { get; } = new SaleImplementation();
    }
}
