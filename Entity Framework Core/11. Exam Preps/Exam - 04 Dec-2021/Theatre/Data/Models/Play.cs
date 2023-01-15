﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Casts= new HashSet<Cast>();
            Tickets=new HashSet<Ticket>();
        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        [Required]
        public float Rating  { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
