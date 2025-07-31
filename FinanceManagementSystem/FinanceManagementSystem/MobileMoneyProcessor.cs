using System;

namespace FinanceManagementSystem
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing GHS{transaction.Amount} for '{transaction.Category}' via Mobile Money.");
        }
    }
}
