using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Workout_Log_Tracker_Trauner.Models;
using Workout_Log_Tracker_Trauner.Services;

namespace Workout_Log_Tracker_Trauner.Pages.Workouts
{
    public class DeleteModel : PageModel
    {
        private readonly WorkoutService _workoutService;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(WorkoutService workoutService, ILogger<DeleteModel> logger)
        {
            _workoutService = workoutService;
            _logger = logger;
        }

        [BindProperty]
        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Workout ID is null.\nWorkout ID: {id}\nRequest ID: {HttpContext.TraceIdentifier}");
                return NotFound();
            }

            var workout = await _workoutService.GetWorkoutByIdAsync(id.Value);
            if (workout == null)
            {
                _logger.LogError($"Workout is null.\nWorkout ID: {id}\nRequest ID: {HttpContext.TraceIdentifier}");
                return NotFound();
            }

            Workout = workout;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Error occured deleting workout.";
                _logger.LogError($"Workout ID is null.\nWorkout ID: {id}\nRequest ID: {HttpContext.TraceIdentifier}");
                return NotFound();
            }

            var workout = await _workoutService.GetWorkoutByIdAsync(id.Value);
            if (workout != null)
            {
                await _workoutService.DeleteWorkoutAsync(workout);
            }

            TempData["SuccessMessage"] = $"Workout '{workout.Name}' deleted successfully.";
            _logger.LogInformation($"Successfully deleted workout '{workout.Name}' at {DateTime.Now}.\nWorkout ID: {workout.Id}\nRequest ID: {HttpContext.TraceIdentifier}");
            return RedirectToPage("./Index");
        }
    }
}
