using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Model
{
    internal class AccountModel : IModel
    {
      

        public int id { get; set; }
        public string customerid { get; set; }
        public DateTime date_opened { get; set; }
        public double balance { get; set; }

        
        public bool IsValidate()
        {
            return true;
        }
    }
}
