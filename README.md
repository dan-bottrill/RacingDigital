# Project Name: Racehorse Owner Hub

## Overview

This project is a web application designed to demonstrate the possible use cases and analytical capabilities related to horse race results and racehorse ownership.

The backend is built using **ASP.NET Core 8** with a **MongoDB Atlas** database. The frontend uses **Razor Pages** with HTML and JavaScript.

---

## Features

- Role-based access to emulate a racehorse owner's journey
- View, filter, sort, and search historical race results
- Add personal notes to specific races
- View reporting insights and analytics across different performance metrics
- Generate jockey rankings based on racecourse and trainer filters
- Bookmark a preferred jockey for the user’s horse
- View and edit profile information for the user's horse

---

## Setup and Running the Project

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) or later installed
- A modern web browser (Chrome, Firefox, Edge)

### Test Login Credentials

- **Username:** `RacehorseOwner123`
- **Password:** `RedRum2025&`

---

## Configuration

This application connects to a MongoDB Atlas database using an environment variable called `MONGODB_URI`.

### To run the app locally:

1. Create an environment variable:
   - **Variable name:** `MONGODB_URI`
   - **Value:**
     ```
     mongodb+srv://danbottrill1:WTh7VeME3F8cBWc3@dbcluster.ai05yxn.mongodb.net/?retryWrites=true&w=majority&appName=DBCluster
     ```

2. Alternatively, configure it in your IDE (e.g., Visual Studio > Project Properties > Debug > Environment Variables).

3. Run the app with:
   ```bash
   dotnet run

