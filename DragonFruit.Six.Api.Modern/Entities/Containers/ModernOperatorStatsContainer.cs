// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities.Containers
{
    public class ModernOperatorStatsContainer
    {
        private IEnumerable<ModernOperatorStats> _attackers;
        private IEnumerable<ModernOperatorStats> _defenders;

        [JsonProperty("attacker")]
        public IEnumerable<ModernOperatorStats> Attackers
        {
            get => _attackers ??= Array.Empty<ModernOperatorStats>();
            set => _attackers = value;
        }

        [JsonProperty("defender")]
        public IEnumerable<ModernOperatorStats> Defenders
        {
            get => _defenders ??= Array.Empty<ModernOperatorStats>();
            set => _defenders = value;
        }
    }
}
