﻿using Kombox.DataAccess.Data;
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
        public IProductRepository productRepository { get; set; }
        public IUserRepository userRepository { get; set; }
        public IAuthorizationRepository authorizationRepository { get; set; }
        public IRolRepository rolRepository { get; set; }
        public IShoppingCartRepository shoppingCartRepository { get; set; }
        public IItemCartRepository itemCartRepository { get; set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            categoryRepository = new CategoryRepository(_db);
            productRepository = new ProductRepository(_db);
            userRepository = new UserRepository(_db);
            authorizationRepository = new AuthorizationRepository(_db);
            rolRepository = new RolRepository(_db);
            itemCartRepository = new ItemCartRepository(_db);
            shoppingCartRepository = new ShoppingCartRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
