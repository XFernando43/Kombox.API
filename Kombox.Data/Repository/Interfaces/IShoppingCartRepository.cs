using Kombox.Models.Models;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public partial interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(int id, ShoppingCart cart);
        void Save();
    }
}
