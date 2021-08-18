namespace Moobie.WebView.TemplateModels
{
    public class PagePayload<T> where T : class
    {
        public string PageTitle { get; set; }
        public TemplateNode Template { get; set; }
        public T Data { get; set; }
    }
}
