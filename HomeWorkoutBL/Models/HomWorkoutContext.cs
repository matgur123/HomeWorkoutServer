using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class HomWorkoutContext : DbContext
    {
        public HomWorkoutContext()
        {
        }

        public HomWorkoutContext(DbContextOptions<HomWorkoutContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<ExercisesDifficulty> ExercisesDifficulties { get; set; }
        public virtual DbSet<ExercisesType> ExercisesTypes { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentUser> TournamentUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public virtual DbSet<WorkoutPoint> WorkoutPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database=HomeWorkout; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.ExercisesInfoId)
                    .HasName("exercises_exercisesinfoid_primary");

                entity.Property(e => e.ExercisesInfoId).ValueGeneratedNever();

                entity.HasOne(d => d.ExercisesDifficultyNavigation)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.ExercisesDifficulty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercises_exercisesdifficulty_foreign");

                entity.HasOne(d => d.ExercisesTypeNavigation)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.ExercisesType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercises_exercisestype_foreign");
            });

            modelBuilder.Entity<ExercisesDifficulty>(entity =>
            {
                entity.HasKey(e => e.DifficultyId)
                    .HasName("exercisesdifficulty_difficultyid_primary");

                entity.Property(e => e.DifficultyId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ExercisesType>(entity =>
            {
                entity.Property(e => e.ExercisesTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.TournamentId).ValueGeneratedNever();

                entity.HasOne(d => d.Admin)
                    .WithOne(p => p.Tournament)
                    .HasForeignKey<Tournament>(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tournament_adminid_foreign");
            });

            modelBuilder.Entity<TournamentUser>(entity =>
            {
                entity.HasKey(e => new { e.TournamentId, e.Userid })
                    .HasName("tournamentusers_tournamentid_primary");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ProfilePic).HasDefaultValueSql("('default_pfp.jpg')");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.Property(e => e.WorkoutId).ValueGeneratedNever();
            });

            modelBuilder.Entity<WorkoutExercise>(entity =>
            {
                entity.HasKey(e => e.WorkoutId)
                    .HasName("workoutexercises_workoutid_primary");

                entity.Property(e => e.WorkoutId).ValueGeneratedNever();

                entity.Property(e => e.ExercisesId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<WorkoutPoint>(entity =>
            {
                entity.HasKey(e => e.PointsUserId)
                    .HasName("workoutpoints_workoutpointsid_primary");

                entity.Property(e => e.PointsUserId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
