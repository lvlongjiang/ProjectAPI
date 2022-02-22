using EFContext;
using IRepositorySqlDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlDb
{ 

    public class RepositorySqlDbUse<T> : IRepositorySqlDbUse<T> where T : class, new()
    {
        private readonly MyDbContext db;
        public RepositorySqlDbUse(MyDbContext db)
        {
            this.db = db;
        }
        public List<T> Query()
        {
            return db.Set<T>().AsQueryable().ToList();
        }
    }


}
