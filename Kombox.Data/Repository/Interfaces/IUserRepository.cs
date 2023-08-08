using Kombox.Models.Models;
using Kombox.Models.Request;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public partial interface IUserRepository : IRepository<Usuario>
    {
        void Update(int id, UserRequest user);
        void Save();
    }
}
