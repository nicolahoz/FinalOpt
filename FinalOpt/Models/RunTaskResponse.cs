using FinalOpt.Models.AggregateValues;

namespace FinalOpt.Models
{
    public class RunTaskResponse
    {
        public List<OutputData>? OutputData { get; set; }
        public SolveState? SolveState { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
