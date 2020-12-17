﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.Api.Modern.Utils
{
    internal static class PlatformUtils
    {
        public static string ModernName(this Platform platform) => platform switch
        {
            Platform.PC => "PC",
            Platform.PSN => "PS4",
            Platform.XB1 => "XONE",

            _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null)
        };
    }
}