using System.Text.Json.Serialization;

namespace FinalOpt.Models.AggregateValues
{
    public class SolveParameters
    {
        [JsonPropertyName("oaas.logAttachmentName")]
        public string OaasLogAttachmentName { get; set; }

        [JsonPropertyName("oaas.logTailEnabled")]
        public string OaasLogTailEnabled { get; set; }
    }
}
