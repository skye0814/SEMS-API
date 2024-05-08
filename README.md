SEMS API that is built using ASP.NET Core 6.0 with Entity Framework Core. 

## Getting Started
Setup the local database by typing in the Package Console Manager _(Infrastructure classlib project)_:
```
PM> EntityFrameworkCore\Add-Migration <migration-name>
PM> EntityFrameworkCore\Update-Database
```

The database will be populated by the seed function inside RepositoryContext, after running _EntityFrameworkCore\Update-Database_

To run the application in Google IDX environment, run:
```
dotnet run --urls=http://localhost:5135
```

