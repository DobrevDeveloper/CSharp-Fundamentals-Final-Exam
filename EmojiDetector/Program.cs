using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            long coolThreshold = 1;
            string allDigits = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    allDigits += input[i];
                }
            }

            long allDigitsToInt = long.Parse(allDigits);

            while (allDigitsToInt > 0)
            {
                coolThreshold *= allDigitsToInt % 10;
                allDigitsToInt /= 10;
            }

            var regex = new Regex(@"([:][:]|[*][*])(?<emoji>[A-Z][a-z]{2,})\1");

            var matches = regex.Matches(input);

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            int coolness = 0;

            foreach (Match match in matches)
            {
                string name = match.Groups["emoji"].Value;

                for (int i = 0; i < name.Length; i++)
                {
                    coolness += (int)name[i];
                }

                if (coolness >= coolThreshold)
                {
                    Console.WriteLine(match);
                }

                coolness = 0;
            }
        }
    }
}
