using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySqlDb
{
    public interface IRepositorySqlDbUse<T> where T:class,new()
    {
        /// <summary>
        /// 泛型显示
        /// </summary>
        /// <returns></returns>
        List<T> Query();

    }
}
