using System;

namespace WarehouseInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouseManager manager = new WareHouseManager();
            manager.SeedData();

            Console.WriteLine("\nGrocery Items:");
            manager.PrintAllItems(manager.Groceries);

            Console.WriteLine("\nElectronic Items:");
            manager.PrintAllItems(manager.Electronics);

            Console.WriteLine("\nTrying to add duplicate Electronic Item:");
            try
            {
                // Will throw DuplicateItemException
                manager.Electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 12));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.WriteLine("\nTrying to remove non-existent Grocery Item:");
            manager.RemoveItemById(manager.Groceries, 99);

            Console.WriteLine("\nTrying to update to negative quantity:");
            try
            {
                manager.Electronics.UpdateQuantity(2, -5);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.WriteLine("\nProgram complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
