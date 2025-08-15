using System;

namespace WarehouseInventorySystem
{
    public class WareHouseManager
    {
        public InventoryRepository<ElectronicItem> _electronics;
        public InventoryRepository<GroceryItem> _groceries;
        
        public WareHouseManager()
        {
            _electronics = new InventoryRepository<ElectronicItem>();
            _groceries = new InventoryRepository<GroceryItem>();
        }
        
        public void SeedData()
        {
            // Add 2-3 electronic items
            _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
            _electronics.AddItem(new ElectronicItem(2, "Smartphone", 15, "Samsung", 12));
            _electronics.AddItem(new ElectronicItem(3, "Tablet", 8, "Apple", 18));
            
            // Add 2-3 grocery items
            _groceries.AddItem(new GroceryItem(101, "Milk", 50, DateTime.Now.AddDays(7)));
            _groceries.AddItem(new GroceryItem(102, "Bread", 30, DateTime.Now.AddDays(3)));
            _groceries.AddItem(new GroceryItem(103, "Eggs", 100, DateTime.Now.AddDays(14)));
        }
        
        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            var items = repo.GetAllItems();
            
            if (typeof(T) == typeof(ElectronicItem))
            {
                Console.WriteLine("=== Electronic Items ===");
                foreach (var item in items)
                {
                    var electronicItem = item as ElectronicItem;
                    Console.WriteLine($"ID: {electronicItem.Id}, Name: {electronicItem.Name}, Quantity: {electronicItem.Quantity}, Brand: {electronicItem.Brand}, Warranty: {electronicItem.WarrantyMonths} months");
                }
            }
            else if (typeof(T) == typeof(GroceryItem))
            {
                Console.WriteLine("=== Grocery Items ===");
                foreach (var item in items)
                {
                    var groceryItem = item as GroceryItem;
                    Console.WriteLine($"ID: {groceryItem.Id}, Name: {groceryItem.Name}, Quantity: {groceryItem.Quantity}, Expiry: {groceryItem.ExpiryDate:MM/dd/yyyy}");
                }
            }
            Console.WriteLine();
        }
        
        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Successfully increased stock for item ID {id} by {quantity} units.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Successfully removed item with ID {id} from inventory.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        public void AddItem<T>(InventoryRepository<T> repo, T item) where T : IInventoryItem
        {
            try
            {
                repo.AddItem(item);
                Console.WriteLine($"Successfully added item '{item.Name}' with ID {item.Id} to inventory.");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        public void UpdateQuantity<T>(InventoryRepository<T> repo, int id, int newQuantity) where T : IInventoryItem
        {
            try
            {
                repo.UpdateQuantity(id, newQuantity);
                Console.WriteLine($"Successfully updated quantity for item ID {id} to {newQuantity} units.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
