using System.ComponentModel.DataAnnotations;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Members
{
    public class AssistantsMilitaryDegree : BaseEntity
    {
        [MaxLength(50)]
        public string Degree { get; set; }
        public int DisplayOrder { get; set; }
    }
}
