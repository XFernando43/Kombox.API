using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.DataAccess.Repository
{
    public class AuthorizationRepository : Repository<Usuario>, IAuthorizationRepository
    {
        private ApplicationDbContext _db;
        public AuthorizationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public ValidarTokenResult ValidarToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new ValidarTokenResult
                    {
                        Success = false,
                        Message = "Verifica si estás enviando un token válido",
                        Result = null
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
                Usuario usuario = _db.Usuarios.FirstOrDefault(x => x.IdUser.ToString() == id);

                return new ValidarTokenResult
                {
                    Success = true,
                    Message = "exito",
                    Result = usuario
                };
            }
            catch (Exception ex)
            {
                return new ValidarTokenResult
                {
                    Success = false,
                    Message = "Catch: " + ex.Message,
                    Result = null
                };
            }
        }
    }
}

