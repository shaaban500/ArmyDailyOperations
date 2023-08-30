using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities
{
    public class OperationDescription : BaseEntity
    {
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
