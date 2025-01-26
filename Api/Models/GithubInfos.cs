using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class GithubInfos
    {
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public DateTime created_at { get; set; }
        public GithubOwner owner { get; set; }
    }

    public class GithubOwner
    {
        public string avatar_url { get; set; }
    }

    public class GitHubRequest
    {
        public int total_count { get; set; }

        public List<GithubInfos> items { get; set; }
    }
}