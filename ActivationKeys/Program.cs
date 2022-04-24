using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] commandToArr = command
                    .Split(">>>")
                    .ToArray();

                if (commandToArr[0] == "Contains")
                {
                    string subs = commandToArr[1];

                    if (activationKey.Contains(subs))
                    {
                        Console.WriteLine($"{activationKey} contains {subs}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                else if (commandToArr[0] == "Flip")
                {
                    int startIndex = int.Parse(commandToArr[2]);
                    int endIndex = int.Parse(commandToArr[3]);

                    if (commandToArr[1] == "Upper")
                    {
                        string current = string.Empty;
                        string currentToUpper = string.Empty;

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            current += activationKey[i];
                            currentToUpper += activationKey[i];
                        }
                        currentToUpper = currentToUpper.ToUpper();

                        activationKey = activationKey.Replace(current, currentToUpper);
                    }
                    else if (commandToArr[1] == "Lower")
                    {
                        string current = string.Empty;
                        string currentToLower = string.Empty;

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            current += activationKey[i];
                            currentToLower += activationKey[i];
                        }
                        currentToLower = currentToLower.ToLower();

                        activationKey = activationKey.Replace(current, currentToLower);
                    }

                    Console.WriteLine(activationKey);
                }

                else if (commandToArr[0] == "Slice")
                {
                    int startIndex = int.Parse(commandToArr[1]);
                    int endIndex = int.Parse(commandToArr[2]);

                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(activationKey);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
