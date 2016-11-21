using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twenty1.Models
{

    public class Person
    {
        public string Name { get; set; }

        public List<Card> Hand { get; set; }

        public string deck_id { get; set; }

        public int HandValue()
        {
            int returnValue = 0;

            foreach (Card c in Hand)
            {

                switch (c.value.ToLower())
                {
                    case "ace":
                        returnValue = returnValue + 1;
                        break;

                    case "king":
                    case "queen":
                    case "jack":
                        returnValue = returnValue + 10;
                        break;
                    default:
                        int num;
                        int.TryParse(c.value, out num);
                        returnValue = returnValue + num;
                        break;
                }
            }

            return returnValue;
        }
    }
}

   
