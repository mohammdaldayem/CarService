using Carseer.CarService.Contracts.CarMakes;
using Carseer.CarService.Domain.CarMakes;
using Carseer.CarService.EntityFrameworkCore.EntityFrameworkCore;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace Carseer.CarService.API
{
    public class DataSeeder
    {
        public static void SeedCarMake(CarServiceDBContext context)
        {
            if (!context.CarMake.Any())
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "CarMake.csv");
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<CarMakeCsv>().ToList();
                    foreach (var item in records)
                    {
                        var carMake = context.CarMake.FirstOrDefault(x => x.Id == item.make_id);
                        if (carMake == null)
                        {
                            context.Add(new CarMake(item.make_id, item.make_name));
                        }
                    }
                }
               
               
                context.SaveChanges();
            }
        }
    }
}
