using WADProject.Models;
using WADProject.Repositories;

namespace WADProject.Services
{
    public class TransactionService
    {
        protected readonly AccountRepository accounts;
        protected readonly TransactionRepository transactions;

        public TransactionService(AccountRepository accounts, TransactionRepository transactions)
        {
            this.accounts = accounts;
            this.transactions = transactions;
        }

        public void CreateTransaction(Account sender, Account reciever, float balanceChange)
        {
            if (sender.Balance < balanceChange)
            {
                throw new System.Exception("Not enough funds");
            }

            sender.Balance -= balanceChange;
            reciever.Balance += balanceChange;

            accounts.Update(sender);
            accounts.Update(reciever);

            var transaction = new Transaction
            {
                Sender = sender.User,
                Receiver = reciever.User,
                Balance = balanceChange,
                Currency = sender.Currency,
                Date = new System.DateTime()
            };

            transactions.Add(transaction);
        }
    }
}