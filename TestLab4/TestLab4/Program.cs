using System;
using TestLab4.Model;
using TestLab4.Repository;

namespace TestLab4
{
    public class Program
    {
        static void Main(string[] args)
        {
           MessageRepository rep = new MessageRepository();

         //  Console.WriteLine(rep.GetMessages("41771983429993937")[0].id);
         
         ReactionRepository repository = new ReactionRepository();

         Emoji emoji = new Emoji()
         {
            id = "41771983429993937",
            name = "LUL",
            unicode = "\U0001F3D3"
         };
         Reaction reaction = new Reaction
         {
             emoji = emoji,
             channelId = "659801659911962647",
             messageId = "659888240651665458"
         };
       //  repository.CreateReaction(reaction);

        
        Console.WriteLine(repository.GetReactions(reaction)[0].username);
        }
    }
}