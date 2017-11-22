using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SupportBank
{
    class Program
    {
        static List<Account> accounts = new List<Account>();
        static Transaction tran = new Transaction();
        static List<Transaction> transactions = new List<Transaction>();

        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"c:\work\training\supportbank\transactions2014.csv"))
            {
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    DateTime dt;
                    bool success = DateTime.TryParse(values[0], out dt);
                    tran.Date = dt;
                    tran.From = values[1];
                    tran.To = values[2];
                    tran.Narrative = values[3];
                    decimal amt;
                    if (decimal.TryParse(values[4], out amt))
                    {
                        tran.Amount = amt;
                    }

                    transactions.Add(new Transaction(dt, values[1], values[2], values[3], amt));

                    if (!accounts.Any(a => a.Name == values[1]))
                    {
                        accounts.Add(new Account() { Name = values[1], Balance = 0 });
                    }

                    if (!accounts.Any(a => a.Name == values[2]))
                    {
                        accounts.Add(new Account() { Name = values[2], Balance = 0 });
                    }
                }

                ProcessTransactions();

                DisplayMenu();

                do
                {
                    string entryLine = Console.ReadLine();
                    switch (entryLine.Substring(0,5))
                    {
                        case "ListA":
                            ListAll();
                            break;
                        case "List[":
                            ListAccount(entryLine);
                            break;
                    }
                } while (true);
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("ListAll or List[AccountName]");
        }

        public static void ProcessTransactions()
        {
            foreach (var t in transactions)
            {
                accounts.Find(a => a.Name == t.To).Deposit(t.Amount);
                accounts.Find(a => a.Name == t.From).Withdraw(t.Amount);
            }
        }

        public static void ListAll()
        {
            foreach (var a in accounts)
            {
                Console.WriteLine(a.Name + ' ' + a.Balance);
            }
            //Console.ReadLine();
        }

        public static void ListAccount(string userName)
        {
            userName = userName.Substring(5, userName.Length - 6); 
            var userList = transactions.FindAll(tr => tr.To == userName).Union(transactions.FindAll(tran => tran.From == userName));
            foreach (var t in userList)
            {
                Console.WriteLine(t.Amount + " " + t.From + ' ' + t.To + ' ' + t.Narrative + ' ' + t.Date);
            }
        }
    }
}
