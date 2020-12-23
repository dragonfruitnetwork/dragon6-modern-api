﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Data;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public class ModernMapStatsRequest : ModernStatsRequest
    {
        protected override string RequestType => "maps";

        public ModernMapStatsRequest(AccountInfo account)
            : base(account)
        {
        }
    }
}