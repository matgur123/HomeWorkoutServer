using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class WorkoutExercise
    {
        [Key]
        [Column("workoutID")]
        public int WorkoutId { get; set; }
        [Column("ExercisesID")]
        public int ExercisesId { get; set; }
        [Column("numOfReps")]
        public int NumOfReps { get; set; }
        [Column("numOfSets")]
        public int NumOfSets { get; set; }
    }
}
