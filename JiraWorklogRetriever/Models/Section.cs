namespace JiraWorklogRetriever.Models
{
    public class Section
    {
        public string label { get; set; }
        public string sub { get; set; }
        public string id { get; set; }
        public Issue[] issues { get; set; }
    }
}
