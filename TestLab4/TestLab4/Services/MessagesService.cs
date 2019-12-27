using System.Collections.Generic;
using TestLab4.Model;
using TestLab4.Repository;

namespace TestLab4.Services
{
    public class MessagesService
    {
        private IMessageRepository messageRepository;

        public MessagesService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public Message GetMostLongContent(string channelId)
        {
            List<Message> messages = messageRepository.GetMessages(channelId);


            Message temp = new Message
            {
                content = ""
            };
            
            foreach (var message in messages)
            {
                if (message.content.Length > temp.content.Length)
                    temp = message;
            }

            return temp;
        }
    }
}