using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static private List<CheeseModel> Cheeses = new List<CheeseModel>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("/Cheese/Add")]

        public IActionResult NewCheese(string name, string desc)
        {
            CheeseModel cm = new CheeseModel();
            cm.name = name;
            cm.desc = desc;
            if (cm.IsValid())
            {
                //add new cheese to existing cheeses
                Cheeses.Add(cm);
                return Redirect("/Cheese");
            }

            return Redirect("/Cheese");
        }
        public IActionResult Remove()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }
        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveCheese(string name, string cheeseToRemove)
        {
            //remove new cheese to existing cheeses
            foreach (var item in Cheeses)
            {
                if (item.name == name || item.name == cheeseToRemove)
                {
                    Cheeses.Remove(item);
                    break;
                }
            }

            return Redirect("/Cheese");
        }

       
    }

    public class ViewList
    {

    }
}
