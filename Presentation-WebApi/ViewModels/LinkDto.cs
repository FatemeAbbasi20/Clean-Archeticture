namespace Presentation_WebApi.ViewModels
{
    public class LinkDto
    {
        public LinkDto(string url, string rel, string method)
        {
            Url = url;
            Rel = rel;
            Method = method;
        }

        public string Url { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}
