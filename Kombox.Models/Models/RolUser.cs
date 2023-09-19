using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kombox.Models.Models
{
    public class RolUser
    {
        [Key]
        public int? RolId { get; set; }
        [Required]
        public string RolName { get; set; }
        public string Access { get; set; }

        [NotMapped]
        List<Usuario>? usuarios { get; set; }
    }
}

//jijijijisddadasd
