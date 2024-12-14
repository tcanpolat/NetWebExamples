﻿using _18_EntityFrameworkExample.Models;
using Microsoft.EntityFrameworkCore;

namespace _18_EntityFrameworkExample.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Öğrenci ders arasındaki ilişkiyi tanımlayalım
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.StudentId);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
