using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Models
{
    public class TableModel
    {
        public Deck MyDeck { get; set; }
        public Deck DiscardPile { get; set; }
        public List<Player> Players { get; set; }
        

        //todo: Remove this
        public Card TestCard { get; set; }

        public TableModel()
        {
            MyDeck = new Deck();
            DiscardPile = new Deck();
        }
        
        //Currently only adding one card in this method because I'm making the assumption that 
        //the DealANewCard view is the first place the players can see their hands
        //and currently it adds a new card immediately
        //todo: put in view to display initial table? Or use redirecting methods to act on Game State 
        //then return to display board method?
        public void InitializeBlackJack(int playerCount)
        {
            //I want to be sure that we have a new empty deck before adding cards to it
            MyDeck = new Deck();
            DiscardPile = new Deck();
            MyDeck.MakeStandardDeck();
            
            Players = new List<Player>();
            //deal everyone their first card
            for(int i = 0; i < playerCount; i++)
            {
                Players.Add(new Player()
                {
                    Name = "Player " + (i + 1),
                    Hand = new List<Card>()

                });
                Players[i].Hand.Add(MyDeck.DealOne());
            }
            //deal everyone their 2nd card
            //redundent for the moment
            //foreach(Player person in Players)
            //{
            //    person.Hand.Add(MyDeck.DealOne());
            //}

        }

    }
}
