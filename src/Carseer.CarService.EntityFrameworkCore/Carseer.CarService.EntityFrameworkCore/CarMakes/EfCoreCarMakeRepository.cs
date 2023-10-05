using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carseer.CarService.Domain.CarMakes;
using Carseer.CarService.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Carseer.CarService.EntityFrameworkCore.CarMakes
{
    public class EfCoreCarMakeRepository : ICarMakeRepository
    {
        protected CarServiceDBContext _context;

        public EfCoreCarMakeRepository(CarServiceDBContext context)
        {
            _context = context;
        }

        public async Task<CarMake> GetByNameAsync(string name) => await _context.CarMake.FirstOrDefaultAsync(x => x.Name == name);
    }
}
