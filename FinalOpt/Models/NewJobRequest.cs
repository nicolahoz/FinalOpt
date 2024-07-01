using FinalOpt.Models.AggregateValues;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FinalOpt.Models
{
    public class NewJobRequest
    {
        public string name { get; set; }

        public string space_id { get; set; }

        public Deployment deployment { get; set; }

        public DecisionOptimization decision_optimization { get; set; }
    }
}
