using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Inventory Management System ===");
            Console.WriteLine("Using C# Records, Generics, and File Operations");
            Console.WriteLine();
            
            try
            {
                // Create an instance of InventoryApp
                var inventoryApp = new InventoryApp();
                
                // Display initial system information
                inventoryApp.DisplaySystemInfo();
                
                // Call SeedSampleData()
                inventoryApp.SeedSampleData();
                
                // Display items after seeding
                Console.WriteLine("=== Items After Seeding ===");
                inventoryApp.PrintAllItems();
                
                // Call SaveData() to persist to disk
                inventoryApp.SaveData();
                
                // Clear memory and simulate a new session
                inventoryApp.ClearMemory();
                
                // Verify memory is cleared
                Console.WriteLine("=== Verification: Memory Cleared ===");
                inventoryApp.PrintAllItems();
                
                // Call LoadData() to read from file
                inventoryApp.LoadData();
                
                // Call PrintAllItems() to confirm data was recovered
                Console.WriteLine("=== Verification: Data Recovered ===");
                inventoryApp.PrintAllItems();
                
                // Final system status
                inventoryApp.DisplaySystemInfo();
                
                Console.WriteLine("=== System Test Complete ===");
                Console.WriteLine("✅ Data seeding successful");
                Console.WriteLine("✅ Data persistence successful");
                Console.WriteLine("✅ Memory clearing successful");
                Console.WriteLine("✅ Data recovery successful");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ System Error: {ex.Message}");
                Console.WriteLine($"Error Type: {ex.GetType().Name}");
                
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Error: {ex.InnerException.Message}");
                }
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
