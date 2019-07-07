using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitColors = new List<Team>();

            this.SecondaryKitColors = new List<Team>();
        }

        public int ColorId { get; set; }

        public string Name { get; set; }

        public ICollection<Team> PrimaryKitColors { get; set; }

        public ICollection<Team> SecondaryKitColors { get; set; }

    }
}
