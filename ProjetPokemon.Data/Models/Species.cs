using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Models
{
    public class Species
    {

        public int Id { get; set; }

        public string SpeciesName { get; set;}

        public Species(string speciesName)
        {
            this.SpeciesName = speciesName;
        }

        public Species(string speciesName, List<ElementType> elementTypes)
        {
            this.SpeciesName = speciesName;
            this.ElementTypes = elementTypes;
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
