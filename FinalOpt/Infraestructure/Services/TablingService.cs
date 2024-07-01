using FinalOpt.Infraestructure.Interfaces;
using FinalOpt.Models;
using FinalOpt.Models.AggregateValues;
using Newtonsoft.Json;

namespace FinalOpt.Infraestructure.Services
{
    public class TablingService : ITablingService
    {
        private readonly IHttpService _httpService;
        private readonly IStorageService _storageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TablingService(IHttpService httpService, IWebHostEnvironment webHostEnvironment, IStorageService storageService)
        {
            _httpService = httpService;
            _webHostEnvironment = webHostEnvironment;
            _storageService = storageService;
        }
       
        public async Task<RunTaskResponse> Run(DataToRunModel dataToRun)
        {
            string newJobResult = await _httpService.CreateJob(dataToRun);
            NewJobResponse newJob = JsonConvert.DeserializeObject<NewJobResponse>(newJobResult);          
            await Task.Delay(10000);
            GetJobInfoResponse jobInfo;
            string jobState;

            do
            {
                jobInfo = await GetJobInfo(newJob.metadata.id);             
                jobState = jobInfo.entity.decision_optimization.status.state;

                switch (jobState)
                {
                    case "completed":
                        _storageService.SaveJob(new BaseJobInfo { JobId = jobInfo.metadata.id, JobName = jobInfo.metadata.name, CreatedAt = jobInfo.metadata.created_at, JobStatus = jobState});
                        return new RunTaskResponse
                        {
                            OutputData = jobInfo.entity.decision_optimization.output_data,
                            SolveState = jobInfo.entity.decision_optimization.solve_state
                        };
                    case "running":
                        await Task.Delay(5000);
                        break;
                    case "failed":
                        _storageService.SaveJob(new BaseJobInfo { JobId = jobInfo.metadata.id, JobName = jobInfo.metadata.name, CreatedAt = jobInfo.metadata.created_at, JobStatus = jobState });
                        return new RunTaskResponse { ErrorMessage = "Error al ejecutar trabajo" };
                    default:
                        break;
                }
            } while (jobState == "running");

            return new RunTaskResponse { ErrorMessage = "Error al ejecutar trabajo " };
        }

        public async Task<GetJobInfoResponse> GetJobInfo(Guid jobId)
        {
            string getJobResult = await _httpService.GetJobInfo(jobId);
            return JsonConvert.DeserializeObject<GetJobInfoResponse>(getJobResult);
        }
        
    }
}
