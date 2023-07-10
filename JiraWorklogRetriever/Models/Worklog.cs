namespace JiraWorklogRetriever.Models
{
    public class Worklog
    {
        internal Issue issue;

        public string self { get; set; }
        public Author author { get; set; }
        public Updateauthor updateAuthor { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public DateTime started { get; set; }
        public string timeSpent { get; set; }
        public int timeSpentSeconds { get; set; }
        public string id { get; set; }
        public string issueId { get; set; }
    }
}
