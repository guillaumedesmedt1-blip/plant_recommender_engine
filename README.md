# Plant recommender engine

The plant recommender engine returns recommended plants based on user input.

## Overview
The plant recommender makes personalised recommendations on what plant a user should chose. It bases that off
the available light, watering frequency, difficulty level and category that are indicated by the user. To find
the right plant it looks for a plant in the plant.csv dataset to find plants that matches those requirements
and returns them. I built this project for an assignment of the Cloud & DevOps course. I chose for a plant 
recommender because of my plant hobby (I collect tropical plants).

## Demo
Live link and/or a screenshot / GIF

## Tech Stack
Languages: C#
Frameworks: ASP.NET Core-framework
Database: plant.csv
Tools: 

## Features        
- ASP.NET Core Web API
- Plant data loaded from CSV
- Recommendation endpoint based on difficulty
- Dockerized application
- Docker Compose support
- GitHub Actions build pipeline

## requirements
Before starting the project, make sure the following software is installed:
- Docker (desktop)
- Git

## Getting Started  
Clone the repository:
```
git clone <repository-url>
cd plant_recommender_engine
```
Start the application with command:
```
docker compose up --build
```

The API will be available at:
```
http://localhost:8080
```
### API
Get plant recommendations by difficulty:
GET /api/recommendations/{difficulty}

Example:
http://localhost:8080/api/recommendations/easy

Available difficulties: easy, medium, hard

### Stopping the application:
Stop the running containers with:
```
docker compose down
```

### Environment variables
The project uses .env.example to document required environment variables. Create your own .env file when needed:
```
copy .env.example .env
```
The .env file is excluded from Git and should never contain secrets that are committed to the repository. Currently, the application does not require any secrets.

### Docker
The application is built using a multi-stage Docker build:
1. The .NET SDK image builds and publishes the application.
2. The ASP.NET Core runtime image runs the published application.
Docker Compose builds and starts the application with:
```
docker compose up --build
```

### CI Pipeline
GitHub Actions automatically builds the project on every push.

### Current Recommendation Logic
The current baseline recommender filters plants based on the requested difficulty level.

## Project Structure 
- app
    - controllers
    - Models
    - Services
- Data
    - plant.csv
- .dockerignore
- .env.example
- appsettings.Development.json
- appsettings.json
- compose.yaml
- Dockerfile
- plant_recommender_engine.csproj
- plant_recommender_engine.http
- Program.cs
- README.md


## Author          
Guillaume De Smedt
github: https://github.com/guillaumedesmedt1-blip
Linkedin: https://www.linkedin.com/in/guillaume-de-smedt-6387151bb/

