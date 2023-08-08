using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.Models.Request
{
    public class UserRequest
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public int RolId { get; set; }
    }
}
