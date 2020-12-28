using _4kGamingBot.DiscordHelper;
using _4kGamingBot.DiscordHelper.Command;
using _4kGamingBot.Enums;
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
            _client.Ready += _events.Client_Ready;
            _client.UserLeft += _events.User_OnLeft;
            _client.UserJoined += _events.User_OnJoined;

            var token = File.ReadAllText("C:\\Token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            CommandHelper _commandHelper = new CommandHelper(_client);

            _Purge _Purge = new _Purge("!purge", "This is the description", 1, GuildRoles.Helper);
            _Help _Help = new _Help("!help", "This shows the user all commands that exist", 0, GuildRoles.Helper);
            _Help.CommandList.Add(_Purge);

            _commandHelper.AddCommand(_Purge);
            _commandHelper.AddCommand(_Help);

            await Task.Delay(-1);
        }
    }
}
