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
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
