using System;
using System.IO;
using System.Net;

namespace TestLab4.Webclient
{
    public class WebClient
    {
        //private string baseURL = "https://discordapp.com/api";
        
        public string SendRequest(string requestString, string method)
        {
           // requestString = baseURL + requestString;
            
            WebRequest request = WebRequest.Create(requestString); 
            request.Headers.Set("Authorization", "Bot NjU5NzkwMzA4NTA2MzM3MzAw.XgTl8w.xEsPdisPBXyoN3cwCHqD-SusYxo");

            request.Method = method;

            request.Credentials = CredentialCache.DefaultCredentials;
            
            WebResponse response = request.GetResponse(); 
            
            Stream stream = response.GetResponseStream(); 
            
            StreamReader reader = new StreamReader(stream);
            
            
            string receiveMessage = reader.ReadToEnd();
            
            stream.Close();
            response.Close();

            return receiveMessage;
        }
    }
}