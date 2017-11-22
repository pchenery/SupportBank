using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Transaction
    {

        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public Transaction()
        {
            
        }

        public Transaction(DateTime date, string from, string to, string narrative, decimal amount)
        {
            Date = date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        }

        public void Credit(Account acc, decimal amount)
        {
            acc.Deposit(amount);
        }

        public void Debit(Account acc, decimal amount)
        {
            acc.Withdraw(amount);
        }
    }
}
