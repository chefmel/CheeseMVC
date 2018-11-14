using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Desc { get; set; } 
        public int cheeseId { get; set; }
        public object Type { get; internal set; }

        private static int nextId = 1;

        public Cheese()
        {
            cheeseId = nextId;
            nextId++;
        }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }
            return true;
        }
    }
}
