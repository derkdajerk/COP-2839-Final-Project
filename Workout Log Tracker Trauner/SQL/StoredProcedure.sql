USE [Workout_Log_Tracker_TraunerContext-1eeceaa3-576a-46ee-ad13-4c34a8a37b20];
GO

CREATE PROCEDURE sp_GetWorkoutSummary
AS
BEGIN
    SELECT 
        MuscleGroup,
        COUNT(*) AS WorkoutCount,
        MAX([Date]) AS MostRecentDate
    FROM [Workout]
    GROUP BY MuscleGroup
    ORDER BY WorkoutCount DESC, MostRecentDate DESC;
END;
GO