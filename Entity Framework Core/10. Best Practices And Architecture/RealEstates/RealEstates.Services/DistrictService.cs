using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstates.Data;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictService : BaseService, IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictService(ApplicationDbContext dbContext)//DI
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var districts = dbContext.Districts
                .Select(x => new DistrictInfoDto
                {
                    Name = x.Name,
                    AveragePricePerSquareMeter =
                        x.Properties.Where(p => p.Price.HasValue).Average(p => p.Price / (decimal)p.Size) ?? 0,
                    PropertiesCount = x.Properties.Count()
                })
                .OrderByDescending(x => x.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();

            return districts;
        }
    }
}
