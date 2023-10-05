using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carseer.CarService.Domain.CarMakes
{
    public interface ICarMakeRepository
    {
        Task<CarMake> GetByNameAsync(string name);
    }
}
