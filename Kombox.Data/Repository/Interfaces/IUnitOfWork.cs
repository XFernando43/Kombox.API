using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository categoryRepository { get; set; }
        IProductRepository productRepository { get; set; }
        IUserRepository userRepository { get; set; }
        IAuthorizationRepository authorizationRepository { get; set; }
        IRolRepository rolRepository { get; set; }
        IShoppingCartRepository shoppingCartRepository { get; set; }
        void Save();
    }
}
