using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TestLab4.Model;
using TestLab4.Webclient;

namespace TestLab4.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public string baseURL { get; set; }

        public List<Message> GetMessages(string channelId)
        {
            string request = $"{baseURL}{channelId}/messages?limit=3";
            
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }

        private List<Message> Parse(string json)
        {
            var messages = JsonConvert.DeserializeObject<List<Message>>(json);
            return messages;
        }
    }
}