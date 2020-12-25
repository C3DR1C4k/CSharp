using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4kGamingBot
{
    class Program
    {
        static DiscordSocketClient _client;
        private static async Task Main(string[] args)
        {
            _client = new DiscordSocketClient();

            _client.LoggedIn += Client_LoggedIn;
            _client.Connected += Client_Connected;

            var token = File.ReadAllText("C:\\Token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private static Task Client_Connected()
        {
            _client.SetStatusAsync(UserStatus.Online);
            _client.SetGameAsync("Administrating");
            return Task.CompletedTask;
        }

        private static Task Client_LoggedIn()
        {
            Console.WriteLine("Logged In");
            return Task.CompletedTask;
        }
    }
}
