# 💼 CV-site – ASP.NET Web API Project

This project is a web API designed to manage personal CV (Curriculum Vitae) data. It consists of two main components:

- **CV-site** – The main ASP.NET Web API project
- **CV-site-Libery** – A shared library for business logic or DTOs

## 🚀 Technologies Used

- C#
- ASP.NET Core
- Entity Framework (optional)
- .NET 6 / .NET 7+
- Visual Studio 2022+

## 📁 Project Structure

```
solution/
 ├── CV-site/              # Web API project (Controllers, Program.cs, etc.)
 └── CV-site-Libery/       # Supporting logic layer or shared models
```

## ▶️ Getting Started

### Prerequisites
- .NET SDK 6 or later
- Visual Studio 2022 or JetBrains Rider

### Run the project

1. Open `CV-site.sln` in Visual Studio
2. Set `CV-site` as the startup project
3. Run with `Ctrl + F5`

## 📘 API Documentation

You can optionally use Swagger (Swashbuckle or springdoc) to expose API docs at:

```
http://localhost:{port}/swagger
```

## 🧪 Testing

> Testing can be added via xUnit or NUnit in a separate test project

## 💡 Example Use Cases

- Personal portfolio backend
- Dynamic CV builder service
- HR or recruiter backend for managing applicants

---

> Created using ASP.NET Core and Visual Studio.
