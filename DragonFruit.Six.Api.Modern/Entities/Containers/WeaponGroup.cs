// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities.Containers
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WeaponGroup
    {
        [JsonProperty("weaponType")]
        public string Type { get; set; }

        [JsonProperty("weapons")]
        public IEnumerable<ModernWeaponStats> Weapons { get; set; }
    }
}
