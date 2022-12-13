using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Card
    {
        public int CardId { get; set; }
        public double Credits { get; set; }
        public int CardNumber { get; set; }
        public string? CardName { get; set; }
        public int CardValidMonth { get; set; }
        public int CardValidYear { get; set;}
        public int CardCVC { get; set; }
    }
}
