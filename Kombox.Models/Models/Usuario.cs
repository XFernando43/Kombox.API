using System.ComponentModel.DataAnnotations;

namespace Kombox.Models.Models
{
    public class Usuario
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string password { get; set; }
        public string Rol { get; set; }
    }
}
