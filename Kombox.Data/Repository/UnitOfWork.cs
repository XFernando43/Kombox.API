using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.DataAccess.Repository
{
    public partial class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _db;
        public ICategoryRepository categoryRepository { get; set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            categoryRepository = new CategoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
