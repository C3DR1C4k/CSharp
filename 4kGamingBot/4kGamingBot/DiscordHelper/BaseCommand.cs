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
        public BaseCommand(string commandString)
        {
            this.commandString = commandString;
        }
        public virtual async Task eventActionMethod(string[] args, DiscordSocketClient _client, IMessageChannel channel)
        {
            if (args.Count() == 2)
            {
                await channel.SendMessageAsync($"User issued the '{commandString}' command with following args '{args[1]}'");
            }
        }
    }
}
