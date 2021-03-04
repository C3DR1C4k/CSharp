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
    class BaseCommand
    {
        public string commandString { get; set; }
        public string description { get; set; }
        public int args { get; set; }
        public GuildRoles permission { get; set; }

        public Func<string[], DiscordSocketClient, IMessageChannel, SocketUser, BaseCommand, Task> eventToHandle { get; set; }

        public BaseCommand(string commandString, string description, int args, GuildRoles permission, Func<string[], DiscordSocketClient, IMessageChannel, SocketUser, BaseCommand, Task> eventToHandle)
        {
            this.commandString = commandString;
            this.description = description;
            this.args = args;
            this.permission = permission;
            this.eventToHandle = eventToHandle;
        }
    }
}
