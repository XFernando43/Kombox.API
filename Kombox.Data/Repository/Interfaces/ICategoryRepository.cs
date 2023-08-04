using Kombox.Models.Models;

namespace Kombox.DataAccess.Repository.Interfaces
{
    public partial interface ICategoryRepository: IRepository<Category>
    {
        void Update(int id, Category category);
        void Save();
    }
}
