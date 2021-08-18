using Moobie.WebView.TemplateModels;
using NameConventionizer;

namespace Moobie.WebView.ViewFactory
{
    public interface IViewBuilder
    {
        public ConventionableName Name { get; }
        public PagePayload<T> BuildView<T>() where T : class;
    }
}
