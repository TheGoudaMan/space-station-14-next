/*using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Robust.Server.Player;
//using Content.Server.Interfaces;

namespace Content.Server.Discord
{
    public sealed class DiscordOAuth
    {
        private const string DiscordTokenUrl = "https://discord.com/api/oauth2/token";
        private const string DiscordUserUrl = "https://discord.com/api/users/@me";
        private const string ClientId = "YOUR_CLIENT_ID";
        private const string ClientSecret = "YOUR_CLIENT_SECRET";
        private const string RedirectUri = "YOUR_REDIRECT_URI";

        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string?> AuthenticateUser(string authCode)
        {
            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", ClientSecret),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", authCode),
                new KeyValuePair<string, string>("redirect_uri", RedirectUri)
            });

            var response = await _httpClient.PostAsync(DiscordTokenUrl, parameters);
            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadAsStringAsync();
            var tokenData = JsonSerializer.Deserialize<DiscordTokenResponse>(responseBody);

            return tokenData?.AccessToken;
        }

        public async Task<DiscordUser?> GetUserInfo(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetAsync(DiscordUserUrl);
            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DiscordUser>(responseBody);
        }
    }

    public class DiscordTokenResponse
    {
        public string AccessToken { get; set; } = "";
    }

    public class DiscordUser
    {
        public string Id { get; set; } = "";
        public string Username { get; set; } = "";
        public string Discriminator { get; set; } = "";
        public string Avatar { get; set; } = "";
    }
}
*/