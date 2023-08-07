using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.Models.Models
{
    public class Usuario
    {
        public string IdUser { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string Rol { get; set; }

        public static List<Usuario> DB()
        {
            var list = new List<Usuario>()
            {
                new Usuario()
                {
                    IdUser = "1",
                    usuario = "Chess",
                    password = "Mierdamierda",
                    Rol = "Admin",
                },
                new Usuario()
                {
                    IdUser = "2",
                    usuario = "Glam",
                    password = "Mierdamierda",
                    Rol = "Employee",
                },
                new Usuario()
                {
                    IdUser = "3",
                    usuario = "Fercho",
                    password = "Mierdamierda",
                    Rol = "Asesor"
                }
            };

            return list;
        }
    }
}
