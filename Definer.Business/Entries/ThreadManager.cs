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
    public class ThreadManager : IThreads
    {
        private readonly IThreads _repo;
        public ThreadManager()
        {
            _repo = new ThreadRepository();
        }

        public ProcessResult Add(Threads entity)
        {
            return _repo.Add(entity);
        }

        public ProcessResult Delete(int ID)
        {
            return _repo.Delete(ID);
        }

        public Threads Get(int ID)
        {
            return _repo.Get(ID);
        }

        public IEnumerable<Threads> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Threads> GetAllByIsActive(bool IsActive)
        {
            return _repo.GetAllByIsActive(IsActive);
        }

        public ProcessResult Update(Threads entity)
        {
            return _repo.Update(entity);
        }

        public ProcessResult UpdateIsActive(int ID, bool IsActive)
        {
            return _repo.UpdateIsActive(ID, IsActive);
        }
    }
}
