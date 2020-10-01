using System;
using System.Collections.Generic;
using System.Text;

namespace PotatoBot
{
    public class ClientConfiguration
    {
        /// <summary>
        /// Discord API token for main bot
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Discord API token for testing bot
        /// </summary>
        public string TestToken { get; set; }
        /// <summary>
        /// Discord Channel ID for log channel
        /// </summary>
        public ulong LogChannel { get; set; }
        /// <summary>
        /// Array of Discord user IDs for access to commands that control the bot
        /// </summary>
        public ulong[] BotAdmins { get; set; }
    }
}
