using System;

namespace InventoryManagementSystem
{
    public class InventoryApp
    {
        private InventoryLogger<InventoryItem> _logger;
        
        public InventoryApp()
        {
            _logger = new InventoryLogger<InventoryItem>("inventory_data.json");
        }
        
        public void SeedSampleData()
        {
            Console.WriteLine("Seeding sample inventory data...");
            
            // Add 5 sample inventory items
            _logger.Add(new InventoryItem(1, "Laptop", 15, DateTime.Now.AddDays(-30)));
            _logger.Add(new InventoryItem(2, "Mouse", 50, DateTime.Now.AddDays(-25)));
            _logger.Add(new InventoryItem(3, "Keyboard", 30, DateTime.Now.AddDays(-20)));
            _logger.Add(new InventoryItem(4, "Monitor", 25, DateTime.Now.AddDays(-15)));
            _logger.Add(new InventoryItem(5, "Headphones", 40, DateTime.Now.AddDays(-10)));
            
            Console.WriteLine($"Added {_logger.GetItemCount()} items to inventory.");
            Console.WriteLine();
        }
        
        public void SaveData()
        {
            try
            {
                Console.WriteLine("Saving inventory data to file...");
                _logger.SaveToFile();
                Console.WriteLine("Data saved successfully!");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
                throw;
            }
        }
        
        public void LoadData()
        {
            try
            {
                Console.WriteLine("Loading inventory data from file...");
                _logger.LoadFromFile();
                Console.WriteLine($"Data loaded successfully! Retrieved {_logger.GetItemCount()} items.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                throw;
            }
        }
        
        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            
            if (items.Count == 0)
            {
                Console.WriteLine("No inventory items found.");
                return;
            }
            
            Console.WriteLine("=== Current Inventory Items ===");
            Console.WriteLine($"Total Items: {items.Count}");
            Console.WriteLine();
            
            foreach (var item in items)
            {
                Console.WriteLine(item.DisplayInfo);
            }
            Console.WriteLine();
        }
        
        public void ClearMemory()
        {
            Console.WriteLine("Clearing memory and simulating new session...");
            _logger.ClearLog();
            Console.WriteLine("Memory cleared. Current item count: 0");
            Console.WriteLine();
        }
        
        public void DisplaySystemInfo()
        {
            Console.WriteLine("=== Inventory Management System ===");
            Console.WriteLine($"Data File: inventory_data.json");
            Console.WriteLine($"Current Items in Memory: {_logger.GetItemCount()}");
            Console.WriteLine($"File Exists: {System.IO.File.Exists("inventory_data.json")}");
            Console.WriteLine();
        }
    }
}
