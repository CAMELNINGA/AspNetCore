using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;

namespace MVC.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            
        });
        public DbSet<Movie> Movie { get; set; }

        
    }
}