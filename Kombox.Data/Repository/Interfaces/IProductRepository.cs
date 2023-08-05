using Kombox.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        void Update(int id, Product product);
        void Save();
    }
}
