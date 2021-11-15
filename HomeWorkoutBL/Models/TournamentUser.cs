using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class TournamentUser
    {
        [Key]
        [Column("tournamentID")]
        public int TournamentId { get; set; }
        [Key]
        [Column("userid")]
        public int Userid { get; set; }
    }
}
