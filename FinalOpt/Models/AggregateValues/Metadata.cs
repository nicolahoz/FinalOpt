using Newtonsoft.Json;

namespace FinalOpt.Models.AggregateValues
{
    public class Metadata
    {
        [JsonProperty("created_at")]
        public DateTimeOffset created_at { get; set; }

        [JsonProperty("id")]
        public Guid id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("space_id")]
        public Guid space_id { get; set; }
    }
}
