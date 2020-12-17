// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Modern.Utils
{
    internal static class ValueUtils
    {
        public static void ApplyValue<T>(T? value, Action<T> setter) where T : struct
        {
            if (value.HasValue)
            {
                setter(value.Value);
            }
        }
    }
}
