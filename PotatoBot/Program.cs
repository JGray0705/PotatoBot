using Newtonsoft.Json;
using System;
using System.IO;

namespace PotatoBot
{
    class Program
    {
        
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

            var bot = new DiscordBot(config);
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
