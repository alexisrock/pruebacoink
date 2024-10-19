using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PruebaDBContext : DbContext
    {
        public PruebaDBContext(DbContextOptions<PruebaDBContext> options) : base(options) { }


        public virtual DbSet<UserSp> SpGetUser { get; set; }
        public virtual DbSet<UserSp> SpGetUserById { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserSp>().HasNoKey().ToView("SpGetUser");
            modelBuilder.Entity<UserSp>().HasNoKey().ToView("SpGetUserById");

        }
    }

}

