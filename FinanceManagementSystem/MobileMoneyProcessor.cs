using System;

namespace FinanceManagementSystem
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Mobile Money: Processing transaction #{transaction.Id} - Amount: ${transaction.Amount:F2} for {transaction.Category}");
        }
    }
}
