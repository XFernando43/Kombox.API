using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kombox.Models.Models
{
    public partial class ShoppingCart
    {
        [Key]
        public int ShoppingId { get; set; }
        /// foreign key
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        //lista
        [NotMapped]
        public List<Product>? Products { get; set; }

        /// foreign key
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        [ValidateNever]
        public Usuario Usuario { get; set; }

        public int Count { get; set; }
    }
}
