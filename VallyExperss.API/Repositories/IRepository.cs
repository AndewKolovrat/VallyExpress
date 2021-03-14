using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VallyExpress.Repositories
{
    public interface IBaseRepository<TDbModel> where TDbModel : Models.Based.EntityBase
    {
        public List<TDbModel> GetAll();
        public TDbModel Get(int id);
        public Task<TDbModel> Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(int id);
    }

}
