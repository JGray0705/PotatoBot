using DSharpPlus;
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
        public static void AddEventListeners(DiscordClient client)
        {
            var events = client.GetType().GetEvents();
            var handlers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(BaseEventHandler)));
            foreach(var handler in handlers)
            {
                var methods = handler.GetTypeInfo().DeclaredMethods;
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
