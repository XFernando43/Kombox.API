using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kombox.Models.Models
{
    public partial class ShoppingCart
    {
        [Key]
        public int ShoppingId { get; set; }
        
    }
}
