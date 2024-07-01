using FinalOpt.Models;
using FinalOpt.Models.AggregateValues;

namespace FinalOpt.Infraestructure.Interfaces
{
    public interface ITablingService
    {
        Task<RunTaskResponse> Run(DataToRunModel dataToRun);
        Task<GetJobInfoResponse> GetJobInfo(Guid jobId);
    }
}
