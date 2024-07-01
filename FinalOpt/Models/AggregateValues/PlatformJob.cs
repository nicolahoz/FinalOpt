using Newtonsoft.Json;

namespace FinalOpt.Models.AggregateValues
{
    public class PlatformJob
    {
        public Guid job_id { get; set; }

        public Guid run_id { get; set; }
    }
}
