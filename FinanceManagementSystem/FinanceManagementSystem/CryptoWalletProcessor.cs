using System;

namespace FinanceManagementSystem
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing GHS{transaction.Amount} for '{transaction.Category}' via Crypto Wallet.");
        }
    }
}
