using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Embed_Webhook
{
    class Program
    {
        static void SendWebhook()
        {
            string token = "<Token>";

            WebRequest wr = (HttpWebRequest)WebRequest.Create(token);

            wr.ContentType = "application/json";

            wr.Method = "POST";

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    username = "Test Username",
                    embeds = new[]
                    {
                        new {
                            description = "Test desc.",
                            title = "Test Title",
                            color = "8464385",
                            
                            footer = new {
                                icon_url = "",
                                text = "footer text"
                            },
                        }
                    }
                });

                sw.Write(json);
            }

            var response = (HttpWebResponse)wr.GetResponse();
        }
    }
}
