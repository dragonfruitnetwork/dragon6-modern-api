// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Services.Developer;
using DragonFruit.Six.Api.Services.Developer.Auth;
using DragonFruit.Six.Api.Tokens;

namespace DragonFruit.Six.Api.Modern.Developer
{
    /// <summary>
    /// Class lifted from <see cref="Dragon6DeveloperClient"/>
    /// </summary>
    public class ModernDragon6DeveloperClient : ModernDragon6Client
    {
        private readonly uint _appId;
        private readonly string _appSecret;
        private readonly object _lock;

        private TokenBase _sessionAuthorization;

        public ModernDragon6DeveloperClient(uint appId, string appSecret)
        {
            _appId = appId;
            _appSecret = appSecret;

            _lock = new object();
        }

        public T Perform<T>(DeveloperApiRequest requestData) where T : class
        {
            lock (_lock)
            {
                CheckAuthHeader(requestData);
            }

            return DirectPerform<T>(requestData);
        }

        protected override TokenBase GetToken() => Perform<Dragon6Token>(new DeveloperTokenRequest());

        private void CheckAuthHeader(DeveloperApiRequest request)
        {
            if ((_sessionAuthorization?.Expired).GetValueOrDefault(true))
            {
                // we don't want this method running if we're getting the token so use the directperform method
                _sessionAuthorization = DirectPerform<DeveloperTokenResponse>(new DeveloperSessionRequest(_appId, _appSecret));
            }

            request.WithAuthHeader($"Bearer {_sessionAuthorization!.Token}");
        }
    }
}
