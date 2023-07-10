using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraWorklogRetriever.Models
{
    public class Issue
    {
        public int id { get; set; }
        public string key { get; set; }
        public string keyHtml { get; set; }
        public string img { get; set; }
        public string summary { get; set; }
        public string summaryText { get; set; }
    }
}
