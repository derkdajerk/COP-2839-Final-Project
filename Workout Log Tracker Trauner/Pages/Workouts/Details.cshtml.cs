using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Workout_Log_Tracker_Trauner.Data;
using Workout_Log_Tracker_Trauner.Models;

namespace Workout_Log_Tracker_Trauner.Pages.Workouts
{
    public class DetailsModel : PageModel
    {
        private readonly Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext _context;

        public DetailsModel(Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext context)
        {
            _context = context;
        }

        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workout.FirstOrDefaultAsync(m => m.Id == id);

            if (workout is not null)
            {
                Workout = workout;

                return Page();
            }

            return NotFound();
        }
    }
}
