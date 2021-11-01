﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class WorkoutDBContext : DbContext
    {
        public WorkoutDBContext()
        {
        }

        public WorkoutDBContext(DbContextOptions<WorkoutDBContext> options)
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
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=WorkoutDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.ExercisesInfoId)
                    .HasName("exercises_exercisesinfoid_primary");

                entity.Property(e => e.ExercisesInfoId)
                    .ValueGeneratedNever()
                    .HasColumnName("exercisesInfoID");

                entity.Property(e => e.ExercisesDescri)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("exercisesDescri");

                entity.Property(e => e.ExercisesDifficulty).HasColumnName("exercisesDifficulty");

                entity.Property(e => e.ExercisesName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("exercisesName");

                entity.Property(e => e.ExercisesType).HasColumnName("exercisesType");

                entity.Property(e => e.ExercisesVideo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("exercisesVideo");

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

                entity.ToTable("ExercisesDifficulty");

                entity.Property(e => e.DifficultyId)
                    .ValueGeneratedNever()
                    .HasColumnName("difficultyID");

                entity.Property(e => e.Difficulty)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("difficulty");
            });

            modelBuilder.Entity<ExercisesType>(entity =>
            {
                entity.ToTable("ExercisesType");

                entity.Property(e => e.ExercisesTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ExercisesTypeID");

                entity.Property(e => e.ExercisetypeDes)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournament");

                entity.HasIndex(e => e.AdminId, "tournament_adminid_unique")
                    .IsUnique();

                entity.Property(e => e.TournamentId)
                    .ValueGeneratedNever()
                    .HasColumnName("tournamentID");

                entity.Property(e => e.AdminId).HasColumnName("adminID");

                entity.Property(e => e.TournamentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tournamentName");

                entity.HasOne(d => d.Admin)
                    .WithOne(p => p.Tournament)
                    .HasForeignKey<Tournament>(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tournament_adminid_foreign");
            });

            modelBuilder.Entity<TournamentUser>(entity =>
            {
                entity.HasKey(e => e.TournamentId)
                    .HasName("tournamentusers_tournamentid_primary");

                entity.Property(e => e.TournamentId)
                    .ValueGeneratedNever()
                    .HasColumnName("tournamentID");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61644F795745")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5721C6F14A1")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.BirthDate).HasColumnName("birthDate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pass");

                entity.Property(e => e.ProfilePic)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("profilePic")
                    .HasDefaultValueSql("('default_pfp.jpg')");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(255)
                    .HasColumnName("userAddress");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.ToTable("Workout");

                entity.Property(e => e.WorkoutId)
                    .ValueGeneratedNever()
                    .HasColumnName("workoutID");

                entity.Property(e => e.Descri)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("descri");

                entity.Property(e => e.PointsForWorkout).HasColumnName("pointsForWorkout");

                entity.Property(e => e.WorkoutName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("workoutName");
            });

            modelBuilder.Entity<WorkoutExercise>(entity =>
            {
                entity.HasKey(e => e.WorkoutId)
                    .HasName("workoutexercises_workoutid_primary");

                entity.Property(e => e.WorkoutId)
                    .ValueGeneratedNever()
                    .HasColumnName("workoutID");

                entity.Property(e => e.ExercisesId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ExercisesID");

                entity.Property(e => e.NumOfReps).HasColumnName("numOfReps");

                entity.Property(e => e.NumOfSets).HasColumnName("numOfSets");
            });

            modelBuilder.Entity<WorkoutPoint>(entity =>
            {
                entity.HasKey(e => e.PointsUserId)
                    .HasName("workoutpoints_workoutpointsid_primary");

                entity.Property(e => e.PointsUserId)
                    .ValueGeneratedNever()
                    .HasColumnName("PointsUserID");

                entity.Property(e => e.DateAndTime).HasColumnName("dateAndTime");

                entity.Property(e => e.PointsGathered).HasColumnName("pointsGathered");

                entity.Property(e => e.PointsId).HasColumnName("pointsID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
