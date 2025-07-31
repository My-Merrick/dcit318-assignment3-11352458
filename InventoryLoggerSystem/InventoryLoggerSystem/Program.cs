using System;
using System.Collections.Generic;

namespace InventoryLoggerSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new InventoryLogger<InventoryItem>();

            // Add items
            logger.AddItem(new InventoryItem(1, "Laptop", 10));
            logger.AddItem(new InventoryItem(2, "Rice Bag", 50));
            logger.AddItem(new InventoryItem(3, "Phone", 25));

            Console.WriteLine("Items added:");
            foreach (var item in logger.GetAllItems())
            {
                Console.WriteLine(item);
            }

            string filePath = "inventory.json";

            // Save to file
            logger.SaveToFile(filePath);
            Console.WriteLine($"\nInventory saved to: {filePath}");

            // Load from file
            List<InventoryItem> loadedItems = logger.LoadFromFile(filePath);
            Console.WriteLine("\nItems loaded from file:");
            foreach (var item in loadedItems)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
