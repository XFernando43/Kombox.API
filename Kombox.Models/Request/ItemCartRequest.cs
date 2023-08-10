using Kombox.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.Models.Request
{
    public class ItemCartRequest
    {
        public int ProductId { get; set; }
        public int count { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
