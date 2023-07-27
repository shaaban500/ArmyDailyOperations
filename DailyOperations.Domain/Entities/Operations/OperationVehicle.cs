using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Operations
{
    public class OperationVehicle : BaseEntity
    {
        public long VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
        
        public long OperationId { get; set; }
        [ForeignKey("OperationId")]
        public Operation Operation { get; set; }

		public long? OperationTypeId { get; set; }
		[ForeignKey("OperationTypeId")]
		public OperationType? OperationType { get; set; }

		public long? OperationDescriptionId { get; set; }
		[ForeignKey("OperationDescriptionId")]
		public OperationDescription? OperationDescription { get; set; }

		public long? OperationInstructionId { get; set; }
		[ForeignKey("OperationInstructionId")]
		public OperationInstruction? OperationInstruction { get; set; }


		// driver data
		public long DriverType { get; set; }
        public long DriverId { get; set; }

        // related operation date
        public long RelatedOperationType { get; set; }
        public long RelatedOperationId { get; set; }


		public int? TimeFrom { get; set; }
		public int? TimeTo { get; set; }
	}
}
