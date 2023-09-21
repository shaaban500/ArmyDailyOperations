using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.Soldiers
{
    public class GetAllSoldiersViewModel
    {
        public Soldier? Soldier { get; set; }
        public PowerType? PowerType { get; set; }
        public Department? Department { get; set; }
        public Skill? Skill { get; set; }
        public string? CertificateName { get; set; }
        public int ExtraDuration { get; set; }
        public List<Soldier>? Soldiers { get; set; }

        public List<EducationType>? EducationTypes { get; set; }
        public List<bool> HasEducationType { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<bool> HasSkill { get; set; }
        public List<PowerType>? PowerTypes { get; set; }
        public List<Department>? Departments { get; set; }

        public GetAllSoldiersViewModel()
        {
            EducationTypes = new List<EducationType>();
            HasEducationType = new List<bool>();
            PowerTypes = new List<PowerType>();
            Departments = new List<Department>();
            HasSkill = new List<bool>();
            Skills = new List<Skill>()
            {
                new Skill{Id = 1, Name = "سائق"},
                new Skill{Id = 2, Name = "فوتوشوب"},
                new Skill{Id = 3, Name = "مونتاج"},
                new Skill{Id = 4, Name = "برمجيات"},
                new Skill{Id = 5, Name = "وورد و إكسيل"},
            };
        }
    }
}
