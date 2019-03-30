using Miunie.Configuration;
using Miunie.Core;
using Miunie.Core.Storage;
using Miunie.Core.Language;
using Miunie.Core.Infrastructure;
using Miunie.Storage;
using Miunie.Discord;
using Miunie.Discord.Configuration;
using Miunie.Discord.Convertors;
using Microsoft.Extensions.DependencyInjection;
using System;
using Miunie.Core.Logging;
using Miunie.Core.Providers;
using Miunie.Logger;

namespace Miunie.ConsoleApp
{
    public static class InversionOfControl
    {
        private static ServiceProvider _provider;

        public static ServiceProvider Provider => GetOrInitProvider();

        private static ServiceProvider GetOrInitProvider()
        {
            if(_provider is null)
            {
                InitializeProvider();
            }

            return _provider;
        }

        private static void InitializeProvider()
            => _provider = new ServiceCollection()
                .AddSingleton<EntityConvertor>()
                .AddSingleton<ProfileService>()
                .AddTransient<ILanguageResources, LanguageResources>()
                .AddSingleton<DSharpPlusDiscord>()
                .AddSingleton<IDiscord>(s =>
                    s.GetRequiredService<DSharpPlusDiscord>())
                .AddSingleton<IDiscordMessages>(s =>
                    s.GetRequiredService<DSharpPlusDiscord>())
                .AddSingleton<IBotConfiguration, BotConfiguration>()
                .AddSingleton<IConfiguration, ConfigManager>()
                .AddSingleton<IPersistentStorage, JsonPersistentStorage>()
                .AddSingleton<Random>()
                .AddSingleton<IMiunieUserProvider, MiunieUserProvider>()
                .AddTransient<IUserReputationProvider, UserReputationProvider>()
                .AddTransient<IDateTime, SystemDateTime>()
                .AddSingleton<ILogger, ConsoleLogger>()
                .BuildServiceProvider();
    }
}
