# My Cookbook

Recipe management web app built with **Blazor**, **Entity Framework Core**, and **PostgreSQL**.  
Includes authentication with a member section where users can manage only their own recipes.

**Live Demo**: [https://mycookbookapp.onrender.com/](https://mycookbookapp.onrender.com/)

## Tech Stack
- **Blazor Web App** (ASP.NET Core 8)  
- **Entity Framework Core**  
- **PostgreSQL** (hosted on [Railway](https://railway.app/))  

## Features
- Authentication & authorization (each user can edit/delete only their own recipes)  
- Recipe management (create, update, delete, view)  
- Member-only section  
- Filtering (favorite / tried recipes)

## Planned Features
- 🎲 Random meal plan generator (based on filters and preferences)

## Development Notes
This project currently runs as a Blazor Web App (combined hosting model introduced in .NET 8).
Frontend and backend are integrated in one project.
