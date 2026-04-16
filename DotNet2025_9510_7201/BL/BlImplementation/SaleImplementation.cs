using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class SaleImplementation:BlApi.ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
    }
}
