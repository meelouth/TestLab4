using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TestLab4.Model;
using TestLab4.Webclient;

namespace TestLab4.Repository
{
    public class ReactionRepository : IReactionRepository
    {
        private string baseURL = "https://discordapp.com/api/channels/";

        public void CreateReaction(Reaction reaction)
        {
            string request = $"{baseURL}{reaction.channelId}/messages/{reaction.messageId}/reactions/{reaction.emoji.unicode}/@me";
            
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "PUT");
        }

        public List<User> GetReactions(Reaction reaction)
        {
            string request = $"{baseURL}{reaction.channelId}/messages/{reaction.messageId}/reactions/{reaction.emoji.unicode}";
            
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