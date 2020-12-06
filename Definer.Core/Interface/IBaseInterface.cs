using Definer.Entity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definer.Core.Interface
{
    public interface IBaseInterface<T> where T : class
    {
        ProcessResult Add(T entity);
        ProcessResult Update(T entity);
        ProcessResult UpdateIsActive(int ID, bool IsActive);
        ProcessResult Delete(int ID);
        T Get(int ID);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllByIsActive(bool IsActive);
    }
}
