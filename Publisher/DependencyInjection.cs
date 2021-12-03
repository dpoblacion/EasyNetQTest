using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Publisher
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            // TODO: services.RegisterEasyNetQ(configuration.GetConnectionString("EasyNetQ"));
            services.RegisterEasyNetQ("host=localhost");
            //services.AddTransient<IIntegrationEventDispatcher, IntegrationEventDispatcher>();
            //services.AddTransient<IIntegrationEventHandler<BonusCreatedEvent>, BonusCreatedEventHandler>();
            //services.AddTransient<IBonusAccountEventPublisher, BonusAccountEventPublisher>();

            return services;
        }

        public static IApplicationBuilder UseEventBus(this IApplicationBuilder app)
        {
            //var container = app.ApplicationServices;
            //var bus = container.GetRequiredService<IBus>();
            //var dispatcher = container.GetRequiredService<IIntegrationEventDispatcher>();

            //bus.Subscribe<BonusCreatedEvent>(
            //    typeof(BonusCreatedEventHandler).FullName,
            //    @event => dispatcher.Dispatch(@event));

            return app;
        }
    }
}
