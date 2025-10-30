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

        public DeleteModel(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [BindProperty]
        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _workoutService.GetWorkoutByIdAsync(id.Value);
            if (workout == null)
            {
                return NotFound();
            }

            Workout = workout;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _workoutService.GetWorkoutByIdAsync(id.Value);
            if (workout != null)
            {
                await _workoutService.DeleteWorkoutAsync(workout);
            }

            return RedirectToPage("./Index");
        }
    }
}
