using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definer.Entity.Users
{
    [Table("Users")]
    public class Users : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool EULA { get; set; }
    }
}
