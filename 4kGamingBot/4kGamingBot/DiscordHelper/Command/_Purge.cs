using Discord;
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
        public _Purge(string commandString) : base(commandString)
        {
        }

        public override async Task eventActionMethod(string[] args, DiscordSocketClient _client, IMessageChannel channel)
        {
            if (args.Count() == 2)
            {
                var messages = channel.GetMessagesAsync(Convert.ToInt32(args[1]) + 1).Flatten();

                foreach (var h in await messages.ToArrayAsync())
                {
                    await channel.DeleteMessageAsync(h);
                }
                await channel.SendMessageAsync($"'{commandString.Replace("!", "")}d' for '{args[1]}' messages");
            }
        }
    }
}
