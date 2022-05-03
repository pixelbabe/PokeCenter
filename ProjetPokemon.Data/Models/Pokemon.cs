using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Models
{
    public class Pokemon : IEquatable<Pokemon>, IComparable<Pokemon>
    {
        public int Id { get; set; }

        public string Name
        {
            get {
                if (this.Nickname != null)
                {
                    return this.Nickname;
                } else
                {
                    return this.Species.SpeciesName;
                }

            } 
        }

        public Species Species { get; set; }

        public string Nickname { get; set; }

        public Pokemon()
        {  
        }

        public Pokemon(int id, Species species)
        {
            this.Id = id;
            this.Species = species;
        }
        public Pokemon(Species species)
        {
            this.Species = species;
        }

        public bool Equals(Pokemon other)
        {
            if (other == null)
                return false;
            return Id.Equals(other.Id);
        }


        //TODO: Implementer ca avec trainer
        public int CompareTo(Pokemon other)
        {
            if (other == null) return -1;

            int result = Nickname.CompareTo(other.Nickname);
           
            return result;
        }
    }
}
