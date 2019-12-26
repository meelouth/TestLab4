using System;
using TestLab4.Repository;

namespace TestLab4
{
    public class Program
    {
        static void Main(string[] args)
        {
           MessageRepository rep = new MessageRepository();

           Console.WriteLine(rep.GetMessage("/channels/0"));
        }
    }
}