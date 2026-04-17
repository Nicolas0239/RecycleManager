RecycleManager - Project for Team

This scaffold contains the complete base of the API (Person A) and leaves only these tasks for Persons B and C:

- Implement the CRUD complete for Material Types (MaterialTypesController + service + repo + tests)
- Implement POST /api/collections (CollectionsController.Post)

How to run:
- Install .NET 8 SDK
- Open RecycleManager.sln in Visual Studio
- Restore NuGet packages
- Run the API (it will use (localdb)\\MSSQLLocalDB by default)

Tests:
- dotnet test

Notes:
- Validators are registered (FluentValidation) and invoked manually inside controllers to avoid dependency on FluentValidation.AspNetCore package.
- Database is ensured created at startup (EnsureCreated) for dev convenience. For production, prefer EF Migrations.
