using System.Data.SQLite;
using Lewis.CodingTracker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Dapper;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");

var dataAccess = new DataAccess(connectionString);

