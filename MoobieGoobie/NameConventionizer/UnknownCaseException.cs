using System;

namespace NameConventionizer
{
    public class UnknownCaseException : Exception
    {
        public UnknownCaseException(string msg) : base(msg) { }
    }
}
