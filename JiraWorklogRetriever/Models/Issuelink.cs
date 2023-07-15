namespace JiraWorklogRetriever.Models
{
    public class Issuelink
    {
        public string id { get; set; }
        public string self { get; set; }
        public Type type { get; set; }
        public Outwardissue outwardIssue { get; set; }
        public Inwardissue inwardIssue { get; set; }
    }

}
