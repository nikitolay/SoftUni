﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class GetCategoriesByProductsCountDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("aveargePrice")]
        public decimal? AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal? TotalRevenue { get; set; }
    }
}
