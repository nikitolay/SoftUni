﻿using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamImportModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"[A-z0-9\s\w\.\-]+")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
