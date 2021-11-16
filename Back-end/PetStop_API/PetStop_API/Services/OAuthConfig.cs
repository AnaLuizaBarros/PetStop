using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace PetStop_API.Services
{
    public class OAuthConfig
    {
        public string ClientId { get; set; }
        public string AppSecret { get; set; }   
        public string RedirectUri { get; set; }   
        public string Version { get; set; }   

        public OAuthConfig()
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            this.ClientId = jAppSettings["oauth"]["client_id"].ToString();
            this.AppSecret = jAppSettings["oauth"]["app_secret"].ToString();
            this.RedirectUri = jAppSettings["oauth"]["redirect_uri"].ToString();
            this.RedirectUri = jAppSettings["oauth"]["version"].ToString();
        }
    }
}
