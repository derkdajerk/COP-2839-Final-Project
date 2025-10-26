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
    public class IndexModel : PageModel
    {
        private readonly Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext _context;

        public IndexModel(Workout_Log_Tracker_Trauner.Data.Workout_Log_Tracker_TraunerContext context)
        {
            _context = context;
        }

        public IList<Workout> Workout { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Workout = await _context.Workout.ToListAsync();
        }
    }
}
