// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Extensions;
using DragonFruit.Six.Api.Modern.Services.Developer;

namespace DragonFruit.Six.Api.Modern.Tests
{
    public class Dragon6ApiTest
    {
        // these are provided by the dragon6 team for development purposes only.
        // abuse will result in their reset without warning.
        private const int ClientId = 4;
        private const string ClientSecret = "VzGgX1SjhpLRBL8bRRqsUoqWQmleOHrdpPxAERu3tg";

        private static ModernDragon6DeveloperClient _client;
        private static readonly List<AccountInfo> Accounts;

        static Dragon6ApiTest()
        {
            Accounts = new List<AccountInfo>();
        }

        protected ModernDragon6DeveloperClient Client => _client ??= new ModernDragon6DeveloperClient(ClientId, ClientSecret);

        protected AccountInfo GetAccountFor(string userId, Platform platform)
        {
            var account = Accounts.SingleOrDefault(x => x.Identifiers.Ubisoft == userId);

            if (account == default)
            {
                account = Client.GetUserByUbisoftId(userId, platform);
                Accounts.Add(account);
            }

            return account;
        }
    }
}
