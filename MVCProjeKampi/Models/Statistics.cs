using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjeKampi.Models
{
    public class Statistics
    {
        public int CategoryCount { get; set; }
        public int YazilimHeadingCount{ get; set; }

        public int WriterACount { get; set; }

        public string  MostHeadingCategory { get; set; }

        public int SubCtgStatus { get; set; }
    }
}