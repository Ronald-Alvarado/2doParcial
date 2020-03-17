using _2doParcial.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2doParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Llamadas> Llamadas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Llamadas.db");
        }
    }
}
