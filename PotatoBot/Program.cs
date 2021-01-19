using Newtonsoft.Json;
using System;
using System.IO;

namespace PotatoBot
{
    class Program
    {
        public static DiscordBot Bot;
        static void Main(string[] args)
        {
            // get the config file with the bot token
            if(!File.Exists("config.json"))
            {
                Console.WriteLine("Could not find json.config");
                return;
            }

            var json = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<ClientConfiguration>(json);

            Bot = new DiscordBot(config);
            Bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
