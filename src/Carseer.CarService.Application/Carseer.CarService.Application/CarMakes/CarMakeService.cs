using Carseer.CarService.Contracts.CarMakes;
using Carseer.CarService.Domain.CarMakes;

namespace Carseer.CarService.Application.CarMakes;

public class CarMakeService : ICarMakeService
{
    private readonly VpicService _vpicService;
    private readonly ICarMakeRepository _carMakeRepository;

    public CarMakeService(VpicService vpicService, ICarMakeRepository carMakeRepository)
    {
        _vpicService = vpicService;
        _carMakeRepository = carMakeRepository;
    }

    public async Task<CarMakeResponseDto> GetCarModels(CarMakeInputDto input)
    {
        var models = new List<string>();
        var carMake = await _carMakeRepository.GetByNameAsync(input.Make);
        if (carMake != null)
        {
            var vpicresault = await _vpicService.GetCarModels(carMake.Id, input.ModelYear);
            models = vpicresault.Results.Select(x => x.Model_Name).ToList();
        }
        return new CarMakeResponseDto()
        {
            Models = models
        };
    }
}
