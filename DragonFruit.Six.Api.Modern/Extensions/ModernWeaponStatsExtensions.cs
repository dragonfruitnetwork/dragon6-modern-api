// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DragonFruit.Six.API;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.Api.Modern.Entities;
using DragonFruit.Six.Api.Modern.Entities.Containers;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Requests;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern.Extensions
{
    public static class ModernWeaponStatsExtensions
    {
        public static IReadOnlyDictionary<PlaylistType, ModernStatsContainer<WeaponSlot>> GetModernWeaponStatsFor<T>(this T client, AccountInfo account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.Independent, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
            where T : Dragon6Client
        {
            var request = new ModernWeaponStatsRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.Perform<JObject>(request)
                         .ProcessData(request, j => new ModernStatsContainer<WeaponSlot>
                         {
                             All = CreateWeaponSlotFor(OperatorType.Independent, j),
                             Attackers = CreateWeaponSlotFor(OperatorType.Attacker, j),
                             Defenders = CreateWeaponSlotFor(OperatorType.Defender, j)
                         });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static WeaponSlot CreateWeaponSlotFor(OperatorType type, JObject source)
        {
            var key = type switch
            {
                OperatorType.Independent => "all",
                _ => type.ToString().ToLower()
            };

            return source[key]?["weaponSlots"]?.ToObject<WeaponSlot>();
        }
    }
}
