using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace eLearning.DAL
{
    public class eLearningContext : DbContext
    {
        public eLearningContext() : base("eLearningContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Resurse> Resurses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Replay> Replays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}