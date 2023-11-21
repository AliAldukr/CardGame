using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<string> CardsList { get; set; } = new List<string>();
        public List<string> WinningCardsList { get; set; } = new List<string>();
        public KeyValuePair<string, int> WinningCard { get; set; } = new KeyValuePair<string, int>();
        public bool IsWinner { get; set; } = false;
        public double WinnerCardsWeight { get; set; } = 0;

    }
}
