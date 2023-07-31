using SkillsDatabase;
using static System.Net.Mime.MediaTypeNames;

namespace SkillsFrontEnd
{
    public static class StatischeKlasse
    {
        public static Tuple<List<string>, List<ProficiencyLevel>> skillLevelInputList = new(new List<string>(), new List<ProficiencyLevel>());

        public static List<Proficiency> proficiencies = new ();

        public static int i;
        public static int N;

        public static string? getInput()
        {
            return skillLevelInputList.Item1[i];
        }
        public static Task setInput(string sk)
        {
            skillLevelInputList.Item1[i] = sk;
            return Task.CompletedTask;
        }

        public static Task SetAsync(string value) { skillLevelInputList.Item1[i] = value; return Task.CompletedTask; }

        public static SkillsContext? context;
    }
}

