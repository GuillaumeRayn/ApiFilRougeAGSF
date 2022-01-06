using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilRouge.Interfaces
{
    interface IRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        T Save(T entity);
        List<T> Search(Expression<Func<T, bool>> searchMethode);
        T SearchOne(Expression<Func<T, bool>> searchMethode);
        bool Update();
    }
}
