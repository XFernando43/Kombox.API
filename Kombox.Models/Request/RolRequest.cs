using Kombox.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.Models.Request
{
    public class RolRequest
    {
        public string RolName { get; set; }
        public string Access { get; set; }
    }
}
