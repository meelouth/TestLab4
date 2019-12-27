using System.Collections.Generic;
using TestLab4.Model;

namespace TestLab4.Repository
{
    public interface IReactionRepository
    {
        void CreateReaction(Reaction reaction);
        List<User> GetReactions(Reaction reaction);
    }
}