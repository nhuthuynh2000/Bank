using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Model;

namespace BankSystem.Model
{
    internal class BranchModel : IModel
    {
        public string id { get; set; }
        public string name { get; set; }

        public string house_no { get; set; }
        public string city { get; set; }

        public bool IsValidate() // Tất cả các kiểm tra đều hợp lệ
        {
            return true;
        }
    }


}
