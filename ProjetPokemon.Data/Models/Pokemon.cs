using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Models
{
    class Pokemon 
    {
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

        public Pokemon(Species species)
        {
            this.Species = species;
        }





    }
}
