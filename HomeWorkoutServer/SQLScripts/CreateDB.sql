--use master
--drop database HomeWorkout
--Go

Create database HomeWorkout
Go

Use HomeWorkout
Go

CREATE TABLE "WorkoutExercises"(
    "workoutID" INT NOT NULL,
    "ExercisesID" INT NOT NULL,
    "numOfReps" INT NOT NULL,
    "numOfSets" INT NOT NULL
);
ALTER TABLE
    "WorkoutExercises" ADD CONSTRAINT "workoutexercises_workoutid_primary" PRIMARY KEY("workoutID", "ExercisesID");

CREATE TABLE "ExercisesDifficulty"(
    "difficultyID" INT NOT NULL,
    "difficulty" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "ExercisesDifficulty" ADD CONSTRAINT "exercisesdifficulty_difficultyid_primary" PRIMARY KEY("difficultyID");
CREATE TABLE "ExercisesType"(
    "ExercisesTypeID" INT NOT NULL,
    "ExercisetypeDes" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "ExercisesType" ADD CONSTRAINT "exercisestype_exercisestypeid_primary" PRIMARY KEY("ExercisesTypeID");
CREATE TABLE "Workout"(
    "workoutID" INT NOT NULL,
    "workoutName" NVARCHAR(255) NOT NULL,
    "pointsForWorkout" INT NOT NULL,
    "descri" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Workout" ADD CONSTRAINT "workout_workoutid_primary" PRIMARY KEY("workoutID");
CREATE TABLE "WorkoutPoints"(
    "WorkoutPointsID" INT NOT NULL,
    "pointsID" INT NOT NULL,
    "dateAndTime" INT NOT NULL,
    "pointsGathered" INT NOT NULL,
    "userID" INT NOT NULL
);
ALTER TABLE
    "WorkoutPoints" ADD CONSTRAINT "workoutpoints_workoutpointsid_primary" PRIMARY KEY("WorkoutPointsID","pointsID");

CREATE TABLE "TournamentUsers"(
    "tournamentID" INT NOT NULL,
    "userid" INT NOT NULL
);
ALTER TABLE
    "TournamentUsers" ADD CONSTRAINT "tournamentusers_tournamentid_primary" PRIMARY KEY("tournamentID", "userid");

CREATE TABLE "User"(
    "userID" INT NOT NULL,
    "email" NVARCHAR(255) NOT NULL,
    "pass" NVARCHAR(255) NOT NULL,
    "username" NVARCHAR(255) NOT NULL,
    "isAdmin" BIT NOT NULL,
    "profilePic" NVARCHAR(255) NOT NULL,
    "birthDate" INT NOT NULL,
    "address" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "User" ADD CONSTRAINT "user_userid_primary" PRIMARY KEY("userID");
CREATE TABLE "Tournament"(
    "tournamentID" INT NOT NULL,
    "adminID" INT NOT NULL,
    "tournamentName" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Tournament" ADD CONSTRAINT "tournament_tournamentid_primary" PRIMARY KEY("tournamentID");
CREATE UNIQUE INDEX "tournament_adminid_unique" ON
    "Tournament"("adminID");
CREATE TABLE "Exercises"(
    "exercisesInfoID" INT NOT NULL,
    "exercisesTypeID" INT NOT NULL,
    "exercisesDifficultyID" INT NOT NULL,
    "exercisesDescri" NVARCHAR(255) NOT NULL,
    "exercisesName" NVARCHAR(255) NOT NULL,
    "exercisesVideo" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Exercises" ADD CONSTRAINT "exercises_exercisesinfoid_primary" PRIMARY KEY("exercisesInfoID");
ALTER TABLE
    "Tournament" ADD CONSTRAINT "tournament_adminid_foreign" FOREIGN KEY("adminID") REFERENCES "User"("userID");
ALTER TABLE
    "WorkoutPoints" ADD CONSTRAINT "workoutpoints_userid_foreign" FOREIGN KEY("userID") REFERENCES "User"("userID");
ALTER TABLE
    "Exercises" ADD CONSTRAINT "exercises_exercisestype_foreign" FOREIGN KEY("exercisesTypeID") REFERENCES "ExercisesType"("ExercisesTypeID");
ALTER TABLE
    "Exercises" ADD CONSTRAINT "exercises_exercisesdifficulty_foreign" FOREIGN KEY("exercisesDifficultyID") REFERENCES "ExercisesDifficulty"("difficultyID");
