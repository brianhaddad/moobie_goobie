using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NameConventionizer
{
    public class ConventionableName : IEquatable<string>
    {
        private readonly string[] NameParts;

        public ConventionableName(string[] parts)
        {
            NameParts = parts.Select(x => x.CapitalizeOnlyFirstLetter()).ToArray();
        }

        public bool Equals([AllowNull] string other)
        {
            var me = ConvertTo(NamingConventions.PascalCase).RemoveNonAlphanumerics().ToLower();
            var you = other.RemoveNonAlphanumerics().ToLower();
            return me == you;
        }

        public override string ToString()
            => ConvertTo(NamingConventions.SpacedTitleCase);

        public override bool Equals(object o) => Equals(o as string);

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(ConventionableName lhs, string rhs)
            => lhs.Equals(rhs);

        public static bool operator !=(ConventionableName lhs, string rhs)
            => !lhs.Equals(rhs);

        public static bool operator ==(string lhs, ConventionableName rhs)
            => rhs.Equals(lhs);

        public static bool operator !=(string lhs, ConventionableName rhs)
            => !rhs.Equals(lhs);

        public string ConvertTo(NamingConventions convention)
            => convention switch
            {
                NamingConventions.SpacedTitleCase => NameParts.JoinWith(" "),
                NamingConventions.PascalCase => NameParts.JoinWith(""),
                NamingConventions.CamelCase => MakeCamelCase(),
                NamingConventions.SnakeCase => NameParts.Select(x => x.ToLower()).ToArray().JoinWith("_"),
                NamingConventions.ShishKebabCase => NameParts.Select(x => x.ToLower()).ToArray().JoinWith("-"),
                NamingConventions.MacroCase => NameParts.Select(x => x.ToUpper()).ToArray().JoinWith("_"),
                _ => throw new UnknownCaseException($"Unable to translate to {convention}."),
            };

        public NamingConventions TestString(string str)
        {
            var enums = typeof(NamingConventions).GetEnumNames();
            foreach (var enumName in enums)
            {
                var e = (NamingConventions)Enum.Parse(typeof(NamingConventions), enumName);
                if (str == ConvertTo(e))
                {
                    return e;
                }
            }
            throw new UnknownCaseException($"'{str}' does not match any programmed case.");
        }

        private string MakeCamelCase()
        {
            var fullWord = NameParts[0].ToLower();
            if (NameParts.Length == 1)
            {
                return fullWord;
            }
            for (var i = 1; i < NameParts.Length; i++)
            {
                fullWord += NameParts[i];
            }
            return fullWord;
        }
    }
}
