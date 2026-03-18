using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BlApi
{
    public interface ISale
    {
        public IEnumerable<Sale> GetList();
        public Sale GetProduct(int id);
        public void Add(Sale sale);
        public void Update(Sale sale);
        public void Delete(int id);
    }
}
