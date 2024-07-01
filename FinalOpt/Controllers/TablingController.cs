using FinalOpt.Infraestructure.Interfaces;
using FinalOpt.Models;
using FinalOpt.Models.AggregateValues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinalOpt.Controllers
{
    public class TablingController : Controller
    {
        private readonly ITablingService _tablingService;
        private readonly IStorageService _storageService;

        public TablingController(ITablingService tablingService, IStorageService storageService)
        {
            _tablingService = tablingService;
            _storageService = storageService;
        }

        public async Task<IActionResult> SolveModel()
        {
            var model = await _storageService.RetrieveData();

            return View("SolveModelView", model: model);
        }

        public async Task<IActionResult> Run(DataToRunModel dataToRun)
        {
            var response = await _tablingService.Run(dataToRun);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetPartialView(SolutionModel model)
        {
            return PartialView("SolutionView", model: model);
        }

        public async Task<IActionResult> History()
        {
            var jobs = await _storageService.RetrieveJobs();

            return View("HistoryView", model: jobs);
        }

        public async Task<IActionResult> GetDetailsView(Guid jobId)
        {
            var jobInfo = await _tablingService.GetJobInfo(jobId);
                     
            return View("DetailsView" ,model: jobInfo);
        }
    }
}
