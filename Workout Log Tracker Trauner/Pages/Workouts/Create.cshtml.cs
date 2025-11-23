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
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(WorkoutService workoutService, ILogger<CreateModel> logger)
        {
            _workoutService = workoutService;
            _logger = logger;
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
                TempData["ErrorMessage"] = "Error occured creating workout.";
                _logger.LogError($"Error creating workout '{Workout.Name}' at {DateTime.Now}.\nWorkout ID: {Workout.Id}\nRequest ID: {HttpContext.TraceIdentifier}");
                return Page();
            }

            await _workoutService.AddWorkoutAsync(Workout);
            TempData["SuccessMessage"] = $"Workout '{Workout.Name}' added successfully.";
            _logger.LogInformation($"Successfully created workout '{Workout.Name}' at {DateTime.Now}.\nWorkout ID: {Workout.Id}\nRequest ID: {HttpContext.TraceIdentifier}");
            return RedirectToPage("./Index");
        }
    }
}
