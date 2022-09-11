using Microsoft.EntityFrameworkCore;
using PYP_PhoneDirectory.Helpers;
using PYP_PhoneDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDirectory.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        public virtual DbSet<Contact> Contact { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contact>(model =>
            {
                model.HasKey(prop => prop.Id);
                model.Property(prop => prop.Name).HasMaxLength(15).IsRequired();
                model.Property(prop => prop.Surname).HasMaxLength(15).IsRequired(false);
                model.Property(prop => prop.Phone).HasMaxLength(50).IsRequired();
                model.Property(prop => prop.Mail).HasMaxLength(30).IsRequired();
            });
            base.OnModelCreating(modelBuilder); 
        }
    }
 
}
