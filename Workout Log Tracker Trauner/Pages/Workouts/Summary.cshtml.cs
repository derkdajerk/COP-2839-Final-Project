using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workout_Log_Tracker_Trauner.Models;
using Workout_Log_Tracker_Trauner.Services;

namespace Workout_Log_Tracker_Trauner.Pages.Workouts
{
    public class SummaryModel : PageModel
    {
        private readonly WorkoutService _workoutService;
        private readonly ILogger<SummaryModel> _logger;

        public SummaryModel(WorkoutService workoutService, ILogger<SummaryModel> logger)
        {
            _workoutService = workoutService;
            _logger = logger;
        }

        public IList<WorkoutSummary> WorkoutSummaries { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                WorkoutSummaries = await _workoutService.GetWorkoutSummaryAsync();
                _logger.LogInformation($"Successfully retrieved workout summaries at {DateTime.Now}.\nRequest ID: {HttpContext.TraceIdentifier}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving workout summaries at {DateTime.Now}.\nError: {ex.Message}\nRequest ID: {HttpContext.TraceIdentifier}");
                WorkoutSummaries = new List<WorkoutSummary>();
            }
        }
    }
}