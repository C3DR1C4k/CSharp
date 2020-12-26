﻿using Discord;
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

        public BaseCommand(string commandString, string description, int args)
        {
            this.commandString = commandString;
            this.description = description;
            this.args = args;
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
