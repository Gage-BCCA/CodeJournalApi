# CodeJournal API
This is the backend to my coding journal. Here's what I made it with:

- ASP.NET Core
- SQL Server
- Dapper
- Lots of tears, sweat, blood, trial, and error

I used the Repository design pattern to separate my database access code from my "business logic". The repository classes touch
the database, the service classes interface with the repositories and get consumed by others to actually pass along data.

## Controllers
The main controllers define the end points for projects and posts. It's the entry point to the API.

## Data
The Data folder is my generic container for all things database-related. 

### Data Models
The models for all the entries in my tables.

### Repositories
Contains classes that actually contain database access code, like SQL. Interfaces with the Context class
to open and use connections to the database.

### Services
These are "controller" classes that the rest of the application uses. These classes interface with the
repository classes to get data, but they do not ever actually touch the data store and are not concerned
with the underlying implementation.

### Context.cs
This is my database class. It contains a method for opening a connection and for initializing the database 
if it does not already exist.