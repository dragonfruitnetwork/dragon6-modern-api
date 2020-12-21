// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ModernWeaponStats
    {
        [JsonProperty("weaponName")]
        public string Name { get; set; }

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        [JsonProperty("headshotAccuracy")]
        public float HeadshotAccuracy { get; set; }

        [JsonProperty("roundsWon")]
        public uint RoundsWon { get; set; }

        [JsonProperty("roundsLost")]
        public uint RoundsLost { get; set; }

        [JsonProperty("roundsPlayed")]
        public uint RoundsPlayed { get; set; }

        [JsonProperty("roundsWithAKill")]
        public float RoundsWithAKill { get; set; }

        [JsonProperty("roundsWithAMultiKill")]
        public float RoundsWithMultipleKills { get; set; }
    }
}
