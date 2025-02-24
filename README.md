# CodeJournal API
This is the backend to my coding journal. Here's what I made it with:

- ASP.NET Core
- Postgres
- Dapper
- Lots of tears, sweat, blood, trial, and error

I used the Repository design pattern to separate my database access code from my "business logic". The repository classes touch
the database, the service classes interface with the repositories and get consumed by others to actually pass along data.

## Controllers
The main controllers define the end points for projects and posts. It's the entry point to the API.

## Repositories
Contains classes that actually contain database access code, like SQL. Interfaces with the Context class
to open and use connections to the database.

## Services
These are "controller" classes that the rest of the application uses. These classes interface with the
repository classes to get data, but they do not ever actually touch the data store and are not concerned
with the underlying implementation.

## Entities
The models for all the entries in my tables. These are used by the repositories to map a SQL result to strongly typed
C# objects.

## DTOs
The modified entities that are ready for transport over the wire. For example, when you retrieve a list of all posts,
I only send the ```PostSummaryDTO``` object, instead of the entirety of the post when it is not needed. Some fields in the database aren't needed,
either, so they are not included. The DTOs are created in the service layer.


