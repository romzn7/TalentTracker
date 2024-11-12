# TalentTracker

TalentTracker is a comprehensive candidate management system designed to streamline and optimize the recruitment process for organizations of all sizes. By leveraging modern technologies and robust features, TalentTracker empowers recruiters and HR professionals to efficiently manage candidate profiles, applications, and communications throughout the hiring lifecycle.

TalentTracker is built on a robust architectural foundation that combines Clean Architecture principles with CQRS and Domain-Driven Design (DDD) methodologies. This architectural approach ensures a scalable, maintainable, and efficient candidate management system.

### Modular Monolithic Transformation
In the future, as the application scales and complexity increases, TalentTracker is architected in a way that it can transition to a modular monolithic approach if deemed necessary. This approach combines the benefits of monolithic architecture, such as simplified deployment and management, with the modularity of microservices.

To run TalentTracker and get started with managing candidates effectively, follow these steps:

### Prerequisites:

#### Development Environment:
- Ensure you have a development environment set up with Visual Studio or Visual Studio Code installed.
- Install .NET Core SDK suitable for your operating system from dotnet.microsoft.com.

#### Database Setup:
- TalentTracker uses SQL Server as its database. Ensure you have access to a SQL Server instance.
- Configure a SQL Server database and update the connection string in appsettings.json under ConnectionStrings with your database details.

  >  "TalentTrackerDbContext": "server={ServerName};database=TalentTracker;TrustServerCertificate=True;"

- Make sure that "EnableMigration" & "EnableMigrationSeed" remains "true". This directly executes the migration and seed the data.
   > "TalentTrackerSettings": {
  "Infrastructure": {
    "EnableMigration": true,
    "EnableMigrationSeed": true
  }
}

#### Dependencies:
- Open the TalentTracker solution in Visual Studio or your preferred IDE.
- Restore NuGet packages to ensure all necessary dependencies are installed.
