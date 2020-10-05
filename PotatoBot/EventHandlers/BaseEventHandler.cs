using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PotatoBot.EventHandlers
{
    public class BaseEventHandler
    {
        public static DiscordChannel LogChannel;

        public static void SetUpEvents(DiscordClient client, DiscordChannel channel)
        {
            LogChannel = channel;
            var handlers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(BaseEventHandler))); // get all classes that extend this class
            foreach(var handler in handlers)
            {
                var methods = handler.GetTypeInfo().DeclaredMethods; // get the methods in each of these classes and add them as handlers to the proper events on the client
                foreach(var method in methods)
                {
                    var name = method.Name.Substring(7); // strip "Client_" from the name to match event name
                    var eventInfo = client.GetType().GetEvent(name);
                    var del = Delegate.CreateDelegate(eventInfo.EventHandlerType, method);
                    eventInfo.AddEventHandler(client, del);
                    client.Logger.LogInformation("Subscribed to event: " + method.Name);
                }
            }
        }
    }
}
