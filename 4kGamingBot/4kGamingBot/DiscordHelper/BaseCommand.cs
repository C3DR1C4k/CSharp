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
        public IMessageChannel channel { get; set; }
        public virtual void eventActionMethod(string[] args, DiscordSocketClient _client)
        {
        }
    }
}
