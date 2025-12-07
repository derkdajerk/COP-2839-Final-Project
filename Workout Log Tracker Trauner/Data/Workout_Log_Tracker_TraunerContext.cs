using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout_Log_Tracker_Trauner.Models;

namespace Workout_Log_Tracker_Trauner.Data
{
    public class Workout_Log_Tracker_TraunerContext : DbContext
    {
        public Workout_Log_Tracker_TraunerContext(DbContextOptions<Workout_Log_Tracker_TraunerContext> options)
            : base(options)
        {
        }

        public DbSet<Workout> Workout { get; set; } = default!;
        public DbSet<WorkoutSummary> WorkoutSummary { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkoutSummary>().HasNoKey();
        }
    }
}