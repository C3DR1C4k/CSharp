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

        private async Task Client_Command(SocketMessage arg)
        {
            if (arg.Content.First() == '!' && !arg.Author.IsBot)
            {
                string[] args = arg.Content.Split(' ');

                foreach (BaseCommand _command in _commandList)
                {
                    if (_command.commandString.ToLower() == args[0].ToLower())
                    {
                        await _command.eventActionMethod(args, _client, arg.Channel as IMessageChannel);
                    }
                }
            }
        }
    }
}
