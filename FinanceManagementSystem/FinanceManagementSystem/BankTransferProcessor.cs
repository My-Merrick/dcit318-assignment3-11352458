using System;

namespace FinanceManagementSystem
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing GHS{transaction.Amount} for '{transaction.Category}' via Bank Transfer.");
        }
    }
}
