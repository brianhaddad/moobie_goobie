using System;

namespace Moobie.WebView.Exceptions
{
    public class PayloadDataMismatchException : Exception
    {
        public PayloadDataMismatchException(string msg) : base(msg) { }
    }
}
