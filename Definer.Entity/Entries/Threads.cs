using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Definer.Entity.Entries
{
    [Table("Threads")]
    public class Threads : BaseEntity
    {
        public DateTime Date { get; set; }
        public IEnumerable<Replies> Replies { get; set; }
    }
}
