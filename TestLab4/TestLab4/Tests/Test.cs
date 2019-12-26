using NUnit.Framework;
using TestLab4.Repository;

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
        
    }
}