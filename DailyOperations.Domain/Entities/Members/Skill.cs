using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Members
{
    public class Skill :BaseEntity
    {
        public string Name { get; set; }
        public List<Soldier> Soldiers { get; set; }
    }
}
