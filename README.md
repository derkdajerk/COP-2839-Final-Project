# Documentation for Final project ASP.NET Core MVC

## Project summary
- This purpose of this app will be to track workouts completed by the user. This is meant for health benefits as you can record, track, and visualize workouts over time. The goal is to help users stay consistent and monitor their fitness progress through logged exercises, sets, reps, and weights. Users can organize workouts by date, categorize them by muscle groups, and view summaries of their performance trends.

---

To run this app you must clone this repository locally(via url/git), install all dependencies needed (Web App Development in Visual Studio Installer)

Open the solution file in Visual Studio Community.

Then build the solution (Ctrl + Shift + B), and then run with or without debug (F5 or Shift + F5).

## Project Planning Table

| Week | Concept | Feature | Goal | Done Criteria | Evidence / Documentation | Testing Plan |
|----|--------------|--------------|------------------------|-----|-------------------------------|------------------|
| **10** | **Modeling** | Create database models for Workouts | Define and store the core data of the app to represent workouts and user logs. | -Models created for Workout <br><br> -Relationships defined (one-to-many, etc.) <br><br> -Workout table created | Code pushed to GitHub with README section written; | Run migration; verify database tables were created correctly |
| **11** | **Separation of Concerns / Dependency Injection** | Implement service layer for workout management | Separate data access logic from controllers, implement service classes and methods to work with data. | -Services created for Workout operations <br><br> -Controllers use constructor injection <br><br> -No direct DbContext access in controllers | Code pushed to GitHub with README section written;| Unit test service methods |
| **12** | **CRUD** | Create, Read, Update, and Delete functionality for Workouts | Allow users to manage workout entries through full CRUD operations. | -Views and controllers for all CRUD operations <br><br>-Validation & Error messages upon submission | Code pushed to GitHub with README section written; Screenshots of CRUD pages | Manually test/confirm all CRUD operations update DB accordingly. Use integration tests (if i can get them to work) |
| **13** | **Diagnostics** | Add `/healthz` endpoint | Provide clear feedback during runtime and system status. | -Custom error pages <br><br> -`/healthz` endpoint returns app status | Code pushed to GitHub with README section written; Screenshots of error and `/healthz` pages. | Test `/healthz` endpoint to ensure it returns healthy/unhealthy status. |
| **14** | **Logging** | Use ILogger to log every action a user completes | Capture detailed app events and errors for monitoring and debugging. | -Logs include key info like action and timestamp <br><br> -Log file written to local storage/console | Code pushed to GitHub with README section written; Screenshot of a log in console | Trigger actions and verify logs are written correctly. Intentionally cause validation errors to confirm error logs appear. |
| **15** | **Stored Procedures** | Stored procedures for workout summaries | Show list of most often days worked out, most hit workout, consistency of workouts.| -Stored procedure created and executed <br><br> -Summary data displayed | Code pushed to GitHub with README section written; Screenshots of SQL and dashboard output. | Execute stored procedure and confirm results manually. |
| **16** | **Deployment** | Deploy app to Azure App Service | Make the application accessible in the cloud with production settings. | -App Service created <br><br> -App builds and runs on Azure <br><br> -`/healthz` is reachable <br><br> -One functional path works | Code pushed to GitHub with README section written; Deployed URL; Screenshots of working site with URL| Visit public URL; confirm health endpoint and one page load |
---

## Week 10 - Modeling
For Week 10, I focused on implementing the foundational data modeling feature for my Workout Log Tracker. The primary goal was to define the core data structure that will support all future features, ensuring a solid and extensible base for the project. I began by creating a new ASP.NET Core Razor Pages project in Visual Studio. This provided a clean starting point and ensured compatibility with the latest .NET 9 features.

Next, I designed and implemented the `Workout` entity class. This model includes essential properties such as `Id`, `Name`, `Description`, `MuscleGroup`, `Length`, and `Date`. These fields were chosen to capture the key details of each workout, allowing for future expansion (e.g., linking exercises or tracking user progress). With the model and context in place, I created an initial migration using the Entity Framework Core tools.

This migration generated the necessary SQL to create the `Workout` table in the database, reflecting the structure defined in the model. I then applied the migration and updated the database, which successfully created the table. To verify the setup, I ran the application and confirmed that the database was created with the correct schema. I also checked that the application could interact with the database, ensuring that the groundwork for CRUD operations is ready for future development.

## Week 11 - Separation of Concerns / Dependency Injection
For Week 11, I focused on implementing separation of concerns and dependency injection in my Workout Log Tracker. The main objective was to move all business and data access logic out of the PageModel classes and into a dedicated service layer, ensuring that the application remains maintainable, testable, and scalable as it grows.

To achieve this, I created a new `WorkoutService` class within the `Services` folder. This service encapsulates all the core operations related to workouts, such as adding a new workout, retrieving a workout by its ID, deleting a workout, and listing all workouts. By centralizing this logic, I reduced code duplication and made it easier to manage changes to data access in one place.

Next, I registered the `WorkoutService`  using the `Scoped` method in Program.cs. This ensures that a new instance of the service is created for each HTTP request, which is the recommended lifetime for services that interact with Entity Framework Core DbContexts. I then updated the relevant PageModel classes (`IndexModel`, `CreateModel`, and `DeleteModel`) to receive the `WorkoutService` via constructor injection.

All data operations in these PageModels now delegate to the service, keeping the PageModels focused solely on handling HTTP requests and responses. This approach not only keeps the PageModels thin and clean but also makes unit testing much easier, as the service can be mocked or replaced as needed.

## Week 12 - CRUD

For Week 12, I focused on implementing full CRUD (Create, Read, Update, Delete) functionality for the Workout Log Tracker application. The goal was to allow users to manage their workout entries through a complete set of operations, while ensuring the application remains responsive and user-friendly.

To achieve this, I utilized asynchronous data access throughout the service and page models. The `WorkoutService` class provides async methods such as `ToListAsync`, `GetWorkoutByIdAsync`, `AddWorkoutAsync`, and `DeleteWorkoutAsync`, all of which leverage Entity Framework Core’s async capabilities (`ToListAsync`, `FindAsync`, and `SaveChangesAsync`). These methods are called from the relevant PageModels, ensuring that all database operations are performed asynchronously for better scalability and performance.

Validation feedback is integrated into the create and edit pages. The `Create.cshtml` view uses `<span asp-validation-for="...">` and `<div asp-validation-summary="ModelOnly">` to display validation errors directly to the user. In the `CreateModel` PageModel, the `OnPostAsync` method checks `ModelState.IsValid` before proceeding, and if validation fails, the page is returned with error messages displayed. This ensures users receive immediate feedback on any issues with their input.

The application supports listing all workouts on the `Workouts\Index` page and allows users to add new workouts via the `Create` page. The application also supports editing and deleting workouts, providing a complete CRUD experience.