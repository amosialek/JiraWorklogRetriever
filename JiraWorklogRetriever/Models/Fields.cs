namespace JiraWorklogRetriever.Models
{
    public class Fields
    {
        public DateTime statuscategorychangedate { get; set; }
        public Parent parent { get; set; }
        public Fixversion[] fixVersions { get; set; }
        public Resolution resolution { get; set; }
        public DateTime? lastViewed { get; set; }
        public Priority priority { get; set; }
        public string[] labels { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public int timeestimate { get; set; }
        public object[] versions { get; set; }
        public Issuelink[] issuelinks { get; set; }
        public Assignee assignee { get; set; }
        public Status status { get; set; }
        public object[] components { get; set; }
        public int aggregatetimeestimate { get; set; }
        public Creator creator { get; set; }
        public object[] subtasks { get; set; }
        public Reporter reporter { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public Progress progress { get; set; }
        public object customfield_11809 { get; set; }
        public Votes votes { get; set; }
        public Issuetype issuetype { get; set; }
        public int timespent { get; set; }
        public Project project { get; set; }
        public int aggregatetimespent { get; set; }
        public DateTime? resolutiondate { get; set; }
        public int workratio { get; set; }
        public Watches watches { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public object timeoriginalestimate { get; set; }
        public string summary { get; set; }
        public object environment { get; set; }
        public object duedate { get; set; }
    }

}
