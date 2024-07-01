using FinalOpt.Infraestructure.Helpers;
using FinalOpt.Infraestructure.Interfaces;
using FinalOpt.Models;
using Newtonsoft.Json;

namespace FinalOpt.Infraestructure.Services
{
    public class StorageService : IStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void SaveJob(BaseJobInfo job)
        {
            try
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "opl/storage.json");
                var fileContent = File.ReadAllText(filePath);

                var finishedJobs = JsonConvert.DeserializeObject<StorageModel>(fileContent);
                finishedJobs!.FinishedJobs.Add(job);

                var jobsString = JsonConvert.SerializeObject(finishedJobs);
                File.WriteAllText(filePath, jobsString);
            }
            catch (Exception e){
                throw new Exception("Error guardando job");            
            }
            
        }

        public Task<IndexViewModel> RetrieveData()
        {
            try
            {
                var dataPath = Path.Combine(_webHostEnvironment.WebRootPath, "opl/baseData.json");
                var dataContent = File.ReadAllText(dataPath);

                var data = JsonConvert.DeserializeObject<IndexViewModel>(dataContent);

                return Task.FromResult(data!);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data");
            }
        }

        public Task<StorageModel> RetrieveJobs()
        {
            try
            {
                var dataPath = Path.Combine(_webHostEnvironment.WebRootPath, "opl/storage.json");
                var dataContent = File.ReadAllText(dataPath);

                var data = JsonConvert.DeserializeObject<StorageModel>(dataContent);

                data!.FinishedJobs = data.FinishedJobs.OrderBy(e => e.CreatedAt).Reverse().ToList();

                return Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data");
            }
        }

        public Task<string> GetOplModel()
        {
            try
            {
                var dataPath = Path.Combine(_webHostEnvironment.WebRootPath, "opl/timetabling.mod");
                var dataContent = File.ReadAllText(dataPath);

                return Task.FromResult(dataContent);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data");
            }
        }

        public Task<string> GetExampleData()
        {
            try
            {
                var dataPath = Path.Combine(_webHostEnvironment.WebRootPath, "opl/data.dat");
                var dataContent = File.ReadAllText(dataPath);

                return Task.FromResult(dataContent);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data");
            }
        }
    }
}
