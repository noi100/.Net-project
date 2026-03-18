using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    public interface ICustomer
    {
        public IEnumerable<Customer> GetList();
        public Customer Get(int id);
        public void Add(Customer customer);
        public void Update(Customer customer);
        public void Delete(int id);
        public bool ExistingCustomer(int id);
    }
}