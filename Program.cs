using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    public class Player
    {
        public int name;
        public string move;
        public List<int> games = new List<int>();
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<Player> players = new List<Player>();

        for (int i = 0; i < N; i++)
        {
            Player p = new Player();
            string[] inputs = Console.ReadLine().Split(' ');
            p.name = int.Parse(inputs[0]);
            p.move = inputs[1];
            players.Add(p);
        }


        int j = 0;
        while (players.Count > 1)
        {
            if (players[j].move == players[j + 1].move) //if both players have the same move low number wins
            {
                if (players[j].name < players[j + 1].name)
                {
                    players[j].games.Add(players[j + 1].name);
                    players.RemoveAt(j + 1);
                }
                else
                {
                    players[j + 1].games.Add(players[j].name);
                    players.RemoveAt(j);
                }

            }
            else if (players[j].move == "R")//Player 1 is Rock
            {
                if (players[j + 1].move == "P" || players[j + 1].move == "S") // if player 2 is paper or Spock, player 2 wins
                {
                    players[j + 1].games.Add(players[j].name);
                    players.RemoveAt(j);
                }

                else // if player 2 is lizarad or Scissors, player 1 wins
                {
                    players[j].games.Add(players[j + 1].name);
                    players.RemoveAt(j + 1);
                }
            }
            else if (players[j].move == "P")//Player 1 is paper
            {
                if (players[j + 1].move == "C" || players[j + 1].move == "L") // if player 2 is Scissors or Lizard, player 2 wins
                {
                    players[j + 1].games.Add(players[j].name);
                    players.RemoveAt(j);
                }
                else // if player 2 is Rock or Spock, player 1 wins
                {
                    players[j].games.Add(players[j + 1].name);
                    players.RemoveAt(j + 1);
                }
            }
            else if (players[j].move == "S")//Player 1 is Spock
            {
                if (players[j + 1].move == "P" || players[j + 1].move == "L") // if player 2 is Paper or Lizard, player 2 wins
                {
                    players[j + 1].games.Add(players[j].name);
                    players.RemoveAt(j);
                }
                else // if player 2 is Rock or Scissors, player 1 wins
                {
                    players[j].games.Add(players[j + 1].name);
                    players.RemoveAt(j + 1);
                }
            }
            else if (players[j].move == "L")//Player 1 is Lizard
            {
                if (players[j + 1].move == "C" || players[j + 1].move == "R") // if player 2 is Scissors or Rock, player 2 wins
                {
                    players[j + 1].games.Add(players[j].name);
                    players.RemoveAt(j);
                }
                else // if player 2 is Paper or Spock, player 1 wins
                {
                    players[j].games.Add(players[j + 1].name);
                    players.RemoveAt(j + 1);
                }
            }
            else if (players[j].move == "C")//Player 1 is Scissors
            {
                if (players[j + 1].move == "S" || players[j + 1].move == "R") // if player 2 is Spock or Rock, player 2 wins
                {
                    players[j + 1].games.Add(players[j].name);
                    players.RemoveAt(j);
                }
                else // if player 2 is Lizard or paer, player 1 wins
                {
                    players[j].games.Add(players[j + 1].name);
                    players.RemoveAt(j + 1);
                }
            }

            j = j + 1 >= players.Count - 1 ? 0 : j + 1;

            //Console.WriteLine("Count {0} , j {1}", players.Count, j);
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(players.ElementAt(0).name);
        Console.WriteLine(string.Join(" ", players[0].games));
    }
}