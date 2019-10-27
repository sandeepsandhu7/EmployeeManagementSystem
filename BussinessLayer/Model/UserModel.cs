using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Model
{
    public class UserModel//These are user class properties used for mapping data from usermodel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
