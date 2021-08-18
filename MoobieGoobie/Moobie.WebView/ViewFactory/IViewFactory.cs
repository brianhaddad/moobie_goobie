using Moobie.WebView.TemplateModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moobie.WebView.ViewFactory
{
    public interface IViewFactory
    {
        public PagePayload<T> GetView<T>(string viewName) where T : class;
    }
}
