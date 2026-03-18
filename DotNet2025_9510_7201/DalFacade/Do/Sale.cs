using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do
{
   
    public record Sale(int id,int amountToGetSale,int priceSale, int idProduct, bool IsClubMemberOnly,DateTime start,DateTime end)
    {
       
        public Sale():this(0,0,0,0,false,DateTime.Now,DateTime.Now)
        {
        
        }
    }
 
}
