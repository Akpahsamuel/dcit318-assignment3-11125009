# Finance Management System

A C# console application that demonstrates a modular finance management system with the following features:

## Features

- **Transaction Records**: Immutable transaction data using C# records
- **Interface-based Processing**: Multiple transaction processors implementing `ITransactionProcessor`
- **Inheritance Control**: Base `Account` class with sealed `SavingsAccount` specialization
- **Data Integrity**: Protected balance setter and transaction validation
- **Modular Design**: Clean separation of concerns using interfaces and inheritance

## Architecture

### Core Models
- `Transaction` - Record type representing financial transactions
- `Account` - Base class for account management
- `SavingsAccount` - Sealed class with specialized transaction handling

### Transaction Processors
- `BankTransferProcessor` - Handles bank transfer transactions
- `MobileMoneyProcessor` - Handles mobile money transactions  
- `CryptoWalletProcessor` - Handles cryptocurrency transactions

### Main Application
- `FinanceApp` - Orchestrates the system simulation
- `Program` - Entry point with user interaction

## How to Run

1. Ensure you have .NET 8.0 SDK installed
2. Navigate to the project directory
3. Run the following commands:

```bash
dotnet build
dotnet run
```

## Sample Output

The system will:
1. Create a savings account with $1000 initial balance
2. Process three sample transactions (Groceries, Utilities, Entertainment)
3. Apply transactions using different processors
4. Display balance updates and transaction summaries

## Design Patterns Used

- **Interface Segregation**: `ITransactionProcessor` for different payment methods
- **Inheritance**: Base `Account` class with specialized `SavingsAccount`
- **Sealed Classes**: Prevents further inheritance of `SavingsAccount`
- **Records**: Immutable transaction data with value semantics
- **Polymorphism**: Virtual methods with overrides for specialized behavior
