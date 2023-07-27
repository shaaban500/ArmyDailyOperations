using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Operations
{
    public class InnerDepartment : BaseEntity
    {
        public string Department { get; set; }
    }
}
