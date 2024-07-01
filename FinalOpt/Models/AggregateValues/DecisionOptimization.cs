

namespace FinalOpt.Models.AggregateValues
{
    public class DecisionOptimization
    {
        public List<InputData> input_data { get; set; }

        public List<OutputData> output_data { get; set; }

        public List<object> output_data_references { get; set; }

        public SolveParameters solve_parameters { get; set; }

        public SolveState solve_state { get; set; }

        public Status status { get; set; }
    }
}
