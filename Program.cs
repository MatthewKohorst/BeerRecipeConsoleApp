using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeerRecipeList
{
	class Program
	{
		static List<BeerRecipes> _beer = new List<BeerRecipes>();
		private static object path;
		private static object console;
		private static bool done;

		public static JsonReader jsonreader { get; private set; }

		static void Main(string[] args)

		//Console Main Menuboard
		{
			CLI.DisplayWelcome();

			int option = 0;
			while ((option = Menu.Prompt()) != 3)
			{
				switch (option)
				{
					case 1:
						AddBeerRecipes();
						break;
					case 2:
						DisplayBeerRecipeList();
						break;
				}
			}
		}

		static void DisplayBeerRecipeList()
		//List of Beer Recipes
		{
			foreach (var b in _beer)
			{
				Console.WriteLine(b.ToString());
			}

			string currentdirectory = Directory.GetCurrentDirectory();
			DirectoryInfo directory = new DirectoryInfo(currentdirectory);
			var fileName = Path.Combine(directory.FullName, "beer-recipes.json");
			var beerNames = deserializebeerNames(fileName);

			foreach (var beerrecipes in beerNames)
			{
				Console.WriteLine("");
				Console.WriteLine(beerrecipes);
				Console.WriteLine("");
				var myBeer = new BeerRecipes();
				myBeer.Name = beerrecipes.Name;
				myBeer.Grain = beerrecipes.Grain;
				myBeer.Malt = beerrecipes.Malt;
				myBeer.Hops = beerrecipes.Hops;
				myBeer.Yeast = beerrecipes.Yeast;

				_beer.Add(myBeer);

			}
		}

		public static List<BeerRecipes> deserializebeerNames(string fileName)
		//Deserialize Beer Json List	
		{
			var beerNames = new List<BeerRecipes>();
			var serializer = new JsonSerializer();
			using (var reader = new StreamReader(fileName))
			using (var jsonreader = new JsonTextReader(reader))
			{
				beerNames = serializer.Deserialize<List<BeerRecipes>>(jsonreader);
			}

			return beerNames;

		}

		public static void Serializebeernames(string fileName, List<BeerRecipes> NewBeerNames)
		//Serializer Saves User Input to Beer Json List	
		{
			var serializer = new JsonSerializer();
			using (var writer = new StreamWriter(fileName))
			using (var jsonWriter = new JsonTextWriter(writer))
			{
				serializer.Serialize(jsonWriter, NewBeerNames);
			}
		}

		static void AddBeerRecipes()
		//Code prompts user to add their own beer recipe ingredient list
		{
			bool done = false;
			string currentdirectory = Directory.GetCurrentDirectory();
			DirectoryInfo directory = new DirectoryInfo(currentdirectory);
			var fileName = Path.Combine(directory.FullName, "beer-recipes.json");
			do
			{
				string beerName = CLI.Prompt("What's the name of your Beer?");
				string Grain = CLI.Prompt("Add Quantity and Name of Grains?");
				string Malt = CLI.Prompt("Add Quantity and Name of Malt?");
				string Hops = CLI.Prompt("Add Quantity and Name of Hops?");
				string Yeast = CLI.Prompt("Add Quantity and Name of Yeast?");

				_beer.Add(new BeerRecipes { Name = beerName, Grain = Grain, Malt = Malt, Hops = Hops, Yeast = Yeast, });
				Serializebeernames(fileName, _beer);
				done = CLI.Prompt("Add another Beer? (y/n) ").ToLower() != "y";

			} while (!done);
		}
	}
}
	






