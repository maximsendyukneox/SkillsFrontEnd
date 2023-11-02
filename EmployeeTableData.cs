using SkillsBackend.Model;

namespace SkillsFrontEnd
{
    public class EmployeeTableData
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public List<string> Skills { get; set; } = new List<string>();
        public List<ProficiencyLevel> SkillLevels { get; set; } = new List<ProficiencyLevel>();
    }
}
