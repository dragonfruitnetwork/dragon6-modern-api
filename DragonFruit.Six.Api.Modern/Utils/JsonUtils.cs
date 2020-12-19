// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Modern.Entities;
using DragonFruit.Six.Api.Modern.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern.Utils
{
    internal static class JsonUtils
    {
        /// <summary>
        /// Abstracts a ubisoft stats response to present the data required
        /// </summary>
        public static Dictionary<PlaylistType, ModernStatsContainer<T>> ProcessData<T>(this JObject source, ModernStatsRequest request, Func<JObject, ModernStatsContainer<T>> customProcessor = null)
        {
            var data = source?["platforms"]?[request.Account.Platform.ModernName()]?["gameModes"];

            if (data == null)
            {
                return null;
            }

            var results = new Dictionary<PlaylistType, ModernStatsContainer<T>>(4);

            foreach (var mode in Enum.GetValues(typeof(PlaylistType)).Cast<PlaylistType>())
            {
                if (data[mode.ToString().ToLower()]?["teamRoles"] is JObject playlistData)
                {
                    results.Add(mode, customProcessor != null ? customProcessor(playlistData) : playlistData.ToObject<ModernStatsContainer<T>>());
                }
            }

            return results;
        }
    }
}
