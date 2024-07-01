using Newtonsoft.Json;

namespace FinalOpt.Models.AggregateValues
{
    public class SolveState
    {
        public Details details { get; set; }

        public List<string> latest_engine_activity { get; set; }

        public string solve_status { get; set; }
    }
}
