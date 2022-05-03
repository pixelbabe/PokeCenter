using ProjetPokemon.Data;


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetPokemon.Data.Service;
using ProjetPokemon.Data.Models;
using System;

namespace ProjetPokemon.Tests
{
    [TestClass]
    public class DonneesPokemonSQLTests
    {
        const string connexionString = "Server=(localdb)\\mssqllocaldb;Database=ProjetPokemon;Trusted_Connection=true;";
        private readonly PokemonDBContext db = new PokemonDBContext(connexionString);


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

            Species s = new Species("Blastoise");
            var p = new Pokemon(s);

            //Act
            source.Add(p);

            //Assert
            Assert.IsTrue(db.Pokemons.Count() == 1);
            Assert.IsTrue(db.Pokemons.First() == p);
            Assert.IsTrue(p.Id != 0);
        }

    }
}
