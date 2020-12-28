using _4kGamingBot.Enums;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4kGamingBot.DiscordHelper.Command
{
    class _Help : BaseCommand
    {
        public List<BaseCommand> CommandList = new List<BaseCommand>();
        public _Help(string commandString, string description, int args, GuildRoles permission) : base(commandString, description, args, permission) { }
        
        public override async Task eventActionMethod(string[] args, DiscordSocketClient _client, IMessageChannel channel, SocketUser authorOfMessage)
        {
            string OutPutString = String.Empty;
            foreach (var command in CommandList)
            {
                OutPutString += $"{command.commandString}   |   {command.args} arguments to pass    |   {command.description}   |   Role needed '{permission.ToString()}' \n";
            }
            await channel.SendMessageAsync(OutPutString);

            base.EventFired(args, _client, channel, authorOfMessage);
        }
    }
}
