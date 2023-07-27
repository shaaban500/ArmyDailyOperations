using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Operations
{
    public class Operation : BaseEntity
    {
        public long GeneralDepartmentId { get; set; }
        [ForeignKey("GeneralDepartmentId")]
        public GeneralDepartment GeneralDepartment { get; set; }

        public long InnerDepartmentId { get; set; }
        [ForeignKey("InnerDepartmentId")]
        public InnerDepartment InnerDepartment { get; set; }

        public long DailyOperationId { get; set; }
        [ForeignKey("DailyOperationId")]
        public DailyOperation DailyOperation { get; set; }

        public long ShiftTypeId { get; set; }
        [ForeignKey("ShiftTypeId")]
        public ShiftType ShiftType { get; set; }

        public int ShiftTimeFrom { get; set; }
        public int ShiftTimeTo { get; set; }

        public long SectorId { get; set; }
        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }

        public long SectorPlaceFromId { get; set; }
        [ForeignKey("SectorPlaceFromId")]
        public SectorPlace SectorPlaceFrom { get; set; }

        public long SectorPlaceToId { get; set; }
        [ForeignKey("SectorPlaceToId")]
        public SectorPlace SectorPlaceTo { get; set; }

        public DateTime Date { get; set; }
    }
}
