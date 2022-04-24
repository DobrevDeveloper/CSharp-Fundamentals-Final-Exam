using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string commandOne = Console.ReadLine();

            var citiesDict = new Dictionary<string, List<int>>();

            while (commandOne != "Sail")
            {
                string[] commandToArr = commandOne
                    .Split("||")
                    .ToArray();

                string city = commandToArr[0];
                int people = int.Parse(commandToArr[1]);
                int gold = int.Parse(commandToArr[2]);

                if (!citiesDict.ContainsKey(city))
                {
                    citiesDict.Add(city, new List<int> { people, gold });
                }
                else
                {
                    citiesDict[city][0] += people;
                    citiesDict[city][1] += gold;
                }

                commandOne = Console.ReadLine();
            }

            string commandTwo = Console.ReadLine();

            while (commandTwo != "End")
            {
                string[] commandToArr = commandTwo
                    .Split("=>")
                    .ToArray();

                if (commandToArr[0] == "Plunder")
                {
                    string city = commandToArr[1];
                    int people = int.Parse(commandToArr[2]);
                    int gold = int.Parse(commandToArr[3]);

                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                    citiesDict[city][0] -= people;
                    citiesDict[city][1] -= gold;

                    if (citiesDict[city][0] == 0 || citiesDict[city][1] == 0)
                    {
                        Console.WriteLine($"{city} has been wiped off the map!");

                        citiesDict.Remove(city);
                    }
                }
                else if (commandToArr[0] == "Prosper")
                {
                    string city = commandToArr[1];
                    int gold = int.Parse(commandToArr[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        citiesDict[city][1] += gold;
                        int totalGold = citiesDict[city][1];
                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {totalGold} gold.");
                    }
                }

                commandTwo = Console.ReadLine();
            }

            Console.WriteLine($"Ahoy, Captain! There are {citiesDict.Keys.Count} wealthy settlements to go to:");

            if (citiesDict.Keys.Count > 0)
            {
                foreach (var kvp in citiesDict.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value[0]} citizens, Gold: {kvp.Value[1]} kg");
                }
            }

            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
