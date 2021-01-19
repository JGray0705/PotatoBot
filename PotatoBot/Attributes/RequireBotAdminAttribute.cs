using DSharpPlus.CommandsNext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PotatoBot.Attributes
{
    public class RequireBotAdminAttribute : BaseCustomAttribute
    {
        public RequireBotAdminAttribute()
        {
            CheckName = "Bot Admin Required";
            CheckMessage = "You must be an admin of the bot to use this command";
        }

        public async override Task<bool> DoCheckAsync(CommandContext ctx, bool help)
        {
            return Program.Bot.BotAdmins.Contains(ctx.Member.Id);
        }
    }
}
