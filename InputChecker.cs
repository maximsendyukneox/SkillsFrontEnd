namespace SkillsFrontEnd
{
    public static class InputChecker
    {
        public static void ValidateName( string name)
        {
            char[] forbiddenSymbols = { '\'', '#', '"', '§', '@', '$', '%', '&', '/', '(', ')', '{', '}', '[', ']', '?', '\\', '|', '<', '>' };
            foreach (char symbol in forbiddenSymbols)
            {
                if (name.Contains(symbol))
                {
                    throw new ArgumentException("Special characters are not allowed");
                }
            }

            if (name == String.Empty)
            {
                throw new ArgumentException("The name must not be empty");
            }
        }

        public static void ValidateSkill( string skillName )
        {
            if (skillName == String.Empty)
            {
                throw new ArgumentException("The name must not be empty");
            }
        }
    }
}
