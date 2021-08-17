using System.Collections.Generic;

namespace Moobie.WebView.TemplateModels
{
    public class TemplateNode
    {
        public string Type { get; set; }
        public List<TemplateNode> Children { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public string InnerHTML { get; set; }
        public string ChildrenDataSource { get; set; }
        public TemplateNode ChildTemplate { get; set; }
    }
}
