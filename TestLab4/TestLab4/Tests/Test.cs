using NUnit.Framework;
using TestLab4.Model;
using TestLab4.Repository;
using TestLab4.Services;

namespace TestLab4.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void GetMessageFromRepositoryTest()
        {
            IMessageRepository messageRepository = new MessageRepository();
            
            messageRepository.baseURL =  "https://discordapp.com/api/channels/";


            string receiveMessage = messageRepository.GetMessages("659801659911962647")[0]
                .content;
            
            Assert.AreEqual("Yeeey", receiveMessage);

            messageRepository.baseURL =  "http://localhost:8888/";

            string receiveMessageFromMock =
                messageRepository.GetMessages(
                        "659801659911962647")[0]
                    .content;
            
            Assert.AreEqual("Hello world", receiveMessageFromMock);
        }

        [Test]
        public void GetMostLongContent()
        {
            MessagesService messagesService = new MessagesService(new MessageRepository());
            messagesService.messageRepository.baseURL =  "https://discordapp.com/api/channels/";

            string channelId = "659801659911962647";
            
            Assert.AreEqual("Yeeey",messagesService.GetMostLongContent(channelId).content);
            Assert.AreEqual(5,messagesService.GetMostLongContent(channelId).content.Length);
            
            messagesService.messageRepository = new Repository.MessageRepository();
            
            Assert.AreEqual("Hello world", messagesService.GetMostLongContent(channelId).content);
            Assert.AreEqual(11,messagesService.GetMostLongContent(channelId).content.Length);

        }

        [Test]
        public void GetReaction()
        {            
            var reactionRepository = new ReactionRepository();
            
            reactionRepository.baseURL =  "https://discordapp.com/api/channels/";

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
            
            string username = "Superduper Bot";

            Assert.AreEqual(username, reactionRepository.GetReactions(reaction)[0].username);

        }
        
        [Test]
        public void CreateReaction()
        {
            IReactionRepository reactionRepository = new ReactionRepository();
            reactionRepository.baseURL =  "https://discordapp.com/api/channels/";
            
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
            
            reactionRepository.CreateReaction(reaction);

            string username = "Superduper Bot";

            Assert.AreEqual(username, reactionRepository.GetReactions(reaction)[0].username); //change tests
            
            reactionRepository.baseURL = "http://localhost:8888/";
            
            reactionRepository.CreateReaction(reaction);
            
            Assert.AreEqual(username, reactionRepository.GetReactions(reaction)[0].username);
        }

        [Test]
        public void CreateReactionService()
        {
            IReactionRepository reactionRepository = new ReactionRepository(); 
            
            reactionRepository.baseURL =  "https://discordapp.com/api/channels/";

            
            ReactionService reactionService = new ReactionService(reactionRepository);
            
            Emoji emoji = new Emoji()
            {
                id = "41771983429993937",
                name = "LUL",
                unicode = "\U0001F606"
            };
            Reaction reaction = new Reaction
            {
                emoji = emoji,
                channelId = "659801659911962647",
                messageId = "659888240651665458"
            };
            
            reactionService.React(reaction);

            string usernameWhoCreateReaction = "Superduper Bot";
            
            Assert.AreEqual(usernameWhoCreateReaction, reactionService.ReactionRepository.GetReactions(reaction)[0]
                .username);
            
            reactionService.ReactionRepository.baseURL =  "http://localhost:8888/";

            Emoji emoji1 = new Emoji()
            {
                id = "41771983429993937",
                name = "LUL",
                unicode = "\U0001F923"
            };
            Reaction reaction1 = new Reaction
            {
                emoji = emoji,
                channelId = "659801659911962647",
                messageId = "659888240651665458"
            };
            
            reactionService.React(reaction1);

            Assert.AreEqual(usernameWhoCreateReaction, reactionService.ReactionRepository.GetReactions(reaction1)[0]
                .username);
        }
    }
}