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
    public partial class UserRepository : Repository<Usuario>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(int id, UserRequest user)
        {
            try
            {

                var userFromDb = _db.Usuarios.FirstOrDefault(u => u.IdUser == id);
                if (userFromDb == null)
                {
                    throw new ArgumentException("user not found with the provided ID.");
                }

                // Actualizar solo los campos que se hayan enviado en el modelo
                userFromDb.usuario = user.usuario ?? userFromDb.usuario;
                userFromDb.password = user.password ?? userFromDb.password;
                userFromDb.Rol = user.Rol;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Manejar excepciones aquí si es necesario
                throw new Exception("An error occurred while updating the product.", ex);
            }
        }
    }
}
