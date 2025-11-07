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

        public EditModel(Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext context)
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
            if (workout == null)
            {
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["SuccessMessage"] = $"Workout '{Workout.Name}' edited successfully.";
            return RedirectToPage("./Index");
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workout.Any(e => e.Id == id);
        }
    }
}
