using System;
using System.Collections.Generic;
using System.Text;

namespace BeerRecipeList

//Code for Console Main Menu Board
{
    class CLI
    {
		//Main menu top banner
        internal static void DisplayWelcome()
        {
            Console.WriteLine("----------HomeBrew Recipe List----------");
            Console.WriteLine("A List of Avid HomeBrewer's Favorite Recipes");
            Console.WriteLine("--------------------------------------------");
        }

        internal static string Prompt(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim();
        }

    }
}
