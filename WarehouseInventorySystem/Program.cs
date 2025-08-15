using System;

namespace WarehouseInventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Warehouse Inventory Management System ===");
            Console.WriteLine();
            
            // i. Instantiate WareHouseManager
            var warehouseManager = new WareHouseManager();
            
            // ii. Call SeedData()
            Console.WriteLine("Seeding initial data...");
            warehouseManager.SeedData();
            Console.WriteLine("Data seeded successfully!");
            Console.WriteLine();
            
            // iii. Print all grocery items
            warehouseManager.PrintAllItems(warehouseManager._groceries);
            
            // iv. Print all electronic items
            warehouseManager.PrintAllItems(warehouseManager._electronics);
            
            // v. Try to perform operations that will trigger exceptions
            Console.WriteLine("=== Testing Exception Handling ===");
            
            // Try to add a duplicate item
            Console.WriteLine("1. Attempting to add duplicate item...");
            try
            {
                var duplicateItem = new ElectronicItem(1, "Duplicate Laptop", 5, "HP", 12);
                warehouseManager.AddItem(warehouseManager._electronics, duplicateItem);
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Caught DuplicateItemException: {ex.Message}");
            }
            Console.WriteLine();
            
            // Try to remove a non-existent item
            Console.WriteLine("2. Attempting to remove non-existent item...");
            try
            {
                warehouseManager.RemoveItemById(warehouseManager._groceries, 999);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Caught ItemNotFoundException: {ex.Message}");
            }
            Console.WriteLine();
            
            // Try to update with invalid quantity
            Console.WriteLine("3. Attempting to update with invalid quantity...");
            try
            {
                warehouseManager.UpdateQuantity(warehouseManager._electronics, 1, -5);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Caught InvalidQuantityException: {ex.Message}");
            }
            Console.WriteLine();
            
            // Demonstrate successful operations
            Console.WriteLine("=== Successful Operations ===");
            
            // Increase stock successfully
            Console.WriteLine("4. Increasing stock for existing item...");
            warehouseManager.IncreaseStock(warehouseManager._electronics, 1, 5);
            
            // Add new item successfully
            Console.WriteLine("5. Adding new item...");
            var newItem = new GroceryItem(104, "Cheese", 25, DateTime.Now.AddDays(21));
            warehouseManager.AddItem(warehouseManager._groceries, newItem);
            
            // Print updated inventory
            Console.WriteLine("\n=== Updated Inventory ===");
            warehouseManager.PrintAllItems(warehouseManager._groceries);
            warehouseManager.PrintAllItems(warehouseManager._electronics);
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
