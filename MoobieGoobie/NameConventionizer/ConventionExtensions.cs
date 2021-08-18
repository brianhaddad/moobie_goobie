using System.Text.RegularExpressions;

namespace NameConventionizer
{
    public static class ConventionExtensions
    {
        private static readonly Regex NonAlphanumeric = new Regex("[^a-zA-Z0-9]");

        public static string CapitalizeOnlyFirstLetter(this string word)
        {
            var firstLetter = word.Substring(0, 1);
            var rest = word.Substring(1);
            return firstLetter.ToUpper() + rest.ToLower();
        }

        public static string JoinWith(this string[] words, string separator)
            => string.Join(separator, words);

        public static string RemoveNonAlphanumerics(this string str)
            => NonAlphanumeric.Replace(str, string.Empty);

        public static NamingConventions GuessConvention(this string str)
        {
            var containsUnderscore = str.Contains('_');
            var containsDash = str.Contains('-');
            var containsSpace = str.Contains(' ');
            if (containsSpace && !containsUnderscore && !containsDash)
            {
                return str.Split(' ').GuessConvention(str);
            }
            else if (containsDash && !containsSpace && !containsUnderscore)
            {
                return str.Split('-').GuessConvention(str);
            }
            else if (containsUnderscore && !containsSpace && !containsDash)
            {
                return str.Split('_').GuessConvention(str);
            }
            else if (!containsDash && !containsSpace && !containsUnderscore)
            {
                var capitalizationState = str.GuessCapitalization();
                switch (capitalizationState)
                {
                    case CapitalizationState.AllUpper:
                        return NamingConventions.MacroCase;
                    case CapitalizationState.FirstLetterCapitalized:
                    case CapitalizationState.PascalCase:
                        return NamingConventions.PascalCase;
                    case CapitalizationState.CamelCase:
                        return NamingConventions.CamelCase;
                }
            }
            throw new UnknownCaseException($"Unable to detect case of '{str}'");
        }

        public static NamingConventions GuessConvention(this string[] words, string str)
            => (new ConventionableName(words)).TestString(str);

        public static CapitalizationState GuessCapitalization(this string str)
        {
            str = str.RemoveNonAlphanumerics();
            if (str == str.ToUpper())
            {
                return CapitalizationState.AllUpper;
            }
            if (str == str.ToLower())
            {
                return CapitalizationState.AllLower;
            }
            if (str == str.CapitalizeOnlyFirstLetter())
            {
                return CapitalizationState.FirstLetterCapitalized;
            }
            if (str.Substring(0, 1) == str.Substring(0, 1).ToUpper())
            {
                return CapitalizationState.PascalCase;
            }
            else if (str.Substring(0, 1) == str.Substring(0, 1).ToLower())
            {
                return CapitalizationState.CamelCase;
            }
            return CapitalizationState.Indeterminate;
        }
    }
}
