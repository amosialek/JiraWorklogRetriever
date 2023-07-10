using JiraWorklogRetriever.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Jira
{
    public static class Jira
    {
        public async static Task JiraApiGetWorkLog(string baseUrl, string email, string token, int lastNDays = 8) 
        {
            string jql = $"worklogAuthor = currentUser() AND worklogDate > -{lastNDays}d";
            var request = JiraApiCreateRequestMessage($"issue/picker?currentJQL={jql}", email, token, HttpMethod.Get);
            var client = new HttpClient();

            client.BaseAddress = new Uri($"{baseUrl}/rest/api/latest/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            var status = response.StatusCode;
            var content = response.Content;
            try
            {
                var issuePickerRootObject = JsonConvert.DeserializeObject<IssuePickerRootObject>(await content.ReadAsStringAsync());
                List<Worklog> myWorklogs = new List<Worklog>();
                foreach (var issue in issuePickerRootObject.sections.SelectMany(x => x.issues))
                {
                    request = JiraApiCreateRequestMessage($"issue/{issue.key}/worklog",email,token, HttpMethod.Get);
                    response = await client.SendAsync(request);
                    status = response.StatusCode;
                    content = response.Content;
                    var worklogRootObject = JsonConvert.DeserializeObject<WorklogRootObject>(await content.ReadAsStringAsync());
                    foreach(var worklog in worklogRootObject.worklogs)
                    { worklog.issue = issue;}
                    myWorklogs.AddRange(worklogRootObject
                        .worklogs
                        .Where(x => x.author.emailAddress == email
                            && DateTime.Now.AddDays(-lastNDays) < x.started));
                    
                }
                var myWorklogsOrdered = myWorklogs.OrderBy(x => x.started).GroupBy(x => x.started.Date,x=>x);
                foreach (var worklogGroup in myWorklogsOrdered)
                {
                    Console.WriteLine($"{worklogGroup.Key.ToString("yyyy-MM-dd")}");
                    foreach(var worklog in worklogGroup)
                    {
                        Console.WriteLine($"\t{worklog.timeSpentSeconds / 3600.0}h {worklog.timeSpentSeconds % 3600.0/60.0}m {worklog.issue.key}");
                    }
                    Console.WriteLine($"\ttotal: {worklogGroup.Sum(x => x.timeSpentSeconds) / 3600.0}h");
                }   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        public static HttpRequestMessage JiraApiCreateRequestMessage(string url, string email, string token, HttpMethod method, string content = null)
        {
            var message = new HttpRequestMessage(method, url);
            var authenticationString = $"{email}:{token}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes(authenticationString));
            message.Headers.Add("Authorization", "Basic " + base64EncodedAuthenticationString);
            if (!string.IsNullOrEmpty(content))
            {
                var httpcontent = new StringContent(content);
                httpcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                message.Content = httpcontent;
            }
            return message;
        }



    }
}
