using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4kGamingBot.DiscordHelper
{
    class CommandHelper
    {
        DiscordSocketClient _client;
        List<BaseCommand> _commandList = new List<BaseCommand>();

        public CommandHelper(DiscordSocketClient _client)
        {
            this._client = _client;

            _client.MessageReceived += Client_Command;
        }

        public void AddCommand(BaseCommand _command)
        {
            _commandList.Add(_command);
        }

        private Task Client_Command(SocketMessage arg)
        {
            if (arg.Content.First() == '!')
            {
                string[] args = arg.Content.Split(' ');

                foreach (BaseCommand _command in _commandList)
                {
                    if (_command.commandString.ToLower() == args[0].ToLower())
                    {
                        _command.channel = arg.Channel as IMessageChannel;
                        _command.eventActionMethod(args, _client);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
