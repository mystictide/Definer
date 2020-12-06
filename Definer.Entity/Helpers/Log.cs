using Dapper.Contrib.Extensions;
using System;

namespace Definer.Entity
{
    [Table("Logs")]
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public int Line { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
