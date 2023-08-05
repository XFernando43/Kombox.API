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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db { get; set; }
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(int id, ProductRequest product)
        {
            try
            {

                var productFromDb = _db.Products.FirstOrDefault(u => u.ProductId == id);
                if (productFromDb == null)
                {
                    throw new ArgumentException("Product not found with the provided ID.");
                }

                // Actualizar solo los campos que se hayan enviado en el modelo
                productFromDb.Name = product.Name ?? productFromDb.Name;
                productFromDb.Description = product.Description ?? productFromDb.Description;
                productFromDb.Price = product.Price;
                productFromDb.CategoryId = product.CategoryId;

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
