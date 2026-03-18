using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    //*
    public interface ICrud<T>
    {
        int Create(T item);
        T? Read(Func<T,bool>?filter);
        T? Read(int id);
        List<T> ReadAll(Func<T,bool>?filter=null);
        void Update(T item);
        void Delete(int id);

    }
}
