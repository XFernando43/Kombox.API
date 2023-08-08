using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.Models.Models
{
    public class ValidarTokenResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Usuario Result { get; set; }
    }
}
