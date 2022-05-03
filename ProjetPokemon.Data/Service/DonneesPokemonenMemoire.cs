using ProjetPokemon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Service
{
    public class DonneesPokemonenMemoire : ISourceDonneesPokemon
    {
        private readonly List<Pokemon> pokemons;

        public DonneesPokemonenMemoire()
        {


            ElementType t1 = new ElementType(Enum.GetName(typeof(EnumElementType), EnumElementType.Flying));
            ElementType t2 = new ElementType(Enum.GetName(typeof(EnumElementType), EnumElementType.Water));

            List<ElementType> elementList1 = new List<ElementType>
                {
                    t2
                };

            List<ElementType> elementList2 = new List<ElementType>
                {
                    t1, t2
                };


            Species s1 = new Species("Blastoise", elementList1);
            Species s2 = new Species("Gyarados", elementList2);

            Pokemon p1 = new Pokemon(1, s1);
            Pokemon p2 = new Pokemon(2, s2);
            Pokemon p3 = new Pokemon(3, s2);
            
            p2.Nickname = "johnny";
            
            pokemons = new List<Pokemon>
            {
                p1,p2,p3
            };

        }

        public IEnumerable<Pokemon> GetAll()
        {
            return pokemons.OrderBy(p => p.Name);
        }

        public void Add(Pokemon addPokemon)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Pokemon Get(int id)
        {
            return pokemons.Find(p => p.Id == id);
        }

        public bool Update(Pokemon updatePokemon)
        {
            throw new NotImplementedException();
        }
    }
}
