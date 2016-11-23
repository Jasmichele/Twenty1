﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twenty1.Models
{
    public class CardViewModel
    {
        public string deck_id { get; set; }
        public Person Player { get; set; }
        public Person Dealer { get; set; }
        public int remaining { get; set; }

    }
}