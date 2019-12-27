using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestLab4.Model
{
    public class Message
    {
        public string id;
        public string channel_id;
        public string content { get; set; }
    }
}