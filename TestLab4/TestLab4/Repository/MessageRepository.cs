using TestLab4.Webclient;

namespace TestLab4.Repository
{
    public class MessageRepository
    {
        public string GetMessage(string message)
        {
            DiscordWebClient webClient = new DiscordWebClient();
            return webClient.SendRequest(message);
        }
    }
}