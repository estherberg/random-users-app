# Random Users App (React + .NET)

This is a full-stack web application that displays a list of users fetched from the [Random User API](https://randomuser.me/). The project is built using a .NET Web API for the backend and a React + TypeScript frontend.

## Features

- Fetches and caches users from RandomUser.me
- Displays users in a paginated list (Lobby screen)
- Search users by name or email
- Click a user to view detailed information (Inner screen)
- Navigation between screens using React Router
- Error and loading state handling
- Clean and responsive UI

---

## Tech Stack

### Backend

- ASP.NET Core (.NET 7)
- Entity Framework Core
- PostgreSQL (or local in-memory)
- Swagger (OpenAPI)
- RESTful API design
- CORS enabled for React frontend

### Frontend

- React + Vite
- TypeScript
- React Router v6
- Axios

---

## Project Structure

backend/
├── Controllers/
├── Models/
├── Data/
├── Migrations/
└── Program.cs

frontend/
├── components/
│ └── UserCard.tsx
├── pages/
│ ├── Lobby.tsx
│ └── UserDetails.tsx
├── services/
│ └── api.ts
└── App.tsx

---

## Getting Started

### 1. Clone the repository


git clone https://github.com/your-username/random-users-app.git
cd random-users-app

### 2. Backend Setup (.NET)

cd backend
dotnet restore
dotnet ef database update
dotnet run
The backend will run on: http://localhost:5149

### 3. Frontend Setup (React)

cd frontend
npm install
npm run dev
The frontend will run on: http://localhost:3000


## API Endpoints (Swagger)

You can test all the API endpoints using Swagger UI:

http://localhost:5149/swagger

### Available Endpoints:
- `GET /api/users`
- `GET /api/users/{id}`
- `GET /api/users/search?query={term}`
