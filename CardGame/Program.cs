
using CardGame;



var playAgain = false;
do
{
    var game = new Game();
    game.Play();
    Console.WriteLine();
    Console.WriteLine("Do You Want to Play Again ? If yes press Y/y");
    var input = Console.ReadLine().ToLower();
    if (input == "y")
    {
        Console.Clear();
        playAgain = true;
    }
    else
    {
        playAgain = false;
    }
} while (playAgain);
