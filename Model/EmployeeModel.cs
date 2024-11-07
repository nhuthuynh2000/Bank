using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Model
{
    internal class EmployeeModel : IModel
    {
        public string id { get; set; }
        public string password { get; set; }
        public string role { get; set; }
      
        public bool IsValidate()
        {
            return true;
        }
    }
}
