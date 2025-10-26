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
    public class DeleteModel : PageModel
    {
        private readonly Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext _context;

        public DeleteModel(Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workout.FindAsync(id);
            if (workout != null)
            {
                Workout = workout;
                _context.Workout.Remove(Workout);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
