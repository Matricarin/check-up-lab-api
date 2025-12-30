# CheckUpLabApi
Simple server-side API for orders in a commercial clinical laboratory

## Project overview

### Architecture

- ASP.NET Core Web API
- Layered architecture:
  - API
  - Application
  - Domain
  - Infrastructure
- DTOs are used to separate API contracts from domain models

### Authorization
- JWT Bearer authentication
- Roles:
  - Consumer
  - Admin

## How to run

Later.

## Tech Stack

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- JWT Authentication

## Future improvements
- Refresh tokens
- Pagination for orders
- Soft delete
- Integration tests