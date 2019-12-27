using System.Collections.Generic;
using TestLab4.Model;
using TestLab4.Repository;

namespace TestLab4.Services
{
    public class ReactionService
    {
        public IReactionRepository ReactionRepository;
        
        public ReactionService(IReactionRepository reactionRepository)
        {
            this.ReactionRepository = reactionRepository;
        }
        public void React(Reaction reaction)
        {
            ReactionRepository.CreateReaction(reaction);
            
            //some logic here
        }

        public List<User> GetReactions(Reaction reaction)
        {
           return ReactionRepository.GetReactions(reaction);
           
           //some logic here
        }
    }
}