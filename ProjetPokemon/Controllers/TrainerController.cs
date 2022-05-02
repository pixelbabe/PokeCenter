using Microsoft.AspNetCore.Mvc;
using ProjetPokemon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetPokemon.Web.Controllers
{
    public class TrainerController : Controller
    {
        public static List<Trainer> Trainers = new List<Trainer>
            {
            new Trainer(1, "Sasha", Regions.Konto),
            new Trainer(2, "Red Ketchup", Regions.Galar),
            new Trainer(3, "Nashu", Regions.Alola)

            };
        public IActionResult Index()
        {
            return View(Trainers);
        }

        public IActionResult Details(int id)
        {
            Trainer trainerTrouvé = null;
            foreach (var t in Trainers)
            {
                if (t.Id == id)
                {
                    trainerTrouvé = t;
                }
            }
            if (trainerTrouvé == null)
                return View("PasTrouve", id);
            else
                return View(trainerTrouvé);
        }

        public IActionResult Create()
        {

            return View(new Trainer(-1, "Nothing", Regions.Konto));
        }

        [HttpPost]
        public IActionResult Create(Trainer nouveauTrainer)
        {
            if (ModelState.IsValid)
            {
                int maxId = 0;
                foreach (var f in Trainers)
                {
                    if (f.Id > maxId)
                    {
                        maxId = f.Id;
                    }
                }
                nouveauTrainer.Id = maxId + 1;
                foreach (var t in Trainers)
                {
                    if (t != null && t.Equals(nouveauTrainer))
                    {
                        ViewBag.MessageErreurs = "Ce trainer existe deja";
                        return View(new Trainer(nouveauTrainer.Id, nouveauTrainer.Nom, nouveauTrainer.Region));
                    }
                }
                if (TryValidateModel(nouveauTrainer, nameof(Trainers)))//non necessaire avec un  paramettre de type complexe
                {
                    Trainers.Add(nouveauTrainer);
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
            return View(new Trainer(-1, nouveauTrainer.Nom, nouveauTrainer.Region));
        }

        public ActionResult Delete(int id)
        {
            Trainer trainerTrouvé = null;
            foreach (var t in Trainers)
            {
                if (t.Id == id)
                {
                    trainerTrouvé = t;
                }
            }
            if (trainerTrouvé == null)
                return View("PasTrouve", id);
            else
                return View(trainerTrouvé);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainerTrouvé = null;
            foreach (var t in Trainers)
            {
                if (t.Id == id)
                {
                    trainerTrouvé = t;
                }
            }
            if (trainerTrouvé != null && Trainers.Remove(trainerTrouvé))
            {
                return RedirectToAction("Index");
            }
            else
                return View("PasTrouve", id);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Trainer trainerTrouvé = null;
            foreach (var t in Trainers)
            {
                if (t.Id == id)
                {
                    trainerTrouvé = t;
                }
            }

            if (trainerTrouvé == null)
            {
                return View("PasTrouve", id);
            }
            return View(trainerTrouvé);
        }

        [HttpPost]
        public IActionResult Edit(Trainer trainerModif)
        {
            if (ModelState.IsValid)
            {
                Trainer trainerTrouvé = null;
                foreach (var t in Trainers)
                {
                    if (t.Id == trainerModif.Id)
                    {
                        trainerTrouvé = t;
                    }
                }
                if (trainerModif == null)
                {
                    return View("PasTrouve");
                }
                
                else
                {
                    foreach (var t in Trainers)
                    {
                        if (t != null && t.Equals(trainerModif) && trainerModif.Equals(trainerTrouvé)==false)
                        {
                            ViewBag.MessageErreurs = "Ce trainer existe deja";
                            return View(trainerModif);
                        }
                    }
                    trainerTrouvé.Nom = trainerModif.Nom;
                    trainerTrouvé.Region = trainerModif.Region;
                    return RedirectToAction("Details", trainerTrouvé);
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

            return View(trainerModif);


        }

    }
}
