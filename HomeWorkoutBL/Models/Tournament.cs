using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class Tournament
    {
        public int TournamentId { get; set; }
        public int AdminId { get; set; }
        public string TournamentName { get; set; }

        public virtual User Admin { get; set; }
    }
}
