﻿namespace JiraWorklogRetriever.Models
{
    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string projectTypeKey { get; set; }
        public bool simplified { get; set; }
        public Avatarurls avatarUrls { get; set; }
        public Projectcategory projectCategory { get; set; }
    }

}
