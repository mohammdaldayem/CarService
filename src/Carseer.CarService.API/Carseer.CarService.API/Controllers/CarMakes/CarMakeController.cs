using Carseer.CarService.Contracts.CarMakes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carseer.CarService.API.Controllers.CarMakes
{
    [Route("api/models")]
    [ApiController]
    public class CarMakeController : ControllerBase
    {
        private ICarMakeService _carMakeService;
        public CarMakeController(ICarMakeService carMakeService)
        {
            _carMakeService = carMakeService;
        }
        [HttpGet]
        public Task<CarMakeResponseDto> GetCarModels([FromQuery]CarMakeInputDto input)
        {
            return _carMakeService.GetCarModels(input);
        }

    }
}
