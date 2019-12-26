using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TestLab4.Model;
using TestLab4.Webclient;

namespace TestLab4.Repository
{
    public class MessageRepository
    {
        public List<Message> GetMessages(string request)
        {
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            Console.WriteLine(json);
            return Parse(json);
        }

        private List<Message> Parse(string json)
        {
            var messages = JsonConvert.DeserializeObject<List<Message>>(json);
            return messages;
        }
    }
}