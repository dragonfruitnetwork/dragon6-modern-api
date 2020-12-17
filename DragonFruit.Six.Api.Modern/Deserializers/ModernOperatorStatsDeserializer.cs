// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.Api.Modern.Entities.Containers;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern.Deserializers
{
    public static class ModernOperatorStatsDeserializer
    {
        public static IReadOnlyDictionary<PlaylistType, ModernOperatorStatsContainer> DeserializeModernOperatorStatsFor(this JObject jObject, AccountInfo account)
        {
            var data = jObject?["platforms"]?[account.Platform.ModernName()]?["gameModes"];

            if (data == null)
            {
                return null;
            }

            var results = new Dictionary<PlaylistType, ModernOperatorStatsContainer>(4);

            foreach (var mode in Enum.GetValues(typeof(PlaylistType)).Cast<PlaylistType>())
            {
                if (data[mode.ToString().ToLower()] is JObject playlistData)
                {
                    var modeData = playlistData["teamRoles"]?.ToObject<ModernOperatorStatsContainer>();
                    results.Add(mode, modeData);
                }
            }

            return results;
        }
    }
}
