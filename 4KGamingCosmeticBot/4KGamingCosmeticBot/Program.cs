using _4KGamingCosmeticBot.DiscordHelper;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4KGamingCosmeticBot
{
    class Program
    {
        static DiscordSocketClient _client;
        private static async Task Main(string[] args)
        {
            _client = new DiscordSocketClient();

            var token = File.ReadAllText("C:\\TokenCosmetic.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            EventHelper _events = new EventHelper(_client);

            _client.LoggedIn += _events.Client_LoggedIn;
            _client.Connected += _events.Client_Connected;
            _client.Ready += _events.Client_Ready;

            await Task.Delay(-1);
        }
    }
}
