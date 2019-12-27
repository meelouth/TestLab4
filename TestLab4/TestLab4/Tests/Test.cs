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

            string receiveMessage = messageRepository.GetMessages("659801659911962647")[0]
                .content;
            
            Assert.AreEqual("Yeeey", receiveMessage);

            messageRepository = new  TestLab4.Tests.Repository.MessageRepository();
            
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

            string channelId = "659801659911962647";
            
            Assert.AreEqual("Hello world",messagesService.GetMostLongContent(channelId).content);
            Assert.AreEqual(11,messagesService.GetMostLongContent(channelId).content.Length);
            
            messagesService = new MessagesService(new Repository.MessageRepository());
            
            Assert.AreEqual("Hello world", messagesService.GetMostLongContent(channelId).content);
            Assert.AreEqual(11,messagesService.GetMostLongContent(channelId).content.Length);

        }

        [Test]
        public void GetReaction()
        {            
            var reactionRepository = new ReactionRepository();

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

            Assert.AreEqual(username, reactionRepository.GetReactions(reaction)[0].username);
            
            reactionRepository = new TestLab4.Tests.Repository.ReactionRepository();
            
            reactionRepository.CreateReaction(reaction);
            
            Assert.AreEqual(username, reactionRepository.GetReactions(reaction)[0].username);
            
        }
    }
}