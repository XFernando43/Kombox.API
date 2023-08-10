using Kombox.Models.Models;
using Kombox.Models.Request;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public interface IItemCartRepository : IRepository<ItemCart>
    {
        void Update(int id, ItemCartRequest itemCart);
        void Save();    
    }
}
