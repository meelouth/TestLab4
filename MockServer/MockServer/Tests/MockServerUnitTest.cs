using System;
using System.IO;
using System.Net;
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
            var ping = new Ping();

            var reply = ping.Send(new IPAddress(new byte[]{127,0,0,1}), 3000);
            
            Assert.AreEqual(reply.Status, IPStatus.Success);
        }
        
        [Test]
        public void ClientConnectedToServer()
        {
            WebRequest request = WebRequest.Create("http://localhost:8888/connection/");
            
            request.Credentials = CredentialCache.DefaultCredentials;
            
            WebResponse response = request.GetResponse();
            
            Stream stream = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(stream);
            
            string responseFromServer = reader.ReadToEnd();

            Assert.AreEqual("Hello world",responseFromServer);
            
            stream.Close();
            response.Close();
        }
    }
}