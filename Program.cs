using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class Program
    {
        public static void shuffle(string[] card, int len)
        {
            Random rand = new Random();

            for (int i = 0; i < len; i++)
            {

                // Random for remaining positions.
                int r = i + rand.Next(len - i);

                //swapping the elements
                string temp = card[r];
                card[r] = card[i];
                card[i] = temp;

            }
        }
        public static void paint_borad(string[,] arr)
        {

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("[" + arr[i, j] + "] \t");

                }
                Console.WriteLine("\n");
            }

        }
        public static void main_game(int len)
        {
            Console.WriteLine("How much players play");
            
            int play = int.Parse(Console.ReadLine());
            int[] score = new int[play];
            int cards = (len * len) / 2;
            string val;
            string[] abc = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Xx", "Y", "Z", "a", "b", "c", "d", "e", "j" };
            string[] abc_board = new string[len * len];
            for (int i = 0, j = 0; i < abc_board.Length; i += 2, j++)
            {
                abc_board[i] = abc[j];
                abc_board[i + 1] = abc[j];
            }
            shuffle(abc_board, abc_board.Length);
            int active_player = 0;
            string[] user_choice = new string[4];
            string[,] board = new string[len, len];
            Console.WriteLine("Player " + (active_player + 1) + " turn");
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.Write("[X] \t");
                    board[i, j] = "X";
                }
                Console.WriteLine("\n");
            }
            do
            {
                val = "";
                Console.WriteLine("Enter card1 shora,amoda");
                val = Console.ReadLine();
                Console.WriteLine("Enter card2 shora,amoda");
                val += "," + Console.ReadLine();
                user_choice = val.Split(',');
                if (board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] == "0")
                {
                    do
                    {
                        Console.WriteLine("This card1 is already been chosen, enter line and colume again");
                        user_choice[0] = Console.ReadLine();
                        user_choice[1] = Console.ReadLine();
                    }
                    while (board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] == "0");
                }
                else if (board[int.Parse(user_choice[2]), int.Parse(user_choice[3])] == "0")
                {
                    do
                    {
                        Console.WriteLine("This card2 is already been chosen, enter line and colume again");
                        user_choice[2] = Console.ReadLine();
                        user_choice[3] = Console.ReadLine();
                    }
                    while (board[int.Parse(user_choice[2]), int.Parse(user_choice[3])] == "0");
                }
                board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] = abc_board[(len*int.Parse(user_choice[0]))+int.Parse(user_choice[1])];
                board[int.Parse(user_choice[2]), int.Parse(user_choice[3])] = abc_board[(len * int.Parse(user_choice[2])) + int.Parse(user_choice[3])];
                Console.WriteLine("Player " + (active_player + 1) + " chose card 1 line " + user_choice[0] + " colum " + user_choice[1]);
                Console.WriteLine("Player " + (active_player + 1) + " chose card 2 line " + user_choice[2] + " colum " + user_choice[3]);
                paint_borad(board);
                Console.Write("press any key");
                Console.ReadLine();
                if (board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] == board[int.Parse(user_choice[2]), int.Parse(user_choice[3])])
                {
                    board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] = "0";
                    board[int.Parse(user_choice[2]), int.Parse(user_choice[3])] = "0";
                    cards -= 2;
                    score[active_player]++;
                }
                else
                {
                    board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] = "X";
                    board[int.Parse(user_choice[2]), int.Parse(user_choice[3])] = "X";

                    Console.WriteLine("Player " + (active_player + 1) + " score is " + score[active_player]);

                    if (active_player == score.Length-1)
                    {
                        active_player = 0;
                    }
                    else
                    {
                        active_player++;
                    }
                }
                Console.WriteLine("Player " + (active_player + 1) + " turn");
                paint_borad(board);

            } while (cards != 0);
            int max = score.Max();
            val = null;
            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] == max)
                {
                    val += i + ",";
                }
            }
            if (val.Length > 2)
            {
                Console.WriteLine("Players " + val + " in tie");
            }
            else
            {
                Console.WriteLine("Player " + val + " Won");
            }

        }
        static void Main(string[] args)
        {
            int flag = 0;
            int len;
            do
            {
                Console.WriteLine("Enter board length between 2, 4, 6, 8");
                len = int.Parse(Console.ReadLine());
                if (len % 2 == 0 && len > 1 && len < 9)
                {
                    flag++;
                }
            } while (flag != 1);

            main_game(len);
            Console.ReadLine();
        }
    }
}
