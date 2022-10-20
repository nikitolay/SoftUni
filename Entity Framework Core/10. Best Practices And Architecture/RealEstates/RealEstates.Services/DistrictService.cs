using RealEstates.Data;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictService(ApplicationDbContext dbContext)//DI
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            return new List<DistrictInfoDto>();
        }
    }
}
