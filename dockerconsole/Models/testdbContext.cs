using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dockerconsole.Models
{
    public partial class testdbContext : DbContext
    {

        //public testdbContext(DbContextOptions<testdbContext> options) : base(options) { }
        public testdbContext()
        {
        }

        public testdbContext(DbContextOptions<testdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Log { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(local),1401;Database=testdb;user id=sa;pwd=ZXroot11!;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.LogData).IsUnicode(false);
            });
        }
    }
}
