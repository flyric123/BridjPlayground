using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Framework.Datas;
using Framework.Services;

namespace Framework.ServiceImps
{
    /// <summary>
    /// the implementation of the ICloudService interface to work with the test endpoint
    /// </summary>
    public class TestEndPointCloudService : ICloudService
    {
        /// <summary>
        /// the class holds the data structure from the cloud endpoint
        /// </summary>
        private class EventList
        {
            public List<EventDetail> events { get; set; }
        }

        /// <summary>
        /// the endpoint url
        /// </summary>
        private readonly string s_readonly_str_endpoint_url = "https://s3-ap-southeast-2.amazonaws.com/bridj-coding-challenge/events.json";

        public async Task<List<EventDetail>> GetEventDetails()
        {

            try
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, s_readonly_str_endpoint_url);

                using (HttpClient client = new HttpClient())
                {
                    var result = await client.SendAsync(message);

                    if (result.IsSuccessStatusCode)
                    {
                        var data = await result.Content.ReadAsStringAsync();

                        return Newtonsoft.Json.JsonConvert.DeserializeObject<EventList>(data).events;
                    }
                    else
                    {
                        throw new Exception("Failed to get data from cloud!");
                    }
                }
            }
            catch
            {
                return new List<EventDetail>();  // return empty list if anything goes wrong
            }
        }
    }
}
