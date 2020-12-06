using Definer.Core.Interface;
using Definer.Core.Repository.Users;
using Definer.Entity.Helpers;
using System.Collections.Generic;

namespace Definer.Business.Users
{
    public class UserManager : IUsers
    {
        private readonly IUsers _repo;
        public UserManager()
        {
            _repo = new UsersRepository();
        }

        public ProcessResult Add(Entity.Users.Users entity)
        {
            return _repo.Add(entity);
        }

        public ProcessResult Delete(int ID)
        {
            return _repo.Delete(ID);
        }

        public Entity.Users.Users Get(int ID)
        {
            return _repo.Get(ID);
        }

        public IEnumerable<Entity.Users.Users> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Entity.Users.Users> GetAllByIsActive(bool IsActive)
        {
            return _repo.GetAllByIsActive(IsActive);
        }

        public ProcessResult Update(Entity.Users.Users entity)
        {
            return _repo.Update(entity);
        }

        public ProcessResult UpdateIsActive(int ID, bool IsActive)
        {
            return _repo.UpdateIsActive(ID, IsActive);
        }
    }
}
