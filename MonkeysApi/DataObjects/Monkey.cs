using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;

namespace MonkeysApi.DataObjects
{
    public class Monkey : EntityData
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("miniBio")]
        public string MiniBio
        {
            get;
            set;
        }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get;
            set;
        }

        [JsonProperty("twitter")]
        public string Twitter
        {
            get;
            set;
        }
    }
}