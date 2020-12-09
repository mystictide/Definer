using Definer.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definer.Core.Interface
{
    public interface IUsers : IBaseInterface<Users>
    {
        bool CheckMail(string Email);
        bool CheckUsername(string Name);

        Users Login(string Email, string Password);
    }
}
