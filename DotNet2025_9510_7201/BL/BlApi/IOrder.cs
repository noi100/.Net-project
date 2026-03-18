using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IOrder
    {
        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int id, int amount);

        public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder);

        public void CalcTotalPrice(BO.Order productOrder);

        public void DoOrder(BO.Order order);

        public void SearchSaleForProduct(BO.ProductInOrder productInOrder,bool ifFavorite);

    }
}
