using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlanetsMass
{
    class Program
    {
        public class Item
        {
            string name;
            int price;

            public Item(string _name, int _price)
            {
                name = _name;
                price = _price;
            }

            public string Name { get { return name; } }

            public int Price { get { return price; } }
        }
        static void Main(string[] args)
        {
            ReadFromShoppingList();
        }

        public static void ReadFromShoppingList()
        {
            string filePath = @"C:\Users\opilane\Planets";
            string fileName = @"SolarSystem.txt";
            List<Item> shoppingItems = new List<Item>();

            List<string> linesFromFile = File.ReadAllLines(Path.Combine(filePath, fileName)).ToList();
            int total = 0;
            foreach (string line in linesFromFile)
            {
                string[] tempArray = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                Item newItem = new Item(tempArray[0], Int32.Parse(tempArray[1]));
                shoppingItems.Add(newItem);
            }
            foreach (Item item in shoppingItems)
            {
                    Console.WriteLine($"Item: {item.Name}; Price: {item.Price}");
                    total += item.Price;
            }
            Console.WriteLine($"total {total}");
        }
    }
}
