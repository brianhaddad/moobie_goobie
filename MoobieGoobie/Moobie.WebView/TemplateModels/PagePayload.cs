namespace Moobie.WebView.TemplateModels
{
    public class PagePayload<T>
    {
        public string PageTitle { get; set; }
        public TemplateNode Template { get; set; }
        public T Data { get; set; }
    }
}
