using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {

            Account acc = new Account();
            List<Account> accounts = new List<Account>();

            Transaction tran = new Transaction();
            List<Transaction> transactions = new List<Transaction>(); 
            
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
                    if(decimal.TryParse(values[4], out amt))
                    {
                        tran.Amount = amt;
                    }

                    transactions.Add(tran);

                    acc.Name = values[1];
                    acc.Balance = decimal.Parse(values[4]);

                    accounts.Add(acc);

                    Console.WriteLine(acc.Name.ToString());
                    Console.WriteLine(acc.Balance.ToString());
                }

            }
          
        }
    }
}
