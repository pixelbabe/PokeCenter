using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPokemon.Data.Models
{
    public class ElementType
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ElementType (string name)
        {
            this.Name = name;
        }

        public List<Species> Species { get; set; }


    }
}
