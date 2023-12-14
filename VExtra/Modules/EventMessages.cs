using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace VExtra.Modules
{
    public class EventMessages
    {
        WebSocket socket = new WebSocket($"wss://gateway.discord.gg/?v=10&encoding=json");
        string token;
        public void Start(string token)
        {
            this.token = token;
            Configure();

            socket.Connect();
        }

        public void OnMessage(JObject message)
        {

            if (message["t"] != null && message["d"] != null)   // Check if this message
            {
                string eventType = message["t"].ToString();     // Type response
                JObject eventData = message["d"] as JObject;    // Data into response

                if (eventType == "MESSAGE_CREATE")
                {
                    string author_id = eventData["author"]["id"].ToString(); // Get author
                    if (author_id == "470597237970436096")
                    {
                        Console.WriteLine(eventData["content"]);
                    }
                }
            }
        }

        public void Stop()
        {
            socket.Close();
        }

        public void Configure()
        {
            socket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            socket.OnMessage += (sender, e) =>
            {
                JObject message = JObject.Parse(e.Data);
                OnMessage(message);
            };

            socket.OnOpen += (sender, e) =>
            {
                string payload = $@"{{
                    ""op"": 2,
                    ""d"": {{
                        ""token"": ""{token}"",
                        ""properties"": {{
                            ""$os"": ""windows"",
                            ""$browser"": ""my_library"",
                            ""$device"": ""my_library""
                        }}
                    }}
                }}";

                socket.Send(payload);
                Console.WriteLine("Connect socket");
            };

            socket.OnError += (sender, e) =>
            {
                Console.WriteLine("Error: " + e.Message);
                Stop();
            };

            socket.OnClose += (sender, e) =>
            {
                Console.WriteLine("Closed: " + e.Reason);
            };


        }
    }
}
