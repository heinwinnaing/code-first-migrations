# Code-First Migration in Entity Framework Core (EF Core)
Code-First Migration is an EF Core feature that allows developers to define their database schema using C# classes (entities) and then generate or update the database schema without writing SQL scripts manually.

# <h3>Why Use Code-First Migration?</h3>
<p>✅ No need to manually write SQL → EF Core generates the database schema.</p>
<p>✅ Version control for database schema → Migrations track schema changes.</p>
<p>✅ Easily modify the database → Add, update, or delete tables and columns.</p>
<p>✅ Automates Database Updates → Keeps the schema in sync with your code.</p>

# <h3>Add the First Migration</h3>
Creates a migration file (e.g., 20240228_InitialCreate.cs).
```csharp
dotnet ef migrations add InitialCreate -- "your-database-connection"
```

# <h3>Apply the Migration (Update Database)</h3>
Applies the migration to database
```csharp
dotnet ef database update -- "your-database-connection"
```

# <h3>Rollback (Undo Last Migration)</h3>
To undo the last migration before updating the database:
```csharp
dotnet ef migrations remove -- "your-database-connection"
```

To revert to a specific migration:
```csharp
dotnet ef database update InitialCreate  -- "your-database-connection"
```
