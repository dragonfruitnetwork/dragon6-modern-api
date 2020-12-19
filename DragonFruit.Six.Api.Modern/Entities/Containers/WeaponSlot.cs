// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities.Containers
{
    public class WeaponSlot
    {
        [JsonProperty("primaryWeapons")]
        public WeaponSlotInfo Primary { get; set; }

        [JsonProperty("secondaryWeapons")]
        public WeaponSlotInfo Secondary { get; set; }
    }

    public class WeaponSlotInfo
    {
        [JsonProperty("weaponTypes")]
        public IEnumerable<WeaponGroup> Weapons { get; set; }
    }
}
