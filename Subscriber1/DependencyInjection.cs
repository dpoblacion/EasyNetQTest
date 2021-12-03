using EasyNetQ;
using Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Subscriber1
{
    public static class DependencyInjection
    {
        public static void AddEventBus(this IServiceCollection services)
        {
            // TODO: services.RegisterEasyNetQ(configuration.GetConnectionString("EasyNetQ"));
            services.RegisterEasyNetQ("host=localhost");
            //services.AddTransient<IIntegrationEventDispatcher, IntegrationEventDispatcher>();
            //services.AddTransient<IIntegrationEventHandler<BonusCreatedEvent>, BonusCreatedEventHandler>();
            //services.AddTransient<IBonusAccountEventPublisher, BonusAccountEventPublisher>();
        }

        public static void UseEventBus(this IApplicationBuilder app)
        {
            var container = app.ApplicationServices;
            var bus = container.GetRequiredService<IBus>();
            
            bus.PubSub.Subscribe<TextMessage>("subscriber1", Messages.Handler.HandleTextMessage);
        }
    }
}
