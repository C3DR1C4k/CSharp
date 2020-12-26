﻿using Discord;
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
        public List<BaseCommand> CommandList { get; set; }
        public _Help(string commandString, string description, int args) : base(commandString, description, args) { }
        
        public override async Task eventActionMethod(string[] args, DiscordSocketClient _client, IMessageChannel channel)
        {
            CommandList = new List<BaseCommand>();
            CommandList.Add(new _Help("!TestHelp", "This is the description", 0));
            CommandList.Add(new _Purge("!purge", "This is the description", 2));

            string OutPutString = String.Empty;
            foreach (var command in CommandList)
            {
                OutPutString += $"{command.commandString}   |   {command.args} arguments to pass    |   {command.description} \n";
            }
            await channel.SendMessageAsync(OutPutString);

        }
    }
}