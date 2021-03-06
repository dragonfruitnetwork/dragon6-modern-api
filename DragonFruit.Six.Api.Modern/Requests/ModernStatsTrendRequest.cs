﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Modern.Enums;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public class ModernStatsTrendRequest : ModernStatsRequest
    {
        private TrendSpan? _trendSpan;

        protected override string RequestType => "trend";

        public ModernStatsTrendRequest(AccountInfo account)
            : base(account)
        {
        }

        public TrendSpan TrendSpan
        {
            get => _trendSpan ??= TrendSpan.Weekly;
            set => _trendSpan = value;
        }

        [QueryParameter("trendType")]
        protected string TrendType => TrendSpan switch
        {
            TrendSpan.Weekly => "weeks",

            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
