using System;
using TestLab4.Repository;

namespace TestLab4
{
    public class Program
    {
        static void Main(string[] args)
        {
           MessageRepository rep = new MessageRepository();

           Console.WriteLine(rep.GetMessages("https://discordapp.com/api/channels/659801659911962647/messages?limit=3")[0].id);
        }
    }
}