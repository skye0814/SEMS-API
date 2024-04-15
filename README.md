SEMS API that is built using ASP.NET Core 6.0 with Entity Framework Core. 

## Getting Started
Setup the local database by typing in the Package Console Manager _(Infrastructure classlib project)_:
```
PM> EntityFrameworkCore\Add-Migration <migration-name>
PM> EntityFrameworkCore\Update-Database
```

The database will be populated by the seed function inside RepositoryContext, after running _EntityFrameworkCore\Update-Database_

You can test API endpoints by accessing this base URL [https://localhost:7081](https://localhost:7286/)
dotnet run --host=0.0.0.0


