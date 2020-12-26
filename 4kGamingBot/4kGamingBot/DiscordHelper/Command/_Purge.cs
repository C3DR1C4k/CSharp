using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4kGamingBot.DiscordHelper.Command
{
    class _Purge : BaseCommand
    {
        public override void eventActionMethod(string[] args, DiscordSocketClient _client)
        {
            if (args.Count() == 2)
            {
                channel.SendMessageAsync(commandString + " " + args[1]);
                return;
            }
        }
    }
}
