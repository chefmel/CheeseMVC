using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseModel
    {
        public string name { get; set; }
        public string desc { get; set; }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }
    }
}
