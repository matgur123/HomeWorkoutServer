using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class Exercise
    {
        [Key]
        [Column("exercisesInfoID")]
        public int ExercisesInfoId { get; set; }
        [Column("exercisesType")]
        public int ExercisesType { get; set; }
        [Column("exercisesDifficulty")]
        public int ExercisesDifficulty { get; set; }
        [Required]
        [Column("exercisesDescri")]
        [StringLength(255)]
        public string ExercisesDescri { get; set; }
        [Required]
        [Column("exercisesName")]
        [StringLength(255)]
        public string ExercisesName { get; set; }
        [Required]
        [Column("exercisesVideo")]
        [StringLength(255)]
        public string ExercisesVideo { get; set; }

        [ForeignKey(nameof(ExercisesDifficulty))]
        [InverseProperty("Exercises")]
        public virtual ExercisesDifficulty ExercisesDifficultyNavigation { get; set; }
        [ForeignKey(nameof(ExercisesType))]
        [InverseProperty("Exercises")]
        public virtual ExercisesType ExercisesTypeNavigation { get; set; }
    }
}
