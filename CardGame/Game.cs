using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardGame
{
    public class Game
    {
        public Dictionary<int, string> CardsValue { get; set; }
        public Game()
        {
            CardsValue = new Dictionary<int, string>()
            {
                { 1,"2@" }, {2,"2#" }, {3,"2^" }, {4,"2*" }, {5,"3@" }, {6,"3#" }, {7,"3^" }, {8,"3*" },
                {9,"4@" }, {10,"4#" }, {11,"4^" }, {12,"4*" },{13, "5@" }, {14,"5#" }, {15,"5^" }, {16,"5*" },
                {17,"6@" }, {18,"6#" }, {19,"6^" }, {20,"6*" }, {21,"7@" }, {22,"7#" }, {23,"7^" }, {24,"7*" },
                {25, "8@" }, {26,"8#" }, {27,"8^" }, {28,"8*" }, {29,"9@" }, {30,"9#" }, {31,"9^" }, {32,"9*" },
                {33,"10@" }, {34,"10#" }, {35,"10^" }, {36,"10*" },{37,"J@" }, {38,"J#" }, {39,"J^" }, {40,"J*" },
                {41, "Q@" }, {42,"Q#" }, {43,"Q^" }, {44,"Q*" }, {45,"K@" }, {46,"K#" }, {47,"K^" }, {48,"K*" },
                {49, "A@" }, {50,"A#" }, {51,"A^" }, {52,"A*"}
            };

        }
        public void Play()
        {
           
            var shuffledDeck = CardsValue.Values.ToList().ShuffleCardList();
            Console.WriteLine("Shuffled Cards  ");
            DisplayCards(shuffledDeck);
            var players = DistributeCards(shuffledDeck);
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}");
                player.WinningCard = GetWinningCard(player.CardsList);
                player.WinnerCardsWeight = GetWinningCardsWeight(player.WinningCard.Key);
                player.WinningCardsList = GetWinningCardsList(player.WinningCard.Key, player.CardsList); ;
                DisplayCards(player.CardsList);

            }
            PrintResult(EvaluateWinner(players));
        }

        private List<string> GetWinningCardsList(string key, List<string> cards)
        {
            var winningCardList = cards.Where(x => key.Contains(x[0])).ToList();
            return winningCardList;
        }

        private double GetWinningCardsWeight(string key)
        {
            var cardsDic = CardsValue.Where(x => key.Contains(x.Value[0])).ToDictionary(d => d.Key, d => d.Value).Average(a => a.Key);
            return cardsDic;
        }

        private void DisplayCards(List<string> cards)
        {

            Console.Write($"{String.Join(',', cards)}");
            Console.WriteLine();
            Console.WriteLine("==============================");
        }
        private List<Player> DistributeCards(List<string> cards)
        {
            var players = new List<Player>();
            var player1 = new Player() { Name = "Player 1"};
            var player2 = new Player() { Name = "Player 2"};
            var player3 = new Player() { Name = "Player 3"};
            var player4 = new Player() { Name = "Player 4"};
            for (var i = 0; i < cards.Count; i += 4)
            {
                player1.CardsList.Add(cards[i]);
                player2.CardsList.Add(cards[i + 1]);
                player3.CardsList.Add(cards[i + 2]);
                player4.CardsList.Add(cards[i + 3]);
            }
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            return players;
        }
        private KeyValuePair<string, int> GetWinningCard(List<string> cards)
        {
            var cardsDic = CardsValue.Where(x => cards.Contains(x.Value)).ToDictionary(d => d.Key, d => d.Value);
            var winningCard = cardsDic.GroupBy(x => x.Value[0]).OrderByDescending(g => g.Count()).ThenByDescending(x => x.Sum(s =>s.Key))
                .ToDictionary(d => d.FirstOrDefault().Value , d => d.Count()).FirstOrDefault();
            return winningCard;
        }
        private List<Player> EvaluateWinner(List<Player> players)
        {
            var winnerPlayer = players[0];

            for (var i = 1;i< players.Count; i++)
            {
                if (players[i].WinningCard.Value > winnerPlayer.WinningCard.Value)
                {
                    winnerPlayer = players[i];
                }else if (players[i].WinningCard.Value == winnerPlayer.WinningCard.Value)
                {
                    if (players[i].WinnerCardsWeight > winnerPlayer.WinnerCardsWeight)
                    {
                        winnerPlayer = players[i];
                    }else if(players[i].WinnerCardsWeight == winnerPlayer.WinnerCardsWeight)
                    {
                        if (players[i].WinningCardsList.Where(x => x.Contains("*")).FirstOrDefault()?.Contains("*") ?? false)
                        {
                            winnerPlayer = players[i];
                        }
                    }
                }
            }    
            
            players.Where(x => x.Name == winnerPlayer.Name).FirstOrDefault().IsWinner = true;
            
            return players;
        }
        private void PrintResult(List<Player> players)
        {
            Console.WriteLine("Results: ");
            foreach (var player in players)
            {
                var winner = player.IsWinner ? "Winner" : " ";
                Console.Write($"{player.Name} : {String.Join(',',player.WinningCardsList)} | {winner}");
                Console.WriteLine();
            }
        }
    }
}
