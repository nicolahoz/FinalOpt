using FinalOpt.Models.AggregateValues;

namespace FinalOpt.Models
{
    public class IndexViewModel
    {
        public List<RequirementSet> Requirements { get; set; }
        public List<string> Disciplines { get; set; }
        public List<string> Teachers { get; set; }
        public List<string> Courses { get; set; }
    }
}
