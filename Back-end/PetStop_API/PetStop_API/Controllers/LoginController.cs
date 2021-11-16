using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetStop_API.Models;
using PetStop_API.Records;
using PetStop_API.Services;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace PetStop_API.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("/api/login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromBody] Login login)
        {
            try
            {
                using var db = new Data.PetStopContext();
                var usuario =
                    login.tipo == 0 ?
                        db.Doador.Where(p => p.email == login.email && p.senha == login.senha).Take(1).ToList<dynamic>() :
                        db.Adotante.Where(p => p.email == login.email && p.senha == login.senha).Take(1).ToList<dynamic>();
                if (usuario.Count > 0)
                    return Ok(usuario[0]);
                else return Ok(login.tipo == 0 ? new Doador() : new Adotante());
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpPost]
        [Route("/api/login/google")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult LoginGoogle()
        {
            try
            {
                string clientId = "745093173799-o3trovdiq3372fhtbv70dhgt77c6i1qa.apps.googleusercontent.com";
                string secretId = "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";

                string[] scope = { "https://www.googleapis.com/auth/gmail.readonly" };

                var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = clientId,
                        ClientSecret = secretId,
                    }, scope, "user", CancellationToken.None).Result;

                //var credentials_2 = GoogleWebAuthorizationBroker.ReauthorizeAsync(credentials, CancellationToken.None);

                //if (credentials.Token.IsExpired(SystemClock.Default))
                //{
                //    credentials.RefreshTokenAsync(CancellationToken.None).Wait();
                //}

                return Ok(credentials.Token.AccessToken.ToString());
            }
            catch (Exception ex) { return Unauthorized(); }
        }

        [HttpGet]
        [Route("/api/login/facebook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult LoginFacebook(string code = "")
        {
            try
            {
                var oauthConfig = new OAuthConfig();
                if (String.IsNullOrEmpty(code))
                {
                    return Redirect($"https://graph.facebook.com/oauth/access_token?client_id={oauthConfig.ClientId}&client_secret={oauthConfig.AppSecret}&grant_type=client_credentials");
                }

                //https://graph.facebook.com/v12.0/oauth/access_token?client_id={oauthConfig.ClientId}&redirect_uri={oauthConfig.RedirectUri}&client_secret={oauthConfig.AppSecret}&code={code}

                string json = String.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://graph.facebook.com/{oauthConfig.Version}/oauth/access_token?client_id={oauthConfig.ClientId}&client_secret={oauthConfig.AppSecret}&code={code}");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream);

                    json = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }

                var oauthToken = JsonConvert.DeserializeObject<OAuthToken>(json);

                return Redirect($"https://graph.facebook.com/me?filds=email,name,gender,birthday,picture.width(320).height(320)&access_token={oauthToken.access_token}");
            }
            catch (Exception ex) { return Unauthorized(); }
        }
    }
}