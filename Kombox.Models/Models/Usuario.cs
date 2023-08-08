using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        //public string Rol { get; set; }

        public int IdRol { get; set; }
        [ForeignKey("IdRol")]
        public RolUser RolUser { get; set; }

    }
}
