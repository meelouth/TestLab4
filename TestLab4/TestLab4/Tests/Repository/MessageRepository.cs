using System.Collections.Generic;
using TestLab4.Model;
using TestLab4.Repository;

namespace TestLab4.Tests.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public List<Message> GetMessages(string request)
        {
            List<Message> responseMsg = new List<Message>()
            {
                new Message()
                {
                    id = "659888240651665458",
                    channel_id = "659801659911962647",
                    content = "Hello world"
                },
                            
            };

            return responseMsg;
        }

        public string baseURL { get; set; }
    }
}