using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Carseer.CarService.Contracts.CarMakes;

namespace Carseer.CarService.Application.CarMakes
{
    public class VpicService
    {
        private readonly HttpClient _httpClient;

        public VpicService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/");
        }
        public async Task<VpicResultDto> GetCarModels(int makeId, int modelyear) => await _httpClient.GetFromJsonAsync<VpicResultDto>(
            $"vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{modelyear}?format=json");
    }
}
