using System.Collections.Generic;
using System.Net;
using RestSharp;
using System.Text.Json;
using System.IO;
namespace tagi
{
    public class TagDataDownloader
    {
        private RestClient client;
        private string site;
        private int page;
        public TagDataDownloader(string site = "stackoverflow", int page=1)
        {
            this.client = new RestClient("https://api.stackexchange.com");
            this.site = site;
            this.page = page;
        }

        public List<TagData> Download()
        {

            var response = this.client.Execute<TagDataRequestResponse>(this.GetRequest());
            return response.Data.items;

        }

        private RestRequest GetRequest()
        {
            var url = $"https://api.stackexchange.com/2.3/tags?pagesize=100&order=desc&sort=popular&site={this.site}&page={this.page}";
            return new RestRequest(url, Method.GET);
        }
        
    }
}