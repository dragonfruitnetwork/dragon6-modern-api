﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Containers
{
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(JsonPathConverter))]
    public class ModernModeStatsContainer<T>
    {
        [JsonIgnore]
        public ModernRoleStatsContainer<T> this[PlaylistType type] => type switch
        {
            PlaylistType.All => AllModes,
            PlaylistType.Casual => Casual,
            PlaylistType.Ranked => Ranked,
            PlaylistType.Unranked => Unranked,

            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        [JsonProperty("gameModes.all")]
        public ModernRoleStatsContainer<T> AllModes { get; set; }

        [JsonProperty("gameModes.casual")]
        public ModernRoleStatsContainer<T> Casual { get; set; }

        [JsonProperty("gameModes.ranked")]
        public ModernRoleStatsContainer<T> Ranked { get; set; }

        [JsonProperty("gameModes.unranked")]
        public ModernRoleStatsContainer<T> Unranked { get; set; }
    }
}
