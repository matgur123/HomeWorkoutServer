using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    [Table("Tournament")]
    [Index(nameof(AdminId), Name = "tournament_adminid_unique", IsUnique = true)]
    public partial class Tournament
    {
        [Key]
        [Column("tournamentID")]
        public int TournamentId { get; set; }
        [Column("adminID")]
        public int AdminId { get; set; }
        [Required]
        [Column("tournamentName")]
        [StringLength(255)]
        public string TournamentName { get; set; }

        [ForeignKey(nameof(AdminId))]
        [InverseProperty(nameof(User.Tournament))]
        public virtual User Admin { get; set; }
    }
}
