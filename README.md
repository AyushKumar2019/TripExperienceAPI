# TripExperience API

A backend API built in ASP.NET Core (.NET 8) that allows users to create
 travel experiences (Trips) and define their associated activities. 
 I Utlized Visual Studio 2022 for development and Entity Framework Core for data access.
 I Tried to make use of SOLID principles and clean architecture to ensure maintainability and scalability.

 ## Design Patterns Used -:

 This project applies several key design patterns to promote clean architecture, scalability, and maintainability:

Repository Pattern-:
Abstracts data access logic (EF Core) via TripRepository, keeping the service layer decoupled and testable.

Service Layer Pattern-:
Encapsulates business rules like validation, cost calculation, and scheduling logic within TripService.

DTO Pattern-:
Separates API request/response models from domain models to maintain control over exposed data.

Dependency Injection (DI)-:
Interfaces like ITripService and ITripRepository are injected via the built-in DI container.

## Features

- Create a Trip with one or more Activities
- Activities support mixed durations (hours/days)
- Optional sequencing and preferred start time for activities
- Validation of input data (model-level and business rules)
- Calculates total cost of the trip
- Auto-scheduling of activities based on durations
- Swagger UI enabled for testing
- Supports enum serialization as strings (`"Day"`, `"Hour"`)

---

## Technologies

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core (SQL Server)
- Swashbuckle (Swagger/OpenAPI)

---

## Project Structure

TripExperienceAPI/
├── Controllers/       # API endpoints
├── DTOs/              # Trip and Activity request/response models
├── Models/            # Domain models (Trip, Activity)
├── Services/          # TripService logic
├── Repositories/      # Data access layer
├── Data/              # AppDbContext
├── Program.cs         # Application startup
├── appsettings.json   # Configuration & DB connection
├── README.md          # You’re here


---

## Setup Instructions

### 1. Clone the repo and restore packages

```bash
git clone https://github.com/yourusername/tripexperience-api.git
cd tripexperience-api
dotnet restore
```
OR 

Use Visual Studio to clone and open the project , restore packages and build the solution.

### 2. Update database

```bash
dotnet ef database update
```
OR 
RUN update-database command in Package Manager Console

Make sure `DefaultConnection` in `appsettings.json` points to your SQL Server.

### 3. Run the API

```bash
dotnet run
```
OR 
Directly start it from VS

Visit Swagger UI: `https://localhost:5001` //Diffrent Port Number Could be there

---

## Sample Request

### `POST /api/Trips`

```json
{
  "userId": "user123",
  "title": "Summer Europe Tour",
  "startDate": "2025-07-01T09:00:00",
  "endDate": "2025-07-10T20:00:00",
  "activities": [
    {
      "destinationId": 101,
      "duration": 2,
      "durationUnit": "Day",
      "cost": 150.0,
      "preferredStartTime": "2025-07-02T10:00:00",
      "sequence": 1
    },
    {
      "destinationId": 102,
      "duration": 10,
      "durationUnit": "Hour",
      "cost": 75.0
    }
  ]
}
```

---

##  Sample Response

```json
{
  "tripId": 1,
  "title": "Summer Europe Tour",
  "totalCost": 225.0
}
```

---

## Validation Rules

- `StartDate < EndDate`
- Total activity duration must not exceed trip length
- At least one activity is required
- Enum values must be valid (`"Day"` or `"Hour"`)
- Cost must be > 0
- Duration must be ≥ 1

---

## Testing

### Using Swagger

Run the project and go to `https://localhost:5001/swagger`


Run tests via Postman:

Use the localHost URL along with Sample data given
```

---

## 👨‍💻 Author

Built by  Ayush Kumar

---