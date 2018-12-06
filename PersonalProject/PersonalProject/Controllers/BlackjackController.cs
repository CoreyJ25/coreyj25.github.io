using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.Models;
using PersonalProject.Extensions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalProject.Controllers
{
    public class BlackjackController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public IActionResult DealANewCard()
        {
            TableModel gameState = GetGameState();

            //Let's make sure we're not going to run out of cars
            if (gameState.Players.Count <= gameState.MyDeck.Cards.Count)
            {
                foreach (Player player in gameState.Players)
                {
                    player.Hand.Add(gameState.MyDeck.DealOne());
                }
            }
            UpdateGameState(gameState);

            return View(gameState);
        }




        const string BLACKJACK_SESSION_ID = "BlackjackTable";

        private TableModel GetGameState()
        {
            TableModel table = HttpContext.Session.Get<TableModel>(BLACKJACK_SESSION_ID);

            //if no table exists in the session yet
            if (table == null)
            {
                table = new TableModel();
                //currently hardcoding the number of players
                int numberOfPlayers = 2;
                table.InitializeBlackJack(numberOfPlayers);
                UpdateGameState(table);
            }

            return table;
        }

        private void UpdateGameState(TableModel table)
        {
            HttpContext.Session.Set(BLACKJACK_SESSION_ID, table);
        }
    }
}
