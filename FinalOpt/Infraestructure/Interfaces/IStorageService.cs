using FinalOpt.Models;

namespace FinalOpt.Infraestructure.Interfaces
{
    public interface IStorageService
    {
        Task<string> GetOplModel();
        Task<string> GetExampleData();
        Task<IndexViewModel> RetrieveData();
        Task<StorageModel> RetrieveJobs();
        public void SaveJob(BaseJobInfo job);
    }
}
