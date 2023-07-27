using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Members
{
    public class EducationCertificate : BaseEntity
    {
        public string CertificateName { get; set; }
        
        public long SoldierId { get; set; }
        [ForeignKey("SoldierId")]
        public Soldier Soldier { get; set; }
    }
}
