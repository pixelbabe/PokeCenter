using ProjetPokemon.Data.Models;
using System;

namespace ProjetPokemon.Data
{
    class Program
    {
        static void Main(string[] args)
        {

            Pokemon pikachu = new Pokemon(Species.Pikachu);
            pikachu.Nickname = "Caca";
            Console.WriteLine($"Species: {pikachu.Species}, Name: {pikachu.Name} Nickname: {pikachu.Nickname} ");

            Pokemon b1 = new Pokemon(Species.Bulbasaur);
        
            Console.WriteLine($"Species: {b1.Species}, Name: {b1.Name} Nickname: {b1.Nickname} ");
        }
    }
}
