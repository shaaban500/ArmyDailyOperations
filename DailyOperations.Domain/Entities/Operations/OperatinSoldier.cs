using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Operations
{
    public class OperatinSoldier : BaseEntity
    {
        public long SoldierId { get; set; }
        [ForeignKey("SoldierId")]
        public Soldier Soldier { get; set; }


        public long OperationId { get; set; }
        [ForeignKey("OperationId")]
        public Operation Operation { get; set; }
        
        public long OperationTypeId { get; set; }
        [ForeignKey("OperationTypeId")]
        public OperationType OperationType { get; set; }
        
        public long OperationDescriptionId { get; set; }
        [ForeignKey("OperationDescriptionId")]
        public OperationDescription OperationDescription { get; set; }
    }
}
