using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tweetbook.External.Contracts
{
    

    public class FacebookUserInfoResult
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("picture")]
        public FacebookPicture Picture { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
        public string Email { get; set; }
    }

    public  class FacebookPicture
    {
        [JsonProperty("data")]
        public FacebookPictureData Data { get; set; }
    }

    public  class FacebookPictureData
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("is_silhouette")]
        public bool IsSilhouette { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }
}

