using FinalOpt.Models.AggregateValues;
using Newtonsoft.Json;

namespace FinalOpt.Models
{
    public class GetJobInfoResponse
    {
        public Entity? entity { get; set; }

        public Metadata? metadata { get; set; }
    }


}
