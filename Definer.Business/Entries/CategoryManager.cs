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
    public class CategoryManager : ICategories
    {
        private readonly ICategories _repo;
        public CategoryManager()
        {
            _repo = new CategoryRepository();
        }

        public ProcessResult Add(Categories entity)
        {
            return _repo.Add(entity);
        }

        public ProcessResult Delete(int ID)
        {
            return _repo.Delete(ID);
        }

        public Categories Get(int ID)
        {
            return _repo.Get(ID);
        }

        public IEnumerable<Categories> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Categories> GetAllByIsActive(bool IsActive)
        {
            return _repo.GetAllByIsActive(IsActive);
        }

        public ProcessResult Update(Categories entity)
        {
            return _repo.Update(entity);
        }

        public ProcessResult UpdateIsActive(int ID, bool IsActive)
        {
            return _repo.UpdateIsActive(ID, IsActive);
        }
    }
}
