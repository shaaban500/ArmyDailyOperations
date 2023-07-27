using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Members
{
    public class SoldiersExtraDuration : BaseEntity
    {
        public long SoldierId { get; set; }
        [ForeignKey("SoldierId")]
        public Soldier Soldier { get; set; }

        public int ExtraDuration { get; set; }
    }
}
