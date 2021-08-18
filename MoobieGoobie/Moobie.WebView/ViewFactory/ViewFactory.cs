using Moobie.WebView.TemplateModels;
using System;
using System.Collections.Generic;

namespace Moobie.WebView.ViewFactory
{
    public class ViewFactory : IViewFactory
    {
        private readonly IEnumerable<IViewBuilder> ViewBuilders;

        public ViewFactory(IEnumerable<IViewBuilder> viewBuilders)
        {
            ViewBuilders = viewBuilders ?? throw new ArgumentNullException(nameof(viewBuilders));
        }

        public PagePayload<T> GetView<T>(string viewName) where T : class
        {
            foreach (var builder in ViewBuilders)
            {
                if (builder.Name == viewName)
                {
                    return builder.BuildView<T>();
                }
            }
            throw new NotImplementedException($"No implementation found for {viewName}.");
        }
    }
}
