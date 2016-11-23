using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twenty1.Models
{
    public class GameViewModel
    {
        public Deck deck_id { get; set; }

        public Person Dealer { get; set; }

        public Person Player { get; set; }
    }
}