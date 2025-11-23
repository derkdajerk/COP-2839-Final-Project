using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout_Log_Tracker_Trauner.Data;
using Workout_Log_Tracker_Trauner.Models;

namespace Workout_Log_Tracker_Trauner.Pages.Workouts
{
    public class EditModel : PageModel
    {
        private readonly Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext _context;
        private readonly ILogger<EditModel> _logger;

        public EditModel(Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Workout ID is null.\nWorkout ID: {id}");
                return NotFound();
            }

            var workout = await _context.Workout.FirstOrDefaultAsync(m => m.Id == id);
            if (workout == null)
            {
                _logger.LogError($"Workout is null.\nWorkout ID: {id}");
                return NotFound();
            }
            Workout = workout;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Error occured editing workout.";
                _logger.LogError($"Error editing workout '{Workout.Name}' at {DateTime.Now}.\nWorkout ID: {Workout.Id}\nRequest ID: {HttpContext.TraceIdentifier}");
                return Page();
            }

            _context.Attach(Workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(Workout.Id))
                {
                    TempData["ErrorMessage"] = "Error occured editing workout.";
                    _logger.LogError($"Error editing workout '{Workout.Name}' at {DateTime.Now}.\nWorkout ID: {Workout.Id}\nRequest ID: {HttpContext.TraceIdentifier}");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["SuccessMessage"] = $"Workout '{Workout.Name}' edited successfully.";
            _logger.LogInformation($"Successfully edited workout '{Workout.Name}' at {DateTime.Now}.\nWorkout ID: {Workout.Id}\nRequest ID: {HttpContext.TraceIdentifier}");
            return RedirectToPage("./Index");
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workout.Any(e => e.Id == id);
        }
    }
}
