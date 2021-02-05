﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Containers;
using DragonFruit.Six.Api.Modern.Entities;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Requests;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern.Extensions
{
    public static class ModernStatsTrendExtensions
    {
        public static ModernModeStatsContainer<IEnumerable<ModernStatsTrend>> GetModernStatsTrendFor<T>(this T client, AccountInfo account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.Independent, TrendSpan trendSpan = TrendSpan.Weekly, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
            where T : ModernDragon6Client
        {
            var request = new ModernStatsTrendRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType,
                TrendSpan = trendSpan
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.Perform<JObject>(request)
                         .ProcessData<IEnumerable<ModernStatsTrend>>(request, client);
        }
    }
}
