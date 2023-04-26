using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    internal class User : BaseEntity
    {
        public string Username {get;set;}

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
