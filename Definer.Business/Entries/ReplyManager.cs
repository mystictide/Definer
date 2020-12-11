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
    public class ReplyManager : IReplies
    {
        private readonly IReplies _repo;
        public ReplyManager()
        {
            _repo = new ReplyRepository();
        }

        public ProcessResult Add(Replies entity)
        {
            return _repo.Add(entity);
        }

        public ProcessResult Delete(int ID)
        {
            return _repo.Delete(ID);
        }

        public Replies Get(int ID)
        {
            return _repo.Get(ID);
        }

        public IEnumerable<Replies> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Replies> GetAllByIsActive(bool IsActive)
        {
            return _repo.GetAllByIsActive(IsActive);
        }

        public ProcessResult Update(Replies entity)
        {
            return _repo.Update(entity);
        }

        public ProcessResult UpdateIsActive(int ID, bool IsActive)
        {
            return _repo.UpdateIsActive(ID, IsActive);
        }
    }
}
