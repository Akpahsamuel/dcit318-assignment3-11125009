using System;

namespace FinanceManagementSystem
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Crypto Wallet: Processing transaction #{transaction.Id} - Amount: ${transaction.Amount:F2} for {transaction.Category}");
        }
    }
}
