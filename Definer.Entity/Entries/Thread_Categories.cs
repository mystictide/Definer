using Dapper.Contrib.Extensions;

namespace Definer.Entity.Entries
{
    [Table("thread_categories")]
    public class Thread_Categories
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int ThreadID { get; set; }
    }
}
