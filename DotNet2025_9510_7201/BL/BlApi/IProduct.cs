using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IProduct
    {
        public IEnumerable<Product> GetList();
        public Product GetProduct(int id);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(int id);
        public void allSales(int productId, bool ifFavorite);
    }
}