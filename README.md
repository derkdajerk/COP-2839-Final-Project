# Documentation for Final project ASP.NET Core MVC

## Project summary
- This purpose of this app will be to track workouts completed by the user. This is meant for health benefits as you can record, track, and visualize workouts over time. The goal is to help users stay consistent and monitor their fitness progress through logged exercises, sets, reps, and weights. Users can organize workouts by date, categorize them by muscle groups, and view summaries of their performance trends.

---

## Project Planning Table

| Week | Concept | Feature | Goal | Done Criteria | Evidence / Documentation | Testing Plan |
|----|--------------|--------------|------------------------|-----|-------------------------------|------------------|
| **10** | **Modeling** | Create database models for Users, Workouts, and Exercises | Define and store the core data of the app to represent workouts and user logs. | -Models created for User, Workout, and Exercise <br><br> -Relationships defined (one-to-many, etc.) <br><br> -User/Workout table created | Code pushed to GitHub with README section written; | Run migration; verify database tables were created correctly |
| **11** | **Separation of Concerns / Dependency Injection** | Implement service layer for workout management | Separate data access logic from controllers, implement service classes and methods to work with data. | -Services created for Workout operations <br><br> -Controllers use constructor injection <br><br> -No direct DbContext access in controllers | Code pushed to GitHub with README section written;| Unit test service methods |
| **12** | **CRUD** | Create, Read, Update, and Delete functionality for Workouts | Allow users to manage workout entries through full CRUD operations. | -Views and controllers for all CRUD operations <br><br> -Validation/Error messages upon submission | Code pushed to GitHub with README section written; Screenshots of CRUD pages | Manually test/confirm all CRUD operations update DB accordingly. Use integration tests (if i can get them to work) |
| **13** | **Diagnostics** | Add `/healthz` endpoint | Provide clear feedback during runtime and system status. | -Custom error pages <br><br> -`/healthz` endpoint returns app status | Code pushed to GitHub with README section written; Screenshots of error and `/healthz` pages. | Test `/healthz` endpoint to ensure it returns healthy/unhealthy status. |
| **14** | **Logging** | Use ILogger to log every action a user completes | Capture detailed app events and errors for monitoring and debugging. | -Logs include key info like action and timestamp <br><br> -Log file written to local storage/console | Code pushed to GitHub with README section written; Screenshot of a log in console | Trigger actions and verify logs are written correctly. Intentionally cause validation errors to confirm error logs appear. |
| **15** | **Stored Procedures** | Stored procedures for workout summaries | Show list of most often days worked out, most hit workout, consistency of workouts.| -Stored procedure created and executed <br><br> -Summary data displayed | Code pushed to GitHub with README section written; Screenshots of SQL and dashboard output. | Execute stored procedure and confirm results manually. |

---


To run this app you must clone this repository locally(via url/git), install all dependencies needed (Web App Development in Visual Studio Installer)

Open the solution file in Visual Studio Community.

Then build the solution (Ctrl + Shift + B), and then run with or without debug (F5 or Shift + F5).
