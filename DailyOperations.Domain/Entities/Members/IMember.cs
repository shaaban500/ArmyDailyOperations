using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.Entities.Members
{
    public interface IMember
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }

        public long? GeneralDepartmentId { get; set; }
        [ForeignKey("GeneralDepartmentId")]
        public GeneralDepartment? GeneralDepartment { get; set; }

        public long? InnerDepartmentId { get; set; }
        [ForeignKey("InnerDepartmentId")]
        public InnerDepartment? InnerDepartment { get; set; }

        public long? PowerTypeId { get; set; }
        [ForeignKey("PowerTypeId")]
        public PowerType? PowerType { get; set; }

    }
}
