using ProjetPokemon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Service
{
    public class DonneesPokemonSQL : ISourceDonneesPokemon
    {

        private readonly PokemonDBContext db;

        public DonneesPokemonSQL(PokemonDBContext db)
        {
            this.db = db;
        }
        public void Add(Pokemon addPokemon)
        {
            db.Pokemons.Add(addPokemon);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Pokemon Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pokemon> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Pokemon updatePokemon)
        {
            throw new NotImplementedException();
        }
    }
}
