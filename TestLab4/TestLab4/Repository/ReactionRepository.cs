using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TestLab4.Model;
using TestLab4.Webclient;

namespace TestLab4.Repository
{
    public class ReactionRepository : IReactionRepository
    {
        private string baseURL = "http://localhost:8888/";

        public void CreateReaction(Reaction reaction)
        {
            string request = $"{baseURL}createReaction";
            
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "PUT");
        }

        public List<User> GetReactions(Reaction reaction)
        {
            string request = $"{baseURL}getReaction";
            
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }

        private List<User> Parse(string json)
        {
            var reaction = JsonConvert.DeserializeObject<List<User>>(json);
            return reaction;
        }
    }
}