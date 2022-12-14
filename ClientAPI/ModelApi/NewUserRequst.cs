using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAPI.ModelApi
{
    public class NewUserRequst
    {
        public string userName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
