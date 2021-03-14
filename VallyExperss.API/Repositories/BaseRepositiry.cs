using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VallyExpress.Repositories
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : Models.Based.EntityBase
    {
        private DataBase.ShopContext Context { get; set; }
        public BaseRepository(DataBase.ShopContext context)
        {
            Context = context;
        }

        public async Task<TDbModel> Create(TDbModel model)
        {
            await Context.Set<TDbModel>().AddAsync(model);
            Context.ChangeTracker.DetectChanges();
            await Context.SaveChangesAsync();
            return model;
        }

        public void Delete(int id)
        {
            var toDelete = Context.Set<TDbModel>().FirstOrDefault(m => m.id == id);
            Context.Set<TDbModel>().Remove(toDelete);
            Context.ChangeTracker.DetectChanges();
            Context.SaveChanges();
        }

        public List<TDbModel> GetAll()
        {
            return Context.Set<TDbModel>().ToList();
        }

        public TDbModel Update(TDbModel model)
        {
            var toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.id == model.id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.ChangeTracker.DetectChanges();
            Context.SaveChanges();
            return toUpdate;
        }

        public TDbModel Get(int id)
        {
            return Context.Set<TDbModel>().FirstOrDefault(m => m.id == id);
        }
    }

}
