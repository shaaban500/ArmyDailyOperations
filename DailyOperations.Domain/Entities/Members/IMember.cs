using System.ComponentModel.DataAnnotations.Schema;

namespace DailyOperations.Domain.Entities.Members
{
    public interface IMember
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }

        public long? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public long? PowerTypeId { get; set; }
        [ForeignKey("PowerTypeId")]
        public PowerType? PowerType { get; set; }
    }
}
