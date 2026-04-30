using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {

            IProduct Product { get; }
            ISale Sale { get; }    
            ICustomer Customer { get; }
      /// <summary>
      /// 
      /// </summary>
            IOrder Order { get; }

    }
}
