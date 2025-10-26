namespace Workout_Log_Tracker_Trauner.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string MuscleGroup { get; set; }
        public string? Length { get; set; }
        public DateTime Date { get; set; }

    }
}
