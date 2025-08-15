using System;

namespace FinanceManagementSystem
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Bank Transfer: Processing transaction #{transaction.Id} - Amount: ${transaction.Amount:F2} for {transaction.Category}");
        }
    }
}
