using ExamenAlbertoAWS.Data;
using ExamenAlbertoAWS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamenAlbertoAWS.Repositories
{
    public class RepositoryPeliculas
    {
        private PeliculasContext context;
        public RepositoryPeliculas(PeliculasContext context)
        {
            this.context = context;
        }

        public async Task<List<Pelicula>> GetPeliculas()
        {
            return await this.context.Pelicula.ToListAsync();
        }

        public async Task<List<Pelicula>> GetPeliculasActores(string actor)
        {
            return await this.context.Pelicula
                                    .Where(x => x.Actores.Contains(actor))
                                    .ToListAsync();
        }
    }
}
