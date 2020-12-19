// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    public class ModernStatsContainer<T>
    {
        /// <summary>
        /// Gets an array of the stats for the specified type
        /// </summary>
        public T this[OperatorType type] => type switch
        {
            OperatorType.Independent => All,
            OperatorType.Attacker => Attackers,
            OperatorType.Defender => Defenders,

            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        [JsonProperty("all")]
        internal T All { get; set; }

        [JsonProperty("attacker")]
        internal T Attackers { get; set; }

        [JsonProperty("defender")]
        internal T Defenders { get; set; }
    }
}
