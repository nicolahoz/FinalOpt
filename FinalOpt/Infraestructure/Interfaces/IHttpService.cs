using FinalOpt.Models;
using FinalOpt.Models.AggregateValues;

namespace FinalOpt.Infraestructure.Interfaces
{
    public interface IHttpService
    {
        Task<TokenResponse> GetToken();
        Task<string> CreateJob(DataToRunModel dataToRun);
        Task<string> GetJobInfo(Guid jobId);
    }
}
