

namespace RealEstates.Models
{
    public class Property//imot-glavnoto
    {
        public Property()
        {
            this.Tags=new HashSet<Tag>();
        }
        public int Id { get; set; }

        public int Size { get; set; }

        public int? YardSize { get; set; }//size of garden - nullable zashtoto moje da nqmame dwor(Apartment)

        public byte? Floor { get; set; }//etaj

        public byte? TotalFloors { get; set; }//all count of floor(etaj)

        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets the property price is in Euro
        /// </summary>

        public int Price { get; set; }


        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public int TypeId { get; set; }

        public virtual PropertyType Type { get; set; }

        public int BuildingTypeId { get; set; }

        public virtual BuildingType BuildingType { get; set; }


        public virtual ICollection<Tag> Tags { get; set; }//many-to-many ef core avtomatichno shte si naparvi vsichko


    }
}
