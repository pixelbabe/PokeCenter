using ProjetPokemon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Service
{
    public interface ISourceDonneesPokemon
    {
        IEnumerable<Pokemon> GetAll();

        Pokemon Get(int id);

        void Add(Pokemon addPokemon);
        bool Update(Pokemon updatePokemon);

        bool Delete(int id);

    }
}
