using System;
using System.Collections.Generic;
using System.Text;

namespace BeerRecipeList
{
    internal class Menu
    {
		//Code setup for the main menu options  
        static string[] _options = new string[]
        {
            "Add Recipe",
            "View Recipe List",
            "Quit"
        };

        static void Display()
        {
            for (int i = 0; i < _options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {_options[i]}");
            }
        }
        internal static int Prompt()
        {
            bool valid = false;
            int parsedOption = 0;
            string option = string.Empty;

            Display();
            do
			//user prompt to select a valid option if false it will return not valid response	
            {
                option = CLI.Prompt($"Please select an option (1-{_options.Length}): ");
                bool canParse = int.TryParse(option, out parsedOption);
                valid = canParse && parsedOption > 0 && parsedOption <= 3;

                if (!valid) 
                {
                    Console.WriteLine("'" + option + "' is not a valid option. Please provide a number 1-3");
                }
            }
            while (!valid);

            return parsedOption;
        }
    }
}
