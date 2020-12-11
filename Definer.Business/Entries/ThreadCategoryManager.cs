using Definer.Core.Interface.Entries;
using Definer.Core.Repository.Entries;
using Definer.Entity.Entries;
using Definer.Entity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definer.Business.Entries
{
    public class ThreadCategoryManager : IThread_Categories
    {
        private readonly IThread_Categories _repo;
        public ThreadCategoryManager()
        {
            _repo = new ThreadCategoryRepository();
        }

        public ProcessResult Add(Thread_Categories entity)
        {
            return _repo.Add(entity);
        }

        public ProcessResult Delete(int ID)
        {
            return _repo.Delete(ID);
        }

        public Thread_Categories Get(int ID)
        {
            return _repo.Get(ID);
        }

        public IEnumerable<Thread_Categories> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Thread_Categories> GetAllByIsActive(bool IsActive)
        {
            return _repo.GetAllByIsActive(IsActive);
        }

        public ProcessResult Update(Thread_Categories entity)
        {
            return _repo.Update(entity);
        }

        public ProcessResult UpdateIsActive(int ID, bool IsActive)
        {
            return _repo.UpdateIsActive(ID, IsActive);
        }
    }
}
