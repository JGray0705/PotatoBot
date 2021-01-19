using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotatoBot.Attributes
{
    public abstract class BaseCustomAttribute : CheckBaseAttribute
    {
        public string CheckName;
        public string CheckMessage;

        public async override Task<bool> ExecuteCheckAsync(CommandContext ctx, bool help)
        {
            return await DoCheckAsync(ctx, help);
        }

        public abstract Task<bool> DoCheckAsync(CommandContext ctx, bool help);
    }
}
