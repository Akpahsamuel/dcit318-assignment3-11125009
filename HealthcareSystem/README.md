# Healthcare System

A C# console application that demonstrates a healthcare management system using Collections, Generics, and Repository pattern to manage patient records and prescriptions.

## Features

- **Generic Repository Pattern**: Type-safe entity management using `Repository<T>`
- **Patient Management**: Store and retrieve patient information
- **Prescription Management**: Track medications and their issuance dates
- **Collection Management**: Efficient grouping and retrieval using Dictionary and Lists
- **Type Safety**: Full generic implementation with constraints

## Architecture

### Core Components

#### Generic Repository
- `Repository<T>` - Generic class for entity storage and retrieval
- Methods: `Add()`, `GetAll()`, `GetById()`, `Remove()`
- Type-safe operations for any entity type

#### Entity Classes
- `Patient` - Patient information (ID, Name, Age, Gender)
- `Prescription` - Medication records (ID, PatientID, Medication, Date)

#### Data Management
- `Dictionary<int, List<Prescription>>` - Groups prescriptions by patient ID
- Efficient lookup and retrieval of patient prescriptions
- Automatic grouping and mapping functionality

#### Application Logic
- `HealthSystemApp` - Main application class managing all operations
- Data seeding, mapping, and display functionality
- Complete workflow demonstration

## Key Features Implemented

### 1. Generic Repository Pattern
- **Type Safety**: Compile-time type checking
- **Reusability**: Single repository class handles multiple entity types
- **Scalability**: Easy to extend for new entity types

### 2. Collections Management
- **Dictionary<int, List<Prescription>>**: Efficient patient-prescription mapping
- **List<T>**: Flexible entity storage and retrieval
- **LINQ Integration**: Advanced querying capabilities

### 3. Data Operations
- **Seeding**: Sample data population
- **Mapping**: Automatic prescription grouping by patient
- **Retrieval**: Fast lookup of patient prescriptions
- **Display**: Formatted output of all system data

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
1. Seed sample patient and prescription data
2. Build the prescription mapping dictionary
3. Display all patients in the system
4. Show prescriptions for selected patients
5. Demonstrate the complete healthcare management workflow

## Design Patterns Used

- **Repository Pattern**: Generic data access abstraction
- **Generic Programming**: Type-safe, reusable code
- **Collection Management**: Efficient data organization and retrieval
- **Separation of Concerns**: Clear separation between data, logic, and presentation
