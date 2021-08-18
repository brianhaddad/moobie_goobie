using Moobie.WebView.TemplateModels;
using Moobie.WebView.ViewFactory;
using NameConventionizer;
using System;

namespace Moobie.WebView.Views
{
    public class TestView : IViewBuilder
    {
        private readonly ConventionableName MyName = new ConventionableName("Test View".Split(' '));
        public ConventionableName Name => MyName;

        public PagePayload<T> BuildView<T>() where T : class
        {
            return new PagePayload<T>();
        }
    }
}
