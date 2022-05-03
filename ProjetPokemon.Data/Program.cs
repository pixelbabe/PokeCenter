using ProjetPokemon.Data.Models;
using System;
using System.Collections.Generic;

namespace ProjetPokemon.Data
{
    class Program
    {
        static void Main(string[] args)
        {

            //Pokemon pikachu = new Pokemon(Species_enum.Pikachu);
            //pikachu.Nickname = "Caca";
            //Console.WriteLine($"Species: {pikachu.Species}, Name: {pikachu.Name} Nickname: {pikachu.Nickname} ");
            //Pokemon b1 = new Pokemon(Species_enum.Bulbasaur);
            //Console.WriteLine($"Species: {b1.Species}, Name: {b1.Name} Nickname: {b1.Nickname} ");

            ElementType t1 = new ElementType(Enum.GetName(typeof(EnumElementType), EnumElementType.Flying));
            ElementType t2 = new ElementType("Water");

            List<ElementType> elementList1 = new List<ElementType>
            {
                t2
            };

            List<ElementType> elementList2 = new List<ElementType> 
            {
                t1, t2
            };
        

            Species s1 = new Species("Blastoise", elementList1);
            Species s2 = new Species("Gyarados", elementList2);
           
            Pokemon p1 = new Pokemon(s1);
            Pokemon p2 = new Pokemon(s2);
            p2.Nickname = "Hello";

            Console.WriteLine($"Species: {p1.Species.SpeciesName}, Name: {p1.Name} Nickname: {p1.Nickname} Type: {p1.Species.DisplayElementType()}");
            Console.WriteLine($"Species: {p2.Species.SpeciesName}, Name: {p2.Name} Nickname: {p2.Nickname} Type: {p2.Species.DisplayElementType()} ");

        }
    }
}
