using System;
using Newtonsoft.Json;

namespace BeerRecipeList
{ 

    public class ListofBeers
    {
        public BeerRecipes[] BeerRecipes { get; set; }
    }
	
    public class BeerRecipes
    {
        public string Name { get; set; }
        public string Grain { get; set; }
        public string Malt { get; set; }
        public string Hops { get; set; }
        public string Yeast { get; set; }

        public override string ToString()
        {
            return "Beer:" + Name + 
					"\nGrain:" + Grain + 
					"\nMalt:" + Malt + 
					"\nHops:" + Hops + 
					"\nYeast:" + Yeast;
		} 

    }

}


