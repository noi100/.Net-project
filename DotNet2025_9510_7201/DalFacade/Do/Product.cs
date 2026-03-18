using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do
{
    public record Product(int barcode,string name,category category,double price,int amount)
    {
        public Product():this(0,"",category.BoardGames,0.0,0)
        {

        }
    }
    

}
