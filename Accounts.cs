using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Accounts
    {
        public List<Account> AccountSet
        {
            get;
            set;
        }

        public List<Account> ListAll()
        {
            return AccountSet;
        }
    }
}
