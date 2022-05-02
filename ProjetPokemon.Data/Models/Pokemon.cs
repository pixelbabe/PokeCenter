using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Models
{
    class Pokemon
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
                    return Enum.GetName(typeof(Species), this.Species);
                }

            } 
        }

        public Species Species { get; set; }
        public string Nickname { get; set; }

        public Pokemon(Species species)
        {
            this.Species = species;
        }


    }
}
