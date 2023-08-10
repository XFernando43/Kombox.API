using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kombox.Models.Models
{
    public partial class ShoppingCart
    {
        [Key]
        public int? ShoppingCartId { get; set; }
        
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        [ValidateNever]
        public Usuario Usuario { get; set; } 

        public double TotalPrice { get; set; }

    }
}
