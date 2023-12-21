using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Employee :IdentityUser<Guid>
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime IdentitDated { get; set; }
        public DateTime Birthday { get; set; }
        public string PlaceIssued { get; set; }
        public string Address { get; set; }
        public string TemporaryAddress { get; set; }
        public bool IsOff { get; set; }
        public DateTime OffDate { get; set; }
        public DateTime OnDate { get; set; }
    }
}
