using Moobie.WebView.TemplateModels;
using System;
using System.Collections.Generic;

namespace Moobie.WebView.Extensions
{
    public static class TemplateNodeExtensions
    {
        public static TemplateNode AddTemplate<T>(this PagePayload<T> payload, string type, Dictionary<string, string> attributes = null, string innerHTML = null, Action<TemplateNode> config = null)
        {
            payload.Template = new TemplateNode
            {
                Type = type,
                Attributes = attributes,
                InnerHTML = innerHTML,
            };

            if (!(config is null))
            {
                config(payload.Template);
            }

            return payload.Template;
        }

        public static TemplateNode AddChild(this TemplateNode templateNode, string type, Dictionary<string, string> attributes = null, string innerHTML = null, Action<TemplateNode> childConfig = null)
        {
            if (templateNode.Children is null)
            {
                templateNode.Children = new List<TemplateNode>();
            }

            var child = new TemplateNode
            {
                Type = type,
                Attributes = attributes,
                InnerHTML = innerHTML,
            };

            if (!(childConfig is null))
            {
                childConfig(child);
            }

            templateNode.Children.Add(child);

            return templateNode;
        }
    }
}
