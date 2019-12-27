using System.Collections.Generic;
using TestLab4.Model;

namespace TestLab4.Repository
{
    public interface IMessageRepository
    {
        List<Message> GetMessages(string request);
    }
}