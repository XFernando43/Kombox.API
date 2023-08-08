using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Kombox.Models.Request;

namespace Kombox.DataAccess.Repository
{
    public class RolRepository : Repository<RolUser>, IRolRepository
    {
        public ApplicationDbContext _db { get; set; }
        public RolRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(int id, RolRequest request)
        {
            try
            {
                var rolFromDb = _db.RolUsers.FirstOrDefault(u => u.RolId == id);
                if (rolFromDb == null)
                {
                    throw new InvalidOperationException("Not founded");
                }
                else
                {
                    rolFromDb.RolName = request.RolName ?? rolFromDb.RolName;
                    rolFromDb.Access = request.Access ?? rolFromDb.Access;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException("An Error Ocurred");
            }
        }
    }
}
