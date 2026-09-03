using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace V2_Dag4_GrpOvn_Pizza

{
    public class ReadFile
    {

        public static List<string> ReadFileToList(string fileName)
        {
            string filePath = System.IO.Path.Combine(
                AppContext.BaseDirectory,
                    "ImportFiler",
                    fileName);
            Debug.WriteLine("Filepath: " + filePath);
            StringReader sr = new StringReader(File.ReadAllText(filePath));

            string line = sr.ReadLine();

            List<string> pizzaTypes = new List<string>();

            while (line != null)
            {
                pizzaTypes.Add(line);
                line = sr.ReadLine();
            }

            // Endast för debugging syfte, skriver ut alla pizza typer i debug output
            foreach (string type in pizzaTypes)
            {
                Debug.WriteLine(type);
            }
            // --------------------------------------

            pizzaTypes.Sort();

            return pizzaTypes;
        }

        public static List<Pizza> CreatePizzaList(List<string> pizzaTypes)
        {
            List<Pizza> pizzas = new List<Pizza>();

            foreach (string pizzaType in pizzaTypes)
            {
                string[] parts = pizzaType.Split(';');

                if (parts[0] == "Name")
                {
                    continue;
                }

                string name = parts[0];
                double price = double.Parse(parts[1]);

                Pizza pizza = new Pizza(name, price);

                pizzas.Add(pizza);

                Debug.WriteLine($"Pizza: {pizza.Name}, Price: {pizza.Price}");
            }

            return pizzas;
        }
    }
    public class Pizza
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Pizza(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }


}

