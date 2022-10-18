using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace UnionApp
{
    internal class User
    {
        public string login { get; set; }
        public string pass { get; set; }

        public User(string u, string p )
        {
            login = u;
            pass = p;
        }   
    }
}
