using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Account
    {
        public string Name{ get; set; }

        public decimal Balance { get; set; }

        public void CreateAccount(string name)
        {
            Name = name;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    Account objacc = obj as Account;
        //    if (objacc == null) return false;
        //    else return Equals(objacc);
        //}

        //public bool Equals(Account other)
        //{
        //    if (other == null) return false;
        //    return (this.Name.Equals(other.Name));
        //}

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }
}
