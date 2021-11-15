using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    [Table("Workout")]
    public partial class Workout
    {
        [Key]
        [Column("workoutID")]
        public int WorkoutId { get; set; }
        [Required]
        [Column("workoutName")]
        [StringLength(255)]
        public string WorkoutName { get; set; }
        [Column("pointsForWorkout")]
        public int PointsForWorkout { get; set; }
        [Required]
        [Column("descri")]
        [StringLength(255)]
        public string Descri { get; set; }
    }
}
