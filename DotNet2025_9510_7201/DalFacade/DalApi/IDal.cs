using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    //*
    public interface IDal
    {
        ISale Sale { get; }
        IProduct Product { get; }
        ICustomer Customer { get; }
    }
}
