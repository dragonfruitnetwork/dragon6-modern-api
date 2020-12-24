// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Linq;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.Api.Modern.Extensions;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Modern.Tests.Stats
{
    [TestFixture]
    public class SeasonStatsTests : Dragon6ApiTest
    {
        [TestCase("ab1ff7ae-13e4-4a6a-9b03-317285f8057b", Platform.PC, true)]
        [TestCase("352655b3-2ff4-4713-9ad5-c10eb080e6f6", Platform.PC, false)]
        [TestCase("b598e9a9-f817-42fe-b381-45f918e5efa4", Platform.XB1, true)]
        [TestCase("a5e7c9c4-a225-4d8e-810f-0c529d829a34", Platform.PSN, false)]
        public void BasicSeasonStatsTest(string userId, Platform platform, bool expectResults)
        {
            var account = GetAccountFor(userId, platform);
            var seasonStats = Client.GetModernSeasonStatsFor(account);

            try
            {
                var latestSeason = seasonStats!.Casual.AsAny.Last();
                Assert.IsTrue(latestSeason.RoundsPlayed > 0 && latestSeason.Name != "summary");
            }
            catch (NullReferenceException) when (!expectResults)
            {
                Assert.Pass();
            }
        }
    }
}
