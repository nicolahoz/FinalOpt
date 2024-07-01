namespace FinalOpt.Models
{
    public class StorageModel
    {
        public List<BaseJobInfo> FinishedJobs { get; set; }
    }

    public class BaseJobInfo
    {
        public Guid JobId { get; set;}
        public DateTimeOffset CreatedAt { get; set; }
        public string JobName { get; set;}
        public string JobStatus { get; set;}
    } 
}
