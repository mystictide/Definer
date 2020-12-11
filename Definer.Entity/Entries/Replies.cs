using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definer.Entity.Entries
{
    [Table("Replies")]
    public class Replies
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public bool IsActive { get; set; }
    }
}
