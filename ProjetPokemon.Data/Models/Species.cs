using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Models
{
    class Species
    {

        public int Id { get; set; }

        public string SpeciesName { get; }


        public Species(string speciesName, ElementType type1)
        {
            this.SpeciesName = speciesName;
            this.ElementTypes = new List<ElementType>
            {
                type1
            };
        }
        public Species(string speciesName, ElementType type1, ElementType type2)
        {
            this.SpeciesName = speciesName;
            this.ElementTypes = new List<ElementType>
            {
                type1,
                type2
            };
        }

     
        public List<ElementType> ElementTypes { get; set; }


        public string DisplayElementType()
        {

            var str = "";
            foreach (var element in ElementTypes)
            {
                str += element.Name + " ";

            }
            return $"{str}";
        }

    }
}
