using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //static private List<Cheese> listOfCheeses = new List<Cheese>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }
        [HttpPost]
        //[Route("/Cheese/Add")]

        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
              
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Desc = addCheeseViewModel.Desc,
                    Type = addCheeseViewModel.Type
                };
                CheeseData.Add(newCheese);
                return Redirect("/Cheese");
            }
            return View(addCheeseViewModel);
        }
            
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll(); 
            return View();
        }
        [HttpPost]
       // [Route("/Cheese/Remove")]
        public IActionResult Remove(int[] cheeseIds)
        {
            //remove new cheese to existing cheeses
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/Cheese");
        }

        public IActionResult Edit(int id)
        {
            var cheeseToEdit = CheeseData.GetById(id);
            ViewBag.Title = "Edit Cheese" + cheeseToEdit.Name + " " + cheeseToEdit.cheeseId;
            ViewBag.cheese = cheeseToEdit;
            return View();

        }
        [HttpPost]
        //[Route("/Cheese/Edit")]
        public IActionResult Edit(int cheeseId, string name, string desc)
        {
            var cheeseToUpdate = CheeseData.GetById(cheeseId);
            cheeseToUpdate.Name = name;
            cheeseToUpdate.Desc = desc;
            ViewBag.cheese = CheeseData.GetById(cheeseId);
            return Redirect("/");
        }
       
             
      

    }

   
}
