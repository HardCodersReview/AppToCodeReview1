using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Wallet
    {
        public int WalletID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public double TotalCredits { get; set; }
        
        public List<Card> Cards { get;}
                            
    }
}
