﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RealEstates.Services.Models
{
    [XmlType("Tag")]
    public class TagInfoDto
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
