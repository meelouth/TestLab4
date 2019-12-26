using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MockServer
{
    class Server
    {
        static void Main(string[] args)
        {
            Listen();
        }

        private static void Listen()
        {
            HttpListener listener = new HttpListener();
            // установка адресов прослушки
            listener.Prefixes.Add("http://localhost:8888/connection/");
            
            listener.Start();
            Console.WriteLine("Ожидание подключений...");


            while (true)
            {
                HttpListenerContext context =  listener.GetContext();
                HttpListenerRequest request = context.Request;

                // получаем объект ответа
                HttpListenerResponse response = context.Response;

               ProcessRequest(request.Url.AbsolutePath, response);
            }
        }

        private static void SendMessageToClient(object message, HttpListenerResponse response)
        { 
            byte[] buffer = ConvertMessageToBytes(message);

            // получаем поток ответа и пишем в него ответ
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            
            output.Close();
        }

        private static byte[] ConvertMessageToBytes(object message)
        {
            string json = JsonConvert.SerializeObject(message);
            return System.Text.Encoding.UTF8.GetBytes(json);
        }

        private static void ProcessRequest(string request, HttpListenerResponse response)
        {
            switch (request)
            {
                case "/connection/":
                    int[] responseMsg = {5, 6};
                    SendMessageToClient(responseMsg,response);
                    break;
            }
        }
    }
}