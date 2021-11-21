using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class ExercisesDifficulty
    {
        public ExercisesDifficulty()
        {
            Exercises = new HashSet<Exercise>();
        }

        public int DifficultyId { get; set; }
        public string Difficulty { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
