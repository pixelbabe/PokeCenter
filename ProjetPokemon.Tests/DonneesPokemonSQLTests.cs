using ProjetPokemon.Data;


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetPokemon.Data.Service;
using ProjetPokemon.Data.Models;
using ProjetPokemon.Data.Data;
using System;
using System.Collections.Generic;

namespace ProjetPokemon.Tests
{
    [TestClass]
    public class DonneesPokemonSQLTests
    {
        const string connexionString = "Server=(localdb)\\mssqllocaldb;Database=ProjetPokemon;Trusted_Connection=true;";
        private readonly PokemonDBContext db = new PokemonDBContext(connexionString);


   //     public void setUp()
   //     {
   //         db.Database.EnsureDeleted();
   //         db.Database.EnsureCreated();

   //     }



        [TestMethod]
        public void TestCreationBD()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            var expected = "ProjetPokemon";
            Assert.AreEqual(expected, db.Database.GetDbConnection().Database);
        }

        [TestMethod]
        public void WhenAddingNewPkmnExpecPkmnIdNot0()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //Arrange
            ISourceDonneesPokemon source = new DonneesPokemonSQL(db);
       
            var p = new Pokemon(Species.Squirtle);

            //Act
            source.Add(p);

            //Assert
            Assert.IsTrue(db.Pokemons.Count() == 1);
            Assert.IsTrue(db.Pokemons.First() == p);
            Assert.IsTrue(p.Id != 0);
        }

        [TestMethod]
        public void TestEagerLoading1()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //Arrange
            ISourceDonneesPokemon source = new DonneesPokemonSQL(db);

            var p = new Pokemon(Species.Squirtle);
            source.Add(p);

            p.ElementType = ElementType.Electric;



            //Act
            var actual = source.GetAll().First();

            //Assert
            Assert.IsTrue(actual.Id != 0);
            Assert.IsTrue(actual == p);
            Assert.IsTrue(actual.Species == Species.Squirtle);
            Assert.IsTrue(actual.ElementType == ElementType.Electric);

        }

        [TestMethod]
        public void UpdatingPokemon()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //Arrange
            ISourceDonneesPokemon source = new DonneesPokemonSQL(db);
            var p = new Pokemon(Species.Squirtle);

            //Act
            source.Add(p);
            p.Nickname = "ChangedNickname";
            source.Update(p);

            var p1 = db.Pokemons.Find(p.Id);

            //Assert
            Assert.IsTrue(p1.Nickname == "ChangedNickname");
        }

        [TestMethod]
        public void DeletePokemonById()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //Arrange
            ISourceDonneesPokemon source = new DonneesPokemonSQL(db);
            var p = new Pokemon(Species.Squirtle);


            //Act
            source.Add(p);
            source.Delete(p.Id);


            var p1 = source.Get(p.Id);

            //Assert
            Assert.IsTrue(p1 == null);
        }

        [TestMethod]
        public void DeleteNonExistingPokemonById()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //Arrange
            ISourceDonneesPokemon source = new DonneesPokemonSQL(db);

            //Act
            var deleted = source.Delete(1);


            //Assert
            Assert.IsFalse(deleted);
        }

        [TestMethod]
        public void UpdateNonExistingPokemon()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //Arrange
            ISourceDonneesPokemon source = new DonneesPokemonSQL(db);

            //Act
            var p = new Pokemon();
            p.Nickname = "ChangedNickname";
            var updated = source.Update(p);

            //Assert
            Assert.IsFalse(updated);
        }

    }
}
