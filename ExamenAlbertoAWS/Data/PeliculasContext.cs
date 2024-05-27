using ExamenAlbertoAWS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAlbertoAWS.Data
{
    public class PeliculasContext : DbContext
    {
        public PeliculasContext(DbContextOptions<PeliculasContext> options) : base(options) { }
        public DbSet<Pelicula> Pelicula { get; set; }
    }
}
