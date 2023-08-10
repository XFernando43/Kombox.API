using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Kombox.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.DataAccess.Repository
{
    public class ItemCartRepository : Repository<ItemCart>, IItemCartRepository
    {
        private readonly ApplicationDbContext _db;
        public ItemCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(int id, ItemCartRequest itemCart)
        {
            var obj = _db.ItemCarts.FirstOrDefault(x => x.ItemCartId == id);

            if (obj != null)
            {
                throw new NotImplementedException();
            }

            else
            {
                obj.ProductId = itemCart.ProductId;
                obj.count = itemCart.count;
                _db.SaveChanges();
            }

        }
    }
}
