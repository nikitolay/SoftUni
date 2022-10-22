using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Add(string district,byte floor,byte maxFloor,int size,
            int yardSize, int year, string propertyType,string buildingType,int price);//za dobavqne na novi jilishta
        decimal AveragePricePerSquareMeter();

        decimal AveragePricePerSquareMeter(int districtId);

        double AverageSize(int districtId);

        IEnumerable<PropertyInfoFullData> GetFullData(int count);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);
    }
}
