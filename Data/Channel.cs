using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HoloDex_UI.Data
{
    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("english_name")]
        public string EngName { get; internal set; }

        [JsonProperty("type")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public string ChannelType { get; internal set; }

        [JsonProperty("org")]
        public string Org { get; internal set; }

        [JsonProperty("suborg")]
        private string Suborganization {  set { Group = value; } }

        [JsonProperty("group")]
        public string Group { get; internal set; }

        [JsonProperty("photo")]
        public string? PhotoUrl { get; internal set; }

        [JsonProperty("banner")]
        public string? BannerUrl { get; internal set; }

        [JsonProperty("twitter")]
        public string? TwitterHandle { get; internal set; }

        [JsonProperty("video_count")]
        public int? Videos { get; internal set; }

        [JsonProperty("subscriber_count")]
        public int? Subscribers { get; internal set; }

        [JsonProperty("view_count")]
        public int? Views { get; internal set; }

        [JsonProperty("clip_count")]
        public int? Clips { get; internal set; }

        [JsonProperty("lang")]
        public string? Lang { get; internal set; }

        [JsonProperty("published_at")]
        public DateTime? DatePublished { get; internal set; }

        [JsonProperty("inactive")]
        public bool IsInactive { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }
    }
}
