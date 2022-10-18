using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionApp
{
    internal class RegisterUser
    {
        public int user_id { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string email { get; set; }       
        public int current_room_id { get; set; } 

        public RegisterUser(string u, string p, string e)
        {
            user_id = 0;
            login = u;
            pass = p;
            email = e;
            current_room_id = 0;
        }
    }
}
