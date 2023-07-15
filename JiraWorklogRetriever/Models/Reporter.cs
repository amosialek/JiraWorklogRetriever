namespace JiraWorklogRetriever.Models
{
    public class Reporter
    {
        public string self { get; set; }
        public string accountId { get; set; }
        public Avatarurls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string accountType { get; set; }
        public string emailAddress { get; set; }
    }

}
