using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetPokemon.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetPokemon.Data
{
    public class PokemonDBContext : DbContext
    {
        private readonly string _connexionString;

        public PokemonDBContext(string connexion)
        {

            _connexionString = connexion;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer(_connexionString);
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }


    }
}
