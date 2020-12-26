using _4kGamingBot.Enums;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4kGamingBot.DiscordHelper
{
    class EventHelper
    {
        DiscordSocketClient _client;
        public EventHelper(DiscordSocketClient _client)
        {
            this._client = _client;
        }

        public Task Client_Connected()
        {
            _client.SetStatusAsync(UserStatus.Online);
            _client.SetGameAsync(BotStatus.Developing.ToString());
            return Task.CompletedTask;
        }

        public Task Client_LoggedIn()
        {
            Console.WriteLine("Logged In");
            return Task.CompletedTask;
        }
    }
}
