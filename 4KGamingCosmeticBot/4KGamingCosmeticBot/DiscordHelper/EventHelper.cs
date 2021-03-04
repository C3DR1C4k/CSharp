using _4KGamingCosmeticBot.Enums;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4KGamingCosmeticBot.DiscordHelper
{
    class EventHelper
    {
        public IMessageChannel LogChannel { get; set; }
        DiscordSocketClient _client;
        public EventHelper(DiscordSocketClient _client)
        {
            this._client = _client;
        }

        public Task Client_Connected()
        {
            _client.SetStatusAsync(UserStatus.Online);
            _client.SetGameAsync(BotStatus.Designing.ToString());
            return Task.CompletedTask;
        }

        public Task Client_LoggedIn()
        {
            Console.WriteLine("Logged In");
            return Task.CompletedTask;
        }

        public Task Client_Ready()
        {
            ulong id = 783720761650315274;
            LogChannel = _client.GetChannel(id) as IMessageChannel;
            return Task.CompletedTask;
        }
    }
}
