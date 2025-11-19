using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using prueba.Entidades;

namespace prueba.Data
{
    public class pruebaContext : DbContext
    {
        public pruebaContext (DbContextOptions<pruebaContext> options)
            : base(options)
        {
        }

        public DbSet<prueba.Entidades.Persona> Persona { get; set; } = default!;
    }
}
