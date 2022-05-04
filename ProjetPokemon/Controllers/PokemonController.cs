using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Create()
        {
            populateSpeciesDropdown();
            populateElementTypeDropdown();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Pokemon newPokemon)
        {

            populateSpeciesDropdown();
            populateElementTypeDropdown();

            if (ModelState.IsValid)
            {
                
                newPokemon.Id = getNextId();

                foreach (var t in source.GetAll())
                {
                    if (t != null && t.Equals(newPokemon))
                    {
                        ViewBag.MessageErreurs = "Ce Pokémon existe déjà";

                        var pokemon = new Pokemon(newPokemon.Id, newPokemon.Species, newPokemon.ElementType);
                        pokemon.Nickname = newPokemon.Nickname;
                        return View(pokemon);
                    }
                }
                if (TryValidateModel(newPokemon, nameof(Pokemon)))//non necessaire avec un  paramettre de type complexe
                {
                    source.Add(newPokemon);
                    return RedirectToAction("Index");
                }

            }

            ViewBag.MessageErreurs = "";
            foreach (var v in ModelState)
            {
                foreach (var erreur in ModelState[v.Key].Errors)
                {
                    ViewBag.MessageErreurs += erreur.ErrorMessage;
                }
            }
            return View();
        }

     

        public IActionResult Details(int id)
        {
            Pokemon pkmnTrouve = source.Get(id);
            if (pkmnTrouve == null)
                return View("PasTrouve", id);
            else
                return View(pkmnTrouve);
        }

        public IActionResult Edit(int id)
        {
            populateSpeciesDropdown();
            populateElementTypeDropdown();

            Pokemon pkmnTrouve = source.Get(id);
            if (pkmnTrouve == null)
                return View("PasTrouve", id);
            else
                return View(pkmnTrouve);
        }

        [HttpPost]
        public IActionResult Edit(Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                Pokemon p = source.Get(pokemon.Id);
                if (p == null)
                {
                    return View("PasTrouve");
                }

            else
            {
               

                    p.Nickname = pokemon.Nickname;
                    p.ElementType = pokemon.ElementType;

                    source.Update(p);

                    return RedirectToAction("Details", p);
                }

            }

            populateSpeciesDropdown();
            populateElementTypeDropdown();

            ViewBag.MessageErreurs = "";
            foreach (var v in ModelState)
            {
                foreach (var erreur in ModelState[v.Key].Errors)
                {
                    ViewBag.MessageErreurs += erreur.ErrorMessage;
                }
            }

            return View(pokemon);
        }


        public ActionResult Delete(int id)
        {
            Pokemon pokemon = source.Get(id);
            if (pokemon == null)
                return View("PasTrouve", id);
            else
                return View(pokemon);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pokemon pokemon = source.Get(id);
      
            if (pokemon != null && source.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
                return View("PasTrouve", id);
        }

        private void populateElementTypeDropdown()
        {
            var elementTypeEnumData = from ElementType e in Enum.GetValues(typeof(ElementType))
                                      select new
                                      {
                                          ID = (int)e,
                                          Name = e.ToString()
                                      };
            ViewBag.elementTypeEnumData = new SelectList(elementTypeEnumData, "ID", "Name");
        }

        private void populateSpeciesDropdown()
        {
            //https://www.c-sharpcorner.com/UploadFile/f1047f/bind-enum-to-dropdownlist-in-Asp-Net-mvc/
            var speciesEnumData = from Species s in Enum.GetValues(typeof(Species))
                                  select new
                                  {
                                      ID = (int)s,
                                      Name = s.ToString()
                                  };

            ViewBag.speciesEnumData = new SelectList(speciesEnumData, "ID", "Name");
        }
        private int getNextId()
        {
            int maxId = 0;
            foreach (var f in source.GetAll())
            {
                if (f.Id > maxId)
                {
                    maxId = f.Id;
                }
            }

            return maxId + 1;
        }
    }
}
