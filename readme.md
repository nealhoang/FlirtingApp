# Initial release of clean architecture sample app

## System requirement

- Local SQL Server with integrated security (or edit FlirtingApp.WebApi/appsettings.json ConnectionStrings.DefaultConnectionString to match your setup)
- MongoDb with port 27017 without authentication (or edit FlirtingApp.WebApi/appsettings.json MongoOptions to match your setup). Mongo can be run with docker with the command: **docker container run -d -p 27017:27017 --name my-mongo mongo**

<img src="https://serving.photos.photobox.com/3047955071e2f47a1e3c1140fb2f279d5472e04913a6d9fa7b7ed858bcf5ed415020f202.jpg"
     alt="Clean architecture" />

## Features

- ASP.NET Core 3.1 LTS, ASP.NET Core 3.1 Identity
- Angular 8 with Angular material component, Angular flex-layout
- CQRS with Mediator: Writing parts will write to both SQL Server and MongoDb, Reading ports will read from MongoDb for optimized performance.
- Jwt Authentication with refresh token.
- Simple, focus on intention of the code.
- Single responsibility classes.
- Separation of concerns.
- Validation with FluentValidation.
- Remove usage of default ASP.NET Core validation with ModelState and move validation to Application layer as it's part of business logic.
- Cloudinary integration for uploading images
- Custom exceptions for each layers.
- Unify exceptions errors message with ExceptionMiddleware
- 2 DbContext: 1 for Application entities, 1 for IdentityDbContext.

## In progress

- Update tests for Application layer.
- Using mongodb for queries.
- Real-time private chat and group chat with SignalR 3
- Dockerizing the app.
