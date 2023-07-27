using SkillsDatabase;
using static System.Net.Mime.MediaTypeNames;

namespace SkillsFrontEnd
{
    public static class StatischeKlasse
    {
        public static Tuple<List<String?>, List<ProficiencyLevel>> skillLevelInputList = new Tuple<List<string?>, List<ProficiencyLevel>>(new List<string?>(), new List<ProficiencyLevel>());


        public static string? getInput()
        {
            return skillLevelInputList.Item1[SkillsFrontEnd.Program.i];
        }
        public static Task setInput(string sk)
        {
            skillLevelInputList.Item1[SkillsFrontEnd.Program.i] = sk;
            return Task.CompletedTask;
        }

        public static Task SetAsync(string value) { skillLevelInputList.Item1[SkillsFrontEnd.Program.i] = value; return Task.CompletedTask; }
    }
}

