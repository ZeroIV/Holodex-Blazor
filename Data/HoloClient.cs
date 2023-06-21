using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace HoloDex_UI.Data
{
    public class HoloClient
    {
        private static readonly string url = "https://holodex.net/api/v2/";
        private static string key;
        private static HttpClient httpClient;

        public HoloClient(string str = "259e9c17-fd1d-473e-a3ea-3e613f530bfb", HttpClient client = null)
        {
            key = str;
            httpClient = client ?? new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-APIKEY", key);
            httpClient.BaseAddress = new Uri(url);
        }

        public async Task<Channel> GetChannel(string channelId)
        {
            channelId = channelId.Trim().ToLower();
            string endpoint = "channels/" + channelId;
            JObject json = await RequestObject(endpoint);

            return json.ToObject<Channel>();
        }

        /// <summary>
        /// Retrieves list of channels 
        /// </summary>
        /// <param name="lang">language to </param>
        /// <param name="limit">number of results to return</param>
        /// <param name="offset"></param>
        /// <param name="sortOrder">direction results should be sorted [asc||desc]</param>
        /// <param name="organization">orginization to filter results by</param>
        /// <param name="sortBy">column results should be sorted on</param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<Channel>> GetChannels(string lang = null, int limit = 25, int offset = 0,
                                                                string sortOrder = "asc", string organization = null, string sortBy = "org")
        {
            StringBuilder sb = new StringBuilder("channels?");
            if (lang != null)
            {
                sb.Append("&lang=");
                sb.Append(lang);
            }
            // Clamp between min and max channel count
            limit = Math.Clamp(limit, 1, 50);

            sb.Append("&limit=");
            sb.Append(limit);

            sb.Append("&offset=");
            sb.Append(offset);

            sb.Append("&order=");
            sb.Append(sortOrder);
            //sb.Append(order == SortOrder.Ascending ? "asc" : "desc");

            if (organization != null)
            {
                sb.Append("&org=");
                sb.Append(organization);
            }

            sb.Append("&sort=");
            sb.Append(sortBy);
            sb.Append("&type=vtuber");

            JArray result = await RequestArray(sb.ToString());

            return result.ToObject<List<Channel>>();
        }

        /// <summary>
        /// Retrieves list of channels associated with given organization
        /// </summary>
        /// <param name="organization"> the organization to retrieve associated accounts for</param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<Channel>> GetChannels(string organization, int offset = 0, int limit = 25)
        {
            string sortOrder = "asc";
            string sortBy = "group";

            organization = organization.Trim();

            StringBuilder sb = new StringBuilder("channels?");

            sb.Append("&limit=");
            sb.Append(limit);

            sb.Append("&offset=");
            sb.Append(offset);

            sb.Append("&order=asc");
            sb.Append(sortOrder);

            sb.Append("&org=");
            sb.Append(organization);

            sb.Append("&sort=");
            sb.Append(sortBy);
            sb.Append("&type=vtuber");

            JArray result = await RequestArray(sb.ToString());

            return result.ToObject<List<Channel>>();
        }

        public async Task<IReadOnlyCollection<Video>> GetUpcoming(string channelId, string include = "live_info,description", 
                                                                string lang = null, int lim = 25, int maxHours = 24, int offset = 0,
                                                                string order = "asc", string org = null)
        {
            string status = "upcoming";
            string type = "stream";

            StringBuilder sb = new StringBuilder("live?");

            sb.Append("&channel_id=");
            sb.Append(channelId);

            sb.Append("&include=");
            sb.Append(include);

            if (lang != null)
            {
                sb.Append("&lang=");
                sb.Append(lang);
            }

            sb.Append("&limit=");
            sb.Append(lim);

            sb.Append("&max_upcoming_hours=");
            sb.Append(maxHours);

            sb.Append("&offset=");
            sb.Append(offset);

            sb.Append("&order=");
            sb.Append(order);

            if (org != null)
            {
                sb.Append("&org=");
                sb.Append(org);
            }

            sb.Append("&type=");
            sb.Append(type);

            //JArray result = await RequestArray(sb.ToString());
            var result = await httpClient.GetFromJsonAsync<Video[]>(sb.ToString());

            //return result.ToObject<List<Video>>();
            return result;
        }

        public async Task<IReadOnlyCollection<Video>> GetStreams(string org)
        {
            string include = "live_info";
            int limit = 25;
            int maxHours = 24;
            int offset = 0;
            string sort = "start_scheduled";
            string order = "asc";
            string type = "stream";

            StringBuilder sb = new StringBuilder("live?");

            sb.Append("&include=");
            sb.Append(include);

            sb.Append("&limit=");
            sb.Append(limit);

            sb.Append("&max_upcoming_hours=");
            sb.Append(maxHours);

            sb.Append("&offset=");
            sb.Append(offset);

            sb.Append("&order=");
            sb.Append(order);

            if (org != null)
            {
                sb.Append("&org=");
                sb.Append(org);
            }

            sb.Append("&sort=");
            sb.Append(sort);

            //sb.Append("&status=");
            //sb.Append(status);

            sb.Append("&type=");
            sb.Append(type);

            JArray result = await RequestArray(sb.ToString());
            //var result = await httpClient.GetFromJsonAsync<List<Video>>(sb.ToString());

            return result.ToObject<List<Video>>();
            //return result;
        }

        public async Task<IReadOnlyCollection<Video>> GetUpcoming(string[] channels)
        {
            string query;
            query = string.Join(", ", channels);

            StringBuilder sb = new StringBuilder("users/live?");
            sb.Append(query);

            JArray result = await RequestArray(sb.ToString());

            return result.ToObject<List<Video>>();
        }

        private async Task<JArray> RequestArray(string endpoint)
        {
            string response;
            try
            {
                HttpResponseMessage httpResponse = await httpClient.GetAsync(url + endpoint);
                response = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }

            JArray result;
            // since errors are returned as objects, we have to handle if the json fails to deserialize to a JArray
            try
            {
                result = JArray.Parse(response);
            }
            catch (JsonException e)
            {
                /* Handle invalid endpoint parameters
                *  API returns a single JSON object named 'message'
                *  Example: {"message":"Channel Id not found"}
                */

                // parse the error into an object
                JObject error = JObject.Parse(response);
                if (error["message"] != null)
                    throw new ArgumentException(error["message"].ToString());
                // special case for when we fail to parse the error message
                else
                    throw new Exception("Unhandled error when parsing Json Array: " + e.Message);
            }

            return result;
        }

        private async Task<JObject> RequestObject(string endpoint)
        {
            string response;
            try
            {
                HttpResponseMessage httpResponse = await httpClient.GetAsync(url + endpoint);
                response = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }
            Console.WriteLine("Printing Json\n" + response);

            JObject result = JObject.Parse(response);

            /* Handle invalid endpoint parameters
            *  API returns a single JSON object named 'message'
            *  Example: {"message":"Channel Id not found"}
            */

            if (result["message"] != null)
                throw new ArgumentException(result["message"].ToString());

            return result;
        }
    }
}
