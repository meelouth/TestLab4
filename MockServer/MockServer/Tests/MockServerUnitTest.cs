using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using NUnit.Framework;

namespace MockServer.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void ServerCreated()
        {
            string server = "127.0.0.1:8888";

            var ping = new Ping();

            var reply = ping.Send(server, 60 * 1000);
            
            Assert.AreEqual(reply, reply.Status == IPStatus.Success);
        }
        
        [Test]
        public void ClientConnectedToServer()
        {
            string server = "127.0.0.1";
            int port = 8888;
            
            TcpClient client = new TcpClient(server,port);
            
            Byte[] data = new Byte[256];
            
            NetworkStream stream = client.GetStream();
            
            String responseData = String.Empty;
            
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            
            Assert.AreEqual("Hello world",responseData);
            
            stream.Close();         
            client.Close();      
        }
    }
}