using Newtonsoft.Json;

namespace FinalOpt.Models.AggregateValues
{
    public class Entity
    {
        public DecisionOptimization? decision_optimization { get; set; }

        public Deployment? deployment { get; set; }

        public PlatformJob? platform_job { get; set; }
    }
}
