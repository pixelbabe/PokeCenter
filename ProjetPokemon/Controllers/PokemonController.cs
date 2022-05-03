using Microsoft.AspNetCore.Mvc;
using ProjetPokemon.Data.Models;
using ProjetPokemon.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetPokemon.Web.Controllers
{
    public class PokemonController : Controller
    {
        private readonly ISourceDonneesPokemon source = Startup.SourceDonnees;

        public IActionResult Index()
        {
            return View(source.GetAll());
        }
    }
}
