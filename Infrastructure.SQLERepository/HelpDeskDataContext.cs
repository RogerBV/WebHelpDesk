using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace Infrastructure.SQLERepository
{
    public class HelpDeskDataContext:DbContext
    {
        //private static readonly string DatabaseConnectionStringName = "HelpDeskDB";
        public DbSet<Request> Requests { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RequestFile> Files { get; set; }
        public DbSet<RequestState> RequestStates { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
            builder.Entity<Module>().ToTable("Module");
            builder.Entity<Request>().ToTable("Request");
            builder.Entity<RequestState>().ToTable("RequestState");
            builder.Entity<Event>().ToTable("Event");
            builder.Entity<RequestFile>().ToTable("RequestFile");
            builder.Entity<EventType>().ToTable("EventType");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            //.UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true))
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging(true);
                //.UseLoggerFactory( new LoggerFactory(). );
            
        }
    }



}
