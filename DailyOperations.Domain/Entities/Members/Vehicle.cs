using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Members
{
    public class Vehicle : BaseEntity
    {
        [MaxLength(5)]
        public string? VehicleNumbers { get; set; }
        [MaxLength(5)]
        public string? VehicleLetters { get; set; }

        public long VehicleMarkId { get; set; }
        [ForeignKey("VehicleMarkId")]
        public VehicleMark? VehicleMark { get; set; }

        public long VehicleTypeId { get; set; }
        [ForeignKey("VehicleTypeId")]
        public VehicleType? VehicleType { get; set; }
    }
}
