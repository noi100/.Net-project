using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do
{
    public record Customer(int id, string name, string adress, int phoneNumber)
    {
        public Customer() : this(0, "", "", 0)
        {

        }
    }
}
