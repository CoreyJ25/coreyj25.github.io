using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.Models;

namespace PersonalProject.Controllers
{
    public class HomeController : Controller
    {
       

        public HomeController()
        {
            
        }
        //public IActionResult DealANewCard()
        //{
        //    //if(gameState == null)
        //    //{
        //    //    gameState = new TableModel();
        //    //}

        //    gameState.aCard = gameState.MyDeck.DealOne();
        //    gameState.DiscardPile.AddCardToBottom(gameState.aCard);
        //    return View(gameState);
        //}

        



        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
