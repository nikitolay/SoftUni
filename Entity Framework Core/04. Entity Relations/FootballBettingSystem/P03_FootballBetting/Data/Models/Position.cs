﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            Players = new HashSet<Player>();
        }
        public int PositionId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
