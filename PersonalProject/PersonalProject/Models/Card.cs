using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Models
{
    public class Card
    {
        public string Suit { get; }
        public int Value { get; }
        public bool FaceUp { get; private set; }
        public string FaceValue
        {
            get
            {
                switch (Value)
                {
                    case 1:
                        return "Ace";

                    //case 2:
                    //    return "Two";
                    //case 3:
                    //    return "Three";
                    //case 4:
                    //    return "Four";
                    //case 5:
                    //    return "Five";
                    //case 6:
                    //    return "Six";
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    default:
                        return Value.ToString();
                }
            }
        }

        public Card(int value, string suit)
        {
            Value = value;
            Suit = suit;
            FaceUp = false;
        }
        public bool Flip()
        {
            FaceUp = !FaceUp;
            return FaceUp;
        }
        public bool Equals(Card input)
        {
            return this.Value == input.Value && Suit == input.Suit;
        }
        public override string ToString()
        {
            return FaceValue + " of " + Suit;
        }
    }
}
