using NUnit.Framework;
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
            var messageRepository = new MessageRepository();

            string receiveMessage = messageRepository.GetMessages("https://discordapp.com/api/channels/659801659911962647/messages?limit=3")[0]
                .content;
            
            Assert.AreEqual("Hello world", receiveMessage);

            string receiveMessageFromMock =
                messageRepository.GetMessages(
                        "http://localhost:8888/channels")[0]
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
    }
}