﻿namespace JiraWorklogRetriever.Models
{
    public class WorklogRootObject
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public Worklog[] worklogs { get; set; }
    }
}
