using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workout_Log_Tracker_Trauner.Data;
using Workout_Log_Tracker_Trauner.Models;


namespace Workout_Log_Tracker_Trauner.Services
{
    public class WorkoutService
    {
        private readonly Workout_Log_Tracker_TraunerContext _context;
        public WorkoutService(Workout_Log_Tracker_TraunerContext context)
        {
            _context = context;
        }

        public async Task AddWorkoutAsync(Workout workout)
        {
            _context.Workout.Add(workout);
            await _context.SaveChangesAsync();
        }

        public async Task<Workout?> GetWorkoutByIdAsync(int id)
        {
            return await _context.Workout.FindAsync(id);
        }

        public async Task DeleteWorkoutAsync(Workout workout)
        {
            _context.Workout.Remove(workout);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Workout>> ToListAsync()
        {
            return await _context.Workout.ToListAsync();
        }

    }
}
