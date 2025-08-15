using System;

namespace InventoryManagementSystem
{
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity
    {
        // The record automatically implements IInventoryEntity.Id through positional syntax
        // Additional computed properties can be added here if needed
        public string DisplayInfo => $"{Name} (ID: {Id}) - Quantity: {Quantity} - Added: {DateAdded:MM/dd/yyyy}";
    }
}
