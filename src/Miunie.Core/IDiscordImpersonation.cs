﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Miunie.Core
{
    public interface IDiscordImpersonation
    {
        event EventHandler MessageReceived;
        void SubscribeForMessages();
        void UnsubscribeForMessages();

        IEnumerable<GuildView> GetAvailableGuilds();
        Task<IEnumerable<TextChannelView>> GetAvailableTextChannelsAsync(ulong guildId);
        Task SendTextToChannelAsync(string text, ulong id);
    }
}
