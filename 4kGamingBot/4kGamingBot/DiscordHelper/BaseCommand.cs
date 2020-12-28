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
    class BaseCommand
    {
        public string commandString { get; set; }
        public string description { get; set; }
        public int args { get; set; }
        public GuildRoles permission { get; set; }

        public BaseCommand(string commandString, string description, int args, GuildRoles permission)
        {
            this.commandString = commandString;
            this.description = description;
            this.args = args;
            this.permission = permission;
        }
        public virtual async Task eventActionMethod(string[] args, DiscordSocketClient _client, IMessageChannel channel, SocketUser authorOfMessage)
        {
            if (args.Count() == 2)
            {
                await channel.SendMessageAsync($"User '{authorOfMessage.Username}' issued the '{commandString}' command with following args '{args[1]}'");
                await EventFired(args, _client, channel, authorOfMessage);
            }
        }

        public async Task EventFired(string[] args, DiscordSocketClient _client, IMessageChannel channel, SocketUser authorOfMessage)
        {
            Console.WriteLine($"User '{authorOfMessage.Username}' issued the '{commandString}' command with following args '{args[1]}'");
            await Task.CompletedTask;
        }
    }
}
