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
        public IMessageChannel LogChannel { get; set; }
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

        public Task Client_Ready()
        {
            ulong id = 783720761650315274;
            LogChannel = _client.GetChannel(id) as IMessageChannel;
            return Task.CompletedTask;
        }

        public Task User_OnLeft(SocketGuildUser arg)
        {
            LogChannel.SendMessageAsync($"'{arg.Username}' left the Guild");
            Console.WriteLine($"'{arg.Username}' left the Guild");
            return Task.CompletedTask;
        }

        public Task User_OnJoined(SocketGuildUser arg)
        {
            var role = arg.Guild.Roles.FirstOrDefault(x => x.Name == "Member");
            arg.AddRoleAsync(role);
            LogChannel.SendMessageAsync($"User '{arg.Username}' was granted the role '{role.Name}'");
            Console.WriteLine($"User '{arg.Username}' was granted the role '{role.Name}'");

            return Task.CompletedTask;
        }
    }
}
