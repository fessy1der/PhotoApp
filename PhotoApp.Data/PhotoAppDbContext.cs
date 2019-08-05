using Microsoft.EntityFrameworkCore;
using PhotoApp.Data.Models;
using PhotoApp.Models;
using System;

namespace PhotoApp.Data
{
    public class PhotoAppDbContext : DbContext
    {
        public PhotoAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Photo> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
