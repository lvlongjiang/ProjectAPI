using IRepositorySqlDb;
using IServices;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesUser : IServicesUser
    {
        private readonly IRepositorySqlDbUse<User> db;

        public ServicesUser(IRepositorySqlDbUse<User> db)
        {
            this.db = db;
        }
        /// <summary>
        /// User显示
        /// </summary>
        /// <returns></returns>
        public List<User> UserShow()
        {
            var ljq = (from a in db.Query()
                       select new User
                       {
                           UId=a.UId,
                           UAge=a.UAge,
                           UName=a.UName,
                           USex=a.USex,
                       }).ToList();
            return ljq;
        }
    }
}
