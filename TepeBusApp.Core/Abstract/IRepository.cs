using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TepeBusApp.Core.Abstract
{
    public interface IRepository<T> where T :class,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll();
        void Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
