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
        void Save();
    }
}
