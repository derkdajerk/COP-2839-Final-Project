using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workout_Log_Tracker_Trauner.Models;

namespace Workout_Log_Tracker_Trauner.Data
{
    public class Workout_Log_Tracker_TraunerContext : DbContext
    {
        public Workout_Log_Tracker_TraunerContext (DbContextOptions<Workout_Log_Tracker_TraunerContext> options)
            : base(options)
        {
        }

        public DbSet<Workout_Log_Tracker_Trauner.Models.Workout> Workout { get; set; } = default!;
    }
}
