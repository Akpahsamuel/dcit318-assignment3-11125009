# Inventory Management System

A C# console application that demonstrates advanced C# features including Records, Generics, and File Operations for managing inventory data with immutable data representation and persistent storage.

## Features

- **C# Records**: Immutable data representation using positional syntax
- **Generic Programming**: Type-safe, reusable inventory logging operations
- **File Operations**: JSON-based persistence with proper exception handling
- **Marker Interface**: Common contract for all inventory entities
- **Memory Management**: Session simulation with data persistence

## Architecture

### Core Components

#### Marker Interface
- **IInventoryEntity**: Common interface with `Id` property
- Ensures all inventory items have a unique identifier

#### Immutable Data Model
- **InventoryItem**: Record type with positional syntax
- **Fields**: `Id`, `Name`, `Quantity`, `DateAdded`
- **Immutability**: Data cannot be modified after creation
- **Computed Properties**: `DisplayInfo` for formatted output

#### Generic Logger
- **InventoryLogger<T>**: Generic class with constraint `where T : IInventoryEntity`
- **Type Safety**: Compile-time type checking for all operations
- **File Persistence**: JSON serialization for data preservation
- **Exception Handling**: Comprehensive error management

#### Application Layer
- **InventoryApp**: Main application orchestrator
- **Data Seeding**: Sample inventory population
- **Session Management**: Memory clearing and data recovery
- **System Integration**: Coordinates all system components

## Key Features Implemented

### 1. C# Records
- **Positional Syntax**: `record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded)`
- **Immutability**: Data integrity through immutable objects
- **Value Semantics**: Automatic equality comparison and copying
- **Interface Implementation**: Implements `IInventoryEntity` marker interface

### 2. Generic Programming
- **Type Constraints**: `where T : IInventoryEntity` ensures type safety
- **Reusable Code**: Single logger class handles any inventory entity type
- **Compile-time Safety**: Type checking prevents runtime errors

### 3. File Operations
- **JSON Serialization**: Modern data format for better compatibility
- **Resource Management**: `using` statements for proper disposal
- **Exception Handling**: Graceful error handling for file operations
- **Data Persistence**: Reliable storage and retrieval

### 4. Exception Handling
- **File Errors**: Directory not found, access denied, I/O errors
- **Data Errors**: JSON serialization/deserialization issues
- **Graceful Degradation**: System continues operation when possible
- **User-friendly Messages**: Clear error reporting

## System Workflow

### 1. Data Seeding
- Creates 5 sample inventory items
- Demonstrates record instantiation
- Shows immutable data creation

### 2. Data Persistence
- Saves inventory data to JSON file
- Uses proper resource management
- Handles file operation exceptions

### 3. Session Simulation
- Clears memory to simulate new session
- Demonstrates data separation
- Shows system state management

### 4. Data Recovery
- Loads data from persistent storage
- Validates data integrity
- Confirms successful recovery

## Sample Data

The system creates sample inventory items:
- **Laptop**: 15 units, added 30 days ago
- **Mouse**: 50 units, added 25 days ago
- **Keyboard**: 30 units, added 20 days ago
- **Monitor**: 25 units, added 15 days ago
- **Headphones**: 40 units, added 10 days ago

## File Format

Data is stored in JSON format for each inventory item:
```json
{"Id":1,"Name":"Laptop","Quantity":15,"DateAdded":"2025-07-16T00:00:00"}
{"Id":2,"Name":"Mouse","Quantity":50,"DateAdded":"2025-07-21T00:00:00"}
```

## How to Run

1. Ensure you have .NET 9.0 SDK installed
2. Navigate to the project directory
3. Run the following commands:

```bash
dotnet build
dotnet run
```

## Expected Output

The system will:
1. Display initial system information
2. Seed sample inventory data
3. Show items after seeding
4. Save data to file
5. Clear memory and verify
6. Load data from file
7. Confirm data recovery
8. Display final system status

## Design Patterns Used

- **Record Pattern**: Immutable data representation
- **Generic Pattern**: Type-safe, reusable operations
- **Marker Interface Pattern**: Common contract definition
- **Repository Pattern**: Data access abstraction
- **Exception Handling Pattern**: Robust error management
- **Resource Management Pattern**: Proper disposal with `using` statements

## Technical Highlights

- **Modern C#**: Records, generics, and pattern matching
- **JSON Integration**: System.Text.Json for data serialization
- **File I/O**: StreamReader/StreamWriter with exception handling
- **Type Safety**: Generic constraints and compile-time validation
- **Immutability**: Data integrity through record types
