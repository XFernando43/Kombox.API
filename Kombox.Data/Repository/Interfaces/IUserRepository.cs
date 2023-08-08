using Kombox.Models.Models;
using Kombox.Models.Request;
using static Kombox.Models.Models.Jwt;
using System.Security.Claims;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public partial interface IUserRepository : IRepository<Usuario>
    {
        void Update(int id, UserRequest user);
        void Save();
        public ValidarTokenResult ValidarToken(ClaimsIdentity identity);

    }
}
