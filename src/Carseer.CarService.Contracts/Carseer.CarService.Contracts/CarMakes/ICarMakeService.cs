using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carseer.CarService.Contracts.CarMakes
{
    public interface ICarMakeService
    {

        Task<CarMakeResponseDto> GetCarModels(CarMakeInputDto input);
    }
}
