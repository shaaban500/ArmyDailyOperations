using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities
{
    public class OperationInstruction : BaseEntity
    {
        public string Instruction { get; set; }
    }
}
