using Dapper.Contrib.Extensions;

namespace Definer.Entity
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}