using Newtonsoft.Json;
using FinalOpt.Models.AggregateValues;

namespace FinalOpt.Models
{   
    public class NewJobResponse
    {
        public Entity entity { get; set; }

        public Metadata metadata { get; set; }
    }
}
