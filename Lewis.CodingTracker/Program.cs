using System.Data.SQLite;
using Lewis.CodingTracker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Dapper;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");

var dataAccess = new DataAccess(connectionString);

dataAccess.CreateCodingSession("2026-06-24 09:00:00", "2026-06-24 18:00:00" );

dataAccess.ReadCodingSessions();

dataAccess.UpdateCodingSession(3, "2026-06-24 09:00:00", "2026-06-24 18:00:00" );

dataAccess.ReadCodingSessions();
