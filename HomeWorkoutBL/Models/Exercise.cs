using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class Exercise
    {
        public int ExercisesInfoId { get; set; }
        public int ExercisesTypeId { get; set; }
        public int ExercisesDifficultyId { get; set; }
        public string ExercisesDescri { get; set; }
        public string ExercisesName { get; set; }
        public string ExercisesVideo { get; set; }

        public virtual ExercisesDifficulty ExercisesDifficulty { get; set; }
        public virtual ExercisesType ExercisesType { get; set; }
    }
}
