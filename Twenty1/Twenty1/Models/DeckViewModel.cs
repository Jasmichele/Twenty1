using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twenty1.Models
{
    public class DeckViewModel
    {
        public Deck myDeck { get; set; }
        public List<Card> Cards { get; set; }
    }
}