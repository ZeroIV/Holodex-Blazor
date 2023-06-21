using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HoloDex_UI.Data

{
    public class Video
    {
        [JsonProperty("id")]
        public string VideoId { get; internal set; }

        [JsonProperty("lang")]
        public string Language { get; internal set; }

        [JsonProperty("title")]
        public string Title { get; internal set; }

        [JsonProperty("type")]
        //[JsonConverter(typeof(StringEnumConverter))]
        //public VideoType VideoType { get; internal set; }
        public string VideoType { get; internal set; }

        [JsonProperty("topic_id")]
        public string Topic { get; internal set; }

        [JsonProperty("published_at")]
        public DateTime? PublishedAt { get; internal set; }

        [JsonProperty("available_at")]
        public DateTime AvailableAt { get; internal set; }

        [JsonProperty("duration")]
        private int duration { get; set; }

        public TimeSpan Duration { get { return TimeSpan.FromSeconds(duration); } }

        [JsonProperty("status")]
        public string Status { get; internal set; }

        [JsonProperty("start_scheduled")]
        public DateTime? ScheduledStart { get; internal set; }

        [JsonProperty("start_actual")]
        public DateTime? ActualStart { get; internal set; }

        [JsonProperty("end_actual")]
        public DateTime? ActualEnd { get; internal set; }

        [JsonProperty("live_viewers")]
        public int? LiveViewers { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }

        [JsonProperty("songcount")]
        public int? SongCount { get; internal set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; internal set; }

        [JsonProperty("channel")]
        public Channel Channel { get; internal set; }

        /*
        [JsonProperty("comments")]
        public IReadOnlyCollection<Comment> Comments { get; internal set; }

        [JsonProperty("clips")]
        public IReadOnlyCollection<Video> Clips { get; internal set; }

        [JsonProperty("sources")]
        public IReadOnlyCollection<Video> Sources { get; internal set; }

        [JsonProperty("refers")]
        public IReadOnlyCollection<Video> Refers { get; internal set; }

        [JsonProperty("simulcasts")]
        public IReadOnlyCollection<Video> Simulcasts { get; internal set; }

        [JsonProperty("mentions")]
        public IReadOnlyCollection<Channel> Mentions { get; internal set; }

        [JsonProperty("songs")]
        public IReadOnlyCollection<Song> Songs { get; internal set; }
        */
    }
}
