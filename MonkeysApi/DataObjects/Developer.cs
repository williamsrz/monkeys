using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;

namespace MonkeysApi.DataObjects
{
    public class Developer : EntityData
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("email")]
        public object Email
        {
            get;
            set;
        }

        [JsonProperty("city")]
        public string City
        {
            get;
            set;
        }

        [JsonProperty("state")]
        public string State
        {
            get;
            set;
        }
    }
}