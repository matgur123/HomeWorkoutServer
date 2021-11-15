using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    [Table("ExercisesDifficulty")]
    public partial class ExercisesDifficulty
    {
        public ExercisesDifficulty()
        {
            Exercises = new HashSet<Exercise>();
        }

        [Key]
        [Column("difficultyID")]
        public int DifficultyId { get; set; }
        [Required]
        [Column("difficulty")]
        [StringLength(255)]
        public string Difficulty { get; set; }

        [InverseProperty(nameof(Exercise.ExercisesDifficultyNavigation))]
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
