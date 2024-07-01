using FinalOpt.Infraestructure.Interfaces;
using FinalOpt.Models;
using FinalOpt.Models.AggregateValues;
using Newtonsoft.Json.Linq;
using System.Text;
using System;
using System.Text.Json;
using FinalOpt.Infraestructure.Helpers;

namespace FinalOpt.Infraestructure.Services
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        private string _baseUrl;

        public HttpService(IConfiguration config, HttpClient httpClient, IStorageService storageService)
        {
            _configuration = config;
            _httpClient = httpClient;
            _storageService = storageService;
            _baseUrl = "https://us-south.ml.cloud.ibm.com/ml/v4/deployment_jobs";
        }

        public async Task<string> CreateJob(DataToRunModel dataToRun)
        {
            var spaceId = _configuration["SpaceId"];
            var version = "2024-06-30";
            var deploymentId = _configuration["DeploymentId"];
            var url = $"{_baseUrl}?version={version}&space_id={spaceId}";

            var modelContent = await _storageService.GetOplModel();
            var customData = dataToRun.RunExample ? await _storageService.GetExampleData() : Helper.ObjectToDat(dataToRun);

            using (var client = new HttpClient())
            {
                var request = new NewJobRequest
                {
                    name = "test-from-net" + DateTime.Now.ToShortDateString(),
                    space_id = spaceId,
                    deployment = new Deployment { id = deploymentId },
                    decision_optimization = new DecisionOptimization
                    {
                        input_data = new List<InputData>
                    {
                        new InputData { id = "model.mod", content = Helper.EncodeToBase64(modelContent) },
                        new InputData { id = "datos.dat", content= Helper.EncodeToBase64(customData)}
                    },
                        output_data = new List<OutputData>
                        {
                            new OutputData { id = ".*\\.json" }
                        }
                    }
                };

                var jsonReq = JsonSerializer.Serialize(request);
                var data = new StringContent(jsonReq, Encoding.UTF8, "application/json");

                TokenResponse token = await GetToken();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);


                var response = await client.PostAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    throw new Exception("Error");
                }
            }
        }

        public async Task<string> GetJobInfo(Guid jobId)
        {
            var spaceId = _configuration["SpaceId"];
            var version = "2024-06-21";
            var url = $"{_baseUrl}/{jobId}?version={version}&space_id={spaceId}";

            using (var client = new HttpClient())
            {

                TokenResponse token = await GetToken();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);


                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    throw new Exception("Error");
                }
            }
        }

        public async Task<TokenResponse> GetToken()
        {
            try
            {
                var apiKey = _configuration["API-KEY"];
                var grantType = _configuration["GrantType"];
                var authIbm = _configuration["AuthIbm"];
                var tokenUrl = _configuration["TokenUrl"];

                using (var client = new HttpClient() )
                {
                    var request = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("apikey", apiKey),
                        new KeyValuePair<string, string>("grant_type", grantType)
                    });

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authIbm);

                    var response = await client.PostAsync(tokenUrl, request);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var jsonObject = JObject.Parse(jsonResponse);
                        var accessToken = jsonObject["access_token"].ToString();
                        return new TokenResponse { Token = accessToken };
                    } 
                    else
                    {
                        throw new Exception($"Error al obtener token: {response.ReasonPhrase} - {response.StatusCode}");
                    }
                }
            } 
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado obteniendo token: {ex.Message}");
            }
        }         
    }
}
