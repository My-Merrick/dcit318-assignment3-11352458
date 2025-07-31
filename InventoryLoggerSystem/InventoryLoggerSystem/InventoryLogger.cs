using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryLoggerSystem
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _items = new List<T>();

        public void AddItem(T item)
        {
            _items.Add(item);
        }

        public List<T> GetAllItems()
        {
            return _items;
        }

        public void SaveToFile(string filePath)
        {
            string json = JsonSerializer.Serialize(_items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<T> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return new List<T>();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}
