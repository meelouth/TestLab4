using System.IO;
using System.Net;

namespace TestLab4.Webclient
{
    public abstract class WebClient
    {
        public string SendRequest(string requestString)
        {
            WebRequest request = WebRequest.Create(requestString);
            
            request.Credentials = CredentialCache.DefaultCredentials;
            
            WebResponse response = request.GetResponse(); 
            
            Stream stream = response.GetResponseStream(); 
            
            StreamReader reader = new StreamReader(stream);
            
            stream.Close();
            response.Close();
            
            return reader.ReadToEnd();
        }
    }
}