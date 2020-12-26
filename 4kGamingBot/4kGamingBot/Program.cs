using _4kGamingBot.DiscordHelper;
using _4kGamingBot.DiscordHelper.Command;
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

            EventHelper _events = new EventHelper(_client);

            _client.LoggedIn += _events.Client_LoggedIn;
            _client.Connected += _events.Client_Connected;

            var token = File.ReadAllText("C:\\Token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            CommandHelper _commandHelper = new CommandHelper(_client);

            _Purge _Purge = new _Purge();

            _Purge.commandString = "!purge";

            _commandHelper.AddCommand(_Purge);

            await Task.Delay(-1);
        }
    }
}
