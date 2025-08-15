# Warehouse Inventory Management System

A C# console application that demonstrates a comprehensive warehouse inventory management system using Collections, Generics, and Exception Handling to manage different types of products with safe and efficient operations.

## Features

- **Generic Repository Pattern**: Type-safe inventory management using `InventoryRepository<T>`
- **Marker Interface**: `IInventoryItem` interface for all product types
- **Multiple Product Types**: Electronic and Grocery items with specific properties
- **Exception Handling**: Custom exceptions for robust error management
- **Collections Management**: Efficient storage using Dictionary and List
- **Type Safety**: Full generic implementation with constraints

## Architecture

### Core Components

#### Marker Interface
- `IInventoryItem` - Common interface for all inventory items
- Properties: `Id`, `Name`, `Quantity`

#### Product Classes
- `ElectronicItem` - Electronics with Brand and Warranty information
- `GroceryItem` - Groceries with Expiry Date tracking
- Both implement `IInventoryItem` interface

#### Generic Repository
- `InventoryRepository<T> where T : IInventoryItem`
- Dictionary-based storage with item ID as key
- Methods: `AddItem()`, `GetItemById()`, `RemoveItem()`, `GetAllItems()`, `UpdateQuantity()`

#### Custom Exceptions
- `DuplicateItemException` - Thrown when adding duplicate IDs
- `ItemNotFoundException` - Thrown when item doesn't exist
- `InvalidQuantityException` - Thrown for negative quantities

#### Management System
- `WareHouseManager` - Orchestrates both electronic and grocery inventory
- Generic methods for type-safe operations
- Comprehensive exception handling with user-friendly messages

## Key Features Implemented

### 1. Generic Programming
- **Type Constraints**: `where T : IInventoryItem` ensures type safety
- **Reusable Code**: Single repository class handles multiple entity types
- **Generic Methods**: Type-safe operations across different product types

### 2. Collections Management
- **Dictionary<int, T>**: Fast lookup using item ID as key
- **List<T>**: Efficient retrieval of all items
- **Type-Safe Operations**: Compile-time type checking

### 3. Exception Handling
- **Custom Exceptions**: Domain-specific error types
- **Graceful Degradation**: User-friendly error messages
- **Try-Catch Blocks**: Comprehensive error handling in all operations

### 4. Data Integrity
- **Duplicate Prevention**: Automatic ID uniqueness validation
- **Quantity Validation**: Prevents negative quantities
- **Safe Operations**: All modifications are exception-safe

## How to Run

1. Ensure you have .NET 9.0 SDK installed
2. Navigate to the project directory
3. Run the following commands:

```bash
dotnet build
dotnet run
```

## Sample Output

The system will:
1. Seed sample electronic and grocery items
2. Display all inventory items
3. Demonstrate exception handling with various scenarios:
   - Adding duplicate items
   - Removing non-existent items
   - Updating with invalid quantities
4. Show successful operations
5. Display updated inventory

## Design Patterns Used

- **Repository Pattern**: Generic data access abstraction
- **Marker Interface Pattern**: Common contract for all entities
- **Exception Handling Pattern**: Robust error management
- **Generic Programming**: Type-safe, reusable code
- **Collection Management**: Efficient data organization and retrieval
