using Microsoft.AspNetCore.Mvc;
using Moobie.WebView.DTOs;
using Moobie.WebView.TemplateModels;
using Moobie.WebView.ViewFactory;
using System.Collections.Generic;

namespace MoobieGoobie.Controllers
{
    [ApiController]
    public class FormRoutes : ControllerBase
    {
        private readonly IViewFactory ViewFactory;

        public FormRoutes(IViewFactory viewFactory)
        {
            ViewFactory = viewFactory ?? throw new System.ArgumentNullException(nameof(viewFactory));
        }

        [HttpPost]
        [Route("/routes")]
        public PagePayload<IndexData> Index()
        {
            var result = ViewFactory.GetView<IndexData>("indexView");
            return result;
        }

        [HttpPost]
        [Route("/routes/{view}")]
        public PagePayload<object> Others([FromRoute] string view, [FromBody] Dictionary<string, object> data)
        {
            //TODO: Really think long and hard about this junk.
            var result = ViewFactory.GetView<object>(view);
            return result;
        }
    }
}
