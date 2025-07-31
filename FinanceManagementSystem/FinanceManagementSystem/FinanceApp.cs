using System;
using System.Collections.Generic;

namespace FinanceManagementSystem
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void Run()
        {
            // Create SavingsAccount with initial balance
            SavingsAccount account = new SavingsAccount("ACC12345", 1000m);

            // Create 3 transactions
            Transaction t1 = new Transaction(1, DateTime.Now, 200m, "Groceries");
            Transaction t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
            Transaction t3 = new Transaction(3, DateTime.Now, 150m, "Entertainment");

            // Process each transaction with a different processor
            ITransactionProcessor processor1 = new MobileMoneyProcessor();
            processor1.Process(t1);

            ITransactionProcessor processor2 = new BankTransferProcessor();
            processor2.Process(t2);

            ITransactionProcessor processor3 = new CryptoWalletProcessor();
            processor3.Process(t3);

            // Apply each transaction to the account
            account.ApplyTransaction(t1);
            account.ApplyTransaction(t2);
            account.ApplyTransaction(t3);

            // Add transactions to record
            _transactions.Add(t1);
            _transactions.Add(t2);
            _transactions.Add(t3);

            Console.WriteLine("All transactions processed and recorded.");
        }
    }
}
