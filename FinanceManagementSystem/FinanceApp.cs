using System;
using System.Collections.Generic;

namespace FinanceManagementSystem
{
    public class FinanceApp
    {
        private List<Transaction> _transactions;
        
        public FinanceApp()
        {
            _transactions = new List<Transaction>();
        }
        
        public void Run()
        {
            // i. Instantiate a SavingsAccount with account number and initial balance
            var savingsAccount = new SavingsAccount("SA001", 1000);
            Console.WriteLine($"Initial account balance: ${savingsAccount.Balance:F2}");
            Console.WriteLine();
            
            // ii. Create three Transaction records with sample values
            var transaction1 = new Transaction(1, DateTime.Now, 150.00m, "Groceries");
            var transaction2 = new Transaction(2, DateTime.Now, 75.50m, "Utilities");
            var transaction3 = new Transaction(3, DateTime.Now, 200.00m, "Entertainment");
            
            // iii. Use processors to process each transaction
            var mobileMoneyProcessor = new MobileMoneyProcessor();
            var bankTransferProcessor = new BankTransferProcessor();
            var cryptoWalletProcessor = new CryptoWalletProcessor();
            
            Console.WriteLine("Processing transactions:");
            mobileMoneyProcessor.Process(transaction1);
            bankTransferProcessor.Process(transaction2);
            cryptoWalletProcessor.Process(transaction3);
            Console.WriteLine();
            
            // iv. Apply each transaction to the SavingsAccount
            Console.WriteLine("Applying transactions to account:");
            savingsAccount.ApplyTransaction(transaction1);
            savingsAccount.ApplyTransaction(transaction2);
            savingsAccount.ApplyTransaction(transaction3);
            Console.WriteLine();
            
            // v. Add all transactions to _transactions
            _transactions.Add(transaction1);
            _transactions.Add(transaction2);
            _transactions.Add(transaction3);
            
            Console.WriteLine($"Final account balance: ${savingsAccount.Balance:F2}");
            Console.WriteLine($"Total transactions processed: {_transactions.Count}");
        }
    }
}
