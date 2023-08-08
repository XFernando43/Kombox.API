using Kombox.Models.Models;
using Kombox.Models.Request;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public interface IRolRepository : IRepository<RolUser>
    {
        void Update(int id, RolRequest user);
        void Save();
    }
}
