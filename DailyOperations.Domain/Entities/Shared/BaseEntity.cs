using System.ComponentModel;

namespace DailyOperations.Domain.Entities.Shared
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
