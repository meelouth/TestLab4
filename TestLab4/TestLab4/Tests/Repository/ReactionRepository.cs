using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TestLab4.Model;
using TestLab4.Repository;
using TestLab4.Webclient;

namespace TestLab4.Tests.Repository
{
    public class ReactionRepository : IReactionRepository
    {
        public string baseURL { get; set; }

        private List<User> users = new List<User>();
        public void CreateReaction(Reaction reaction)
        {
            User user = new User
            {
                id = "123",
                username = "Superduper Bot"
            };

                users.Add(user);
        }

        public List<User> GetReactions(Reaction reaction)
        {
            return users;
        }
    }
}