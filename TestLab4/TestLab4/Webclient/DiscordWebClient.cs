using System.IO;
using System.Net;

namespace TestLab4.Webclient
{
    public class DiscordWebClient : WebClient
    {
        private string baseURL = "https://discordapp.com/api";

        private void SendRequestToDiscord(string prefix)
        {
            base.SendRequest(baseURL + prefix);
        }
    }
}