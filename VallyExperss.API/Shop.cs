using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using VallyExpress.DataBase;
using VallyExpress.Models;

namespace VallyExpress
{

    public interface IShop
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        IEnumerable<Product> GetProducts();
        Task<Product> GetProductAsync(int id);
        Product GetProduct(int id);


        IEnumerable<Reserv> GetReservs();
        Task<IEnumerable<Reserv>> GetReservsAsync();
        Reserv GetReservs(int id);
        Task<Reserv> GetReservsAsync(int id);
        Reserv Reserve(int UserID, int ProductID, int Count);
        Task<Reserv> ReserveAsync(int UserID, int ProductID, int Count);


        IEnumerable<User> GetUsers();
        Task<IEnumerable<User>> GetUsersAsync();
        User GetUser(int id);
        Task<User> GetUserAsync(int id);

    }

    public class Shop : IShop
    {
        object lockObj = new object();
        static string connetionsString;
        ShopContext db;

        static public void SetConnectionsString(string con)
        {
            connetionsString = con;
        }

        public Shop()
        {
            if ( string.IsNullOrEmpty(connetionsString))
            {
                throw new Exception("Can't create Shop instance withoute called SetConnectionsString(str)!");
            }
            db = new ShopContext(connetionsString);
            // отключаем для более-быстрой работы
            db.ChangeTracker.AutoDetectChangesEnabled = false;

        }

        public void initSample()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            // Create
            db.Products.Add(Product.Sample());
            db.Users.Add(User.Sample());

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();
        }

        #region Reserve
        public Reserv GetReservs(int id)
        {
            return db.Reserved.Find(id);
        }
        public async Task<Reserv> GetReservsAsync(int id)
        {
            return await db.Reserved.FindAsync(id);
        }
        public IEnumerable<Reserv> GetReservs()
        {
            return db.Reserved;
        }
        public async Task<IEnumerable<Reserv>> GetReservsAsync()
        {
            return await db.Reserved.ToListAsync();
        }
        public Reserv Reserve(int UserID, int ProductID, int count)
        {
            User user = GetUser(UserID);
            Product prod = GetProduct(ProductID);

            if (!prod.TryReserv(count)) return null;

            Reserv r = new Reserv
            {
                ProductID = prod.id,
                UserID = user.id,
                Count = count
            };

            prod.Reserveds.Add(r.id);
            db.Reserved.Add(r);
            user.ReservedsID.Add(r.id);

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();

            return r;
        }
        public async Task<Reserv> ReserveAsync(int UserID, int ProductID, int count)
        {
            User user = GetUser(UserID);
            Product prod = GetProduct(ProductID);
            
            if (!prod.TryReserv(count)) return null;

            Reserv r = new Reserv
            {
                ProductID = prod.id,
                UserID = user.id,
                Count = count
            };

            prod.Reserveds.Add(r.id);
            user.ReservedsID.Add(r.id);

            await db.Reserved.AddAsync(r);

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();
            return r;
        }
        #endregion

        #region Product
        public IEnumerable<Product> GetProducts()
        {
            return  db.Products;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await db.Products.ToListAsync();
        }
        public Product GetProduct(int id)
        {
            Product prod = db.Products.Find(id);
            if (prod == null)
            {
                throw new Exception($"Cant't get Product with id={id}");
            }
            return prod;
        }
        public async Task<Product> GetProductAsync(int id)
        {
            Product prod = await db.Products.FirstOrDefaultAsync(p => p.id == id);
            if (prod == null)
            {
                throw new Exception($"Cant't get Product with id={id}");
            }
            return prod;
        }
        #endregion

        #region User
        public IEnumerable<User> GetUsers()
        {
            return db.Users;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await db.Users.ToListAsync();
        }
        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                throw new Exception($"Cant't get User with id={id}");
            }
            return user;
        }
        public async Task<User> GetUserAsync(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(p => p.id == id);
            if (user == null)
            {
                throw new Exception($"Cant't get User with id={id}");
            }
            return user;
        }
        #endregion
    
    }

}
