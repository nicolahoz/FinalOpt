using System.Text.Json.Serialization;

namespace FinalOpt.Models.AggregateValues
{
    public class InputData
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("content")]
        public string content { get; set; }
    }
}
