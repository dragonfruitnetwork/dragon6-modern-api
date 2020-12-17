// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net;
using System.Net.Http;
using DragonFruit.Six.API;
using DragonFruit.Six.API.Data.Tokens;

namespace DragonFruit.Six.Api.Modern
{
    /// <summary>
    /// An type of <see cref="Dragon6Client"/> with the data needed to get modern stats
    /// </summary>
    public abstract class ModernDragon6Client : Dragon6Client
    {
        /// <summary>
        /// Guid generated per-session for using Ubisoft's modern stats
        /// </summary>
        public string SessionId
        {
            get => Headers["Ubi-SessionId"];
            private set => Headers["Ubi-SessionId"] = value;
        }

        protected override void ApplyToken(TokenBase currentToken)
        {
            base.ApplyToken(currentToken);

            SessionId = currentToken.SessionId ?? Guid.NewGuid().ToString();
            Headers["Expiration"] = currentToken.Expiry.UtcDateTime.ToString("O");
        }

        protected override T ValidateAndProcess<T>(HttpResponseMessage response, HttpRequestMessage request)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.NoContent => default,

                _ => base.ValidateAndProcess<T>(response, request)
            };
        }
    }
}
