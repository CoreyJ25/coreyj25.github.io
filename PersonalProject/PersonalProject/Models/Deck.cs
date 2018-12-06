using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Models
{
    public class Deck
    {
        public List<Card> Cards { get; } = new List<Card>();


        public enum CardValue
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
        };
        public List<string> Suits = new List<string>()
        {
            "Spades",
            "Clubs",
            "Diamonds",
            "Hearts"
        };

        public void MakeStandardDeck()
        {
            foreach (string suit in Suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Cards.Add(new Card(i, suit));
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            Random r = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int random = r.Next(i);
                Card temp = Cards[i];
                Cards[i] = Cards[random];
                Cards[random] = temp;
            }
        }
        public Card DealOne()
        {
            if (Cards == null || Cards.Count == 0)
            {
                return null;
            }
            Card output = Cards[0];
            Cards.RemoveAt(0);
            return output;
        }
        public bool ContainsInDeck(Card toBeChecked)
        {
            foreach (Card card in Cards)
            {
                if (card.Equals(toBeChecked))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ShuffleBackIn(Card toBeShuffled)
        {
            bool completeWithNoErrors = AddCardToBottom(toBeShuffled);


            Shuffle();
            return completeWithNoErrors;
        }
        public bool ShuffleBackIn(List<Card> toBeShuffled)
        {
            bool completeWithNoErrors = true;
            if (toBeShuffled == null)
            {
                completeWithNoErrors = false;
                return completeWithNoErrors;
            }
            foreach (Card card in toBeShuffled)
            {
                completeWithNoErrors = AddCardToBottom(card);
                if (!completeWithNoErrors)
                {
                    return completeWithNoErrors;
                }


            }
            Shuffle();
            return completeWithNoErrors;
        }
        public bool AddCardToBottom(Card toBePutBackIn)
        {
            bool completeWithNoErrors = true;
            if (toBePutBackIn == null)
            {
                completeWithNoErrors = false;
                return completeWithNoErrors;
            }
            if (ContainsInDeck(toBePutBackIn))
            {
                Console.WriteLine("\n\n\nSomeone tried to slip in a card we alread have!!\n\n\n");
                completeWithNoErrors = false;
            }
            else
            {
                Cards.Add(toBePutBackIn);
            }
            return true;
        }

    }
}
