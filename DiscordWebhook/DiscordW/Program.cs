using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiscordW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Token = "your Token";


            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new
                HttpRequestMessage(HttpMethod.Post, Token);

                string json = JsonConvert.SerializeObject(new
                {
                    embeds = new object[]
                    {
                        new
                        {
                            title = "Title",
                            description = "Description",
                            color = 1127128,
                        },
                        new
                        {
                            fields = new object[]
                            {
                                new {
                                    name = "Cat",
                                    value = "Hi! :wave:",
                                    inline = true
                                },
                                new {
                                    name = "Dog",
                                    value = "hello!",
                                    inline = true
                                },
                                new {
                                    name = "Cat",
                                    value = "wanna play? join to voice channel!"
                                },
                                new {
                                    name = "Dog",
                                    value = "yay"
                                }
                            }
                        }
                    }
                });

                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.SendAsync(requestMessage).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine(response);
                }
            }


            Console.ReadKey();
        }

    }
}