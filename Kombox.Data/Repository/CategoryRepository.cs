using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;

namespace Kombox.DataAccess.Repository
{
    public partial class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db): base(   db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
