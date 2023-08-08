using Kombox.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public interface IAuthorizationRepository: IRepository<Usuario>
    {
        public ValidarTokenResult ValidarToken(ClaimsIdentity identity);
    }
}
