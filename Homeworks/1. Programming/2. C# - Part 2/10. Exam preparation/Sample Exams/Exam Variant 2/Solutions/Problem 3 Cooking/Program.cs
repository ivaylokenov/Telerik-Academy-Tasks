using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Problem_3_Cooking
{
    static class Units
    {
        static readonly List<Tuple<string, decimal>> oneUnitEqualToXCups = new List<Tuple<string, decimal>>();
        static Units()
        {
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("tablespoons", 1.0M / 16.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("tbsps", 1.0M / 16.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("teaspoons", 1.0M / 48.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("tsps", 1.0M / 48.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("milliliters", 1.0M / 240.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("mls", 1.0M / 240.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("liters", 25.0M / 6.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("ls", 25.0M / 6.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("fluid ounces", 1.0M / 8.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("fl ozs", 1.0M / 8.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("pints", 2.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("pts", 2.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("quarts", 4.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("qts", 4.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("gallons", 16.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("gals", 16.0M));
            oneUnitEqualToXCups.Add(new Tuple<string, decimal>("cups", 1.0M));
        }

        public static decimal ConvertToCups(decimal Quanity, string fromUnit)
        {
            return oneUnitEqualToXCups.First(x => x.Item1 == fromUnit).Item2 * Quanity;
        }

        public static decimal ConvertFromCups(decimal Quanity, string toUnit)
        {
            return Quanity / oneUnitEqualToXCups.First(x => x.Item1 == toUnit).Item2;
        }
    }

    class Product
    {
        public string Name { get; set; }
        public decimal QuantityInCups { get; set; }
        public string OriginalUnit { get; set; }

        public Product(string productAsString)
        {
            string[] productParts = productAsString.Split(':');
            this.Name = productParts[2];
            this.OriginalUnit = productParts[1];
            this.QuantityInCups = Units.ConvertToCups(decimal.Parse(productParts[0]), this.OriginalUnit);
        }

        public void AddCupsQuantity(decimal quantityInCups)
        {
            this.QuantityInCups += quantityInCups;
        }

        public override string ToString()
        {
            return string.Format("{0:0.00}:{1}:{2}", Units.ConvertFromCups(this.QuantityInCups, this.OriginalUnit), this.OriginalUnit, this.Name);
        }
    }

    class Program
    {
        static void Main()
        {
            // Decimal point fix
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Generate tests
            // TestsGenerator.GenerateTests(); return;

            // Read recipe
            List<Product> recipe = new List<Product>();
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                Product product = new Product(Console.ReadLine());
                Product existsInRecipe = recipe.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
                if (existsInRecipe != null)
                {
                    existsInRecipe.AddCupsQuantity(product.QuantityInCups);
                }
                else
                {
                    recipe.Add(product);
                }
            }

            // Read Krisi products
            int M = int.Parse(Console.ReadLine());
            for (int i = 1; i <= M; i++)
            {
                Product product = new Product(Console.ReadLine());
                Product existsInRecipe = recipe.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
                if (existsInRecipe != null)
                {
                    existsInRecipe.AddCupsQuantity(-product.QuantityInCups);
                }
            }

            // Write products left
            foreach  (Product product in recipe)
            {
                if (product.QuantityInCups > 0)
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }
    }
}
