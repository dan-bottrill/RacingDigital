# Project Name: Racehorse Owner Hub

## Overview
This project is a web application designed to demostrate the possible use cases and analytical possibilities connected to horse race results and general racehorse ownership.

The backend is built using ASP .NET Core with a MongoDB datatbase, the frontend is built using Razor pages containing HTML and Javascript.

##Features
- User controlled access to emulate racehorse owner's realistic user journey
- View, filter, sort and search previous rae results
- Add custom notes to race results
- View reporting insights based on race result data for different metrics
- generate best jockey results based on racecourse and trainer
- bookmark preferred jockey for the user's own racehorse
- View and edit profile details for the user's own horse

## Setup and Running the Project

### Prerequisites
- .NET 8 SDK or later installed
- Modern web browser (Chrome, Firefox, Edge)
- login details... u:RacehorseOwner123 p:RedRum2025&

## Configuration

This app connects to a MongoDB Atlas database using an environment variable called `MONGODB_URI`.

To run the app locally, create a new environment variable (or use your IDE's run/debug settings) with:

**Variable name**: `MONGODB_URI`
**Value**: `mongodb+srv://danbottrill1:WTh7VeME3F8cBWc3@dbcluster.ai05yxn.mongodb.net/?retryWrites=true&w=majority&appName=DBCluster`
