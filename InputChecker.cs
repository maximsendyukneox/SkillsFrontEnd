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

        public static void ValidateDateOfBirth( DateTime dob ) 
        {
            if (dob > DateTime.Now)
            {
                throw new ArgumentException("The date of birth must not be in the future");
            }
        }

        public static void ValidateSkill( string skillName )
        {
            if (skillName == String.Empty)
            {
                throw new ArgumentException("The name must not be empty");
            }
        }

        public static void FindSkillDuplicates(List<string> skills)
        {
            foreach(string skill1 in skills)
            {
                foreach (string skill2 in skills)
                {
                    if(skill1 == skill2 && !object.ReferenceEquals(skill1, skill2))
                    {
                        throw new ArgumentException("One employee may not have the same skill twice");
                    }
                }
            }
        }
    }
}
