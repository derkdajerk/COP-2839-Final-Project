using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout_Log_Tracker_Trauner.Data;
using Workout_Log_Tracker_Trauner.Models;
using Workout_Log_Tracker_Trauner.Services;

namespace Workout_Log_Tracker_Trauner.Pages.Workouts
{
    public class IndexModel : PageModel
    {
        private readonly WorkoutService _workoutService;

        public IndexModel(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public IList<Workout> Workout { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Workout = await _workoutService.ToListAsync();
        }
    }
}
