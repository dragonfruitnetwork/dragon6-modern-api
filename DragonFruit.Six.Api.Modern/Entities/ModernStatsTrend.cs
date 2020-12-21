// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(JsonPathConverter))]
    public class ModernStatsTrend
    {
        [JsonProperty("statsPeriod")]
        public IEnumerable<string> StatsPeriods { get; set; }

        #region Matches/Rounds

        [JsonProperty("matchesPlayed")]
        public IEnumerable<int> MatchesPlayed { get; set; }

        [JsonProperty("roundsPlayed")]
        public IEnumerable<int> RoundsPlayed { get; set; }

        [JsonProperty("minutesPlayed")]
        public IEnumerable<int> MinutesPlayed { get; set; }

        [JsonProperty("matchesWon")]
        public IEnumerable<int> MatchesWon { get; set; }

        [JsonProperty("matchesLost")]
        public IEnumerable<int> MatchesLost { get; set; }

        [JsonProperty("roundsWon")]
        public IEnumerable<int> RoundsWon { get; set; }

        [JsonProperty("roundsLost")]
        public IEnumerable<int> RoundsLost { get; set; }

        #endregion

        #region Kills/Deaths

        [JsonProperty("kills")]
        public IEnumerable<int> Kills { get; set; }

        [JsonProperty("assists")]
        public IEnumerable<int> Assists { get; set; }

        [JsonProperty("death")]
        public IEnumerable<int> Deaths { get; set; }

        [JsonProperty("headshots")]
        public IEnumerable<int> Headshots { get; set; }

        [JsonProperty("meleeKills")]
        public IEnumerable<int> MeleeKills { get; set; }

        [JsonProperty("teamKills")]
        public IEnumerable<int> TeamKills { get; set; }

        [JsonProperty("openingKills")]
        public IEnumerable<int> OpeningKills { get; set; }

        [JsonProperty("openingDeaths")]
        public IEnumerable<int> OpeningDeaths { get; set; }

        [JsonProperty("trades")]
        public IEnumerable<int> Trades { get; set; }

        [JsonProperty("openingKillTrades")]
        public IEnumerable<int> OpeningKillTrades { get; set; }

        [JsonProperty("openingDeathTrades")]
        public IEnumerable<int> OpeningDeathTrades { get; set; }

        [JsonProperty("revives")]
        public IEnumerable<int> Revives { get; set; }

        #endregion

        #region Ratios

        [JsonProperty("winLossRatio")]
        public IEnumerable<float> Wl { get; set; }

        [JsonProperty("killDeathRatio")]
        public IEnumerable<float> Kd { get; set; }

        [JsonProperty("headshotAccuracy")]
        public IEnumerable<float> HeadshotAccuracy { get; set; }

        [JsonProperty("killsPerRound")]
        public IEnumerable<float> KillsPerRound { get; set; }

        #endregion

        #region Rounds (Extended Info)

        [JsonProperty("roundsWithAKill")]
        public IEnumerable<float> RoundsWithAKill { get; set; }

        [JsonProperty("roundsWithMultiKill")]
        public IEnumerable<float> RoundsWithMultiKill { get; set; }

        [JsonProperty("roundsWithOpeningKill")]
        public IEnumerable<float> RoundsWithOpeningKill { get; set; }

        [JsonProperty("roundsWithOpeningDeath")]
        public IEnumerable<float> RoundsWithOpeningDeath { get; set; }

        [JsonProperty("roundsWithKOST")]
        public IEnumerable<float> RoundsWithKost { get; set; }

        [JsonProperty("roundsSurvived")]
        public IEnumerable<float> RoundsSurvived { get; set; }

        [JsonProperty("roundsWithAnAce")]
        public IEnumerable<float> RoundsWithAnAce { get; set; }

        [JsonProperty("roundsWithClutch")]
        public IEnumerable<int> RoundsWithClutch { get; set; }

        #endregion

        #region Time/Distance

        [JsonProperty("timeAlivePerMatch")]
        public IEnumerable<float> TimeAlivePerMatch { get; set; }

        [JsonProperty("timeDeadPerMatch")]
        public IEnumerable<float> TimeDeadPerMatch { get; set; }

        [JsonProperty("distanceTravelled")]
        public IEnumerable<int> DistanceTravelled { get; set; }

        [JsonProperty("distancePerRound")]
        public IEnumerable<float> DistancePerRound { get; set; }

        #endregion

        public IEnumerable<ModernStatsPeriod<T>> Collate<T>(IEnumerable<T> data)
        {
            return StatsPeriods.Zip(data, (period, values) => new ModernStatsPeriod<T>(period, values));
        }
    }
}
