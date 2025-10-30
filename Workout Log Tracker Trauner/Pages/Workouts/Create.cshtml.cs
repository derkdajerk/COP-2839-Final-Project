using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout_Log_Tracker_Trauner.Data;
using Workout_Log_Tracker_Trauner.Models;
using Workout_Log_Tracker_Trauner.Services;

namespace Workout_Log_Tracker_Trauner.Pages.Workouts
{
    public class CreateModel : PageModel
    {
        private readonly WorkoutService _workoutService;

        public CreateModel(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Workout Workout { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _workoutService.AddWorkoutAsync(Workout);
            return RedirectToPage("./Index");
        }
    }
}
