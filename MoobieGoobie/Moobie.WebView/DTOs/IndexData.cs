using System.Collections.Generic;

namespace Moobie.WebView.DTOs
{
    public class IndexData
    {
        //TEMP TEST DATA
        public Dictionary<string, string> UserText { get; set; }
        public Dictionary<string, List<Option>> OptionCollections { get; set; }
    }

    public class Option
    {
        public string Display { get; set; }
        public string Value { get; set; }
    }
}
