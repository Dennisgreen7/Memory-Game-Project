using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class Program
    {

        public static char[,] game_arr(int len)
        {
            char[,] arr = new char[len, len];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = '1';
                }
            }
            return arr;
        }

        public static void free_space(char[,] arr, char randomChar)
        {
            int a, b;
            Random rnd = new Random();
            int count = 0;
            while (count != 2)
            {
                a = rnd.Next(0, arr.GetLength(0));
                b = rnd.Next(0, arr.GetLength(0));

                if (arr[a, b] == '1')
                {
                    arr[a, b] = randomChar;
                    count++;
                }
            }
        }


        public static void arr_value(char[,] arr, int len)
        {
            int count;
            int zugot = 0;
            char randomChar;
            Random rnd = new Random();
            while (zugot != (len * len) / 2)
            {
                count = 0;
                randomChar = (char)rnd.Next('a', 'z');
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] == randomChar)
                        {
                            count++;
                        }
                    }
                }
                if (count == 0)
                {
                    free_space(arr, randomChar);
                    zugot++;
                }
            }
        }
        public static void paint_borad(string[,] arr)
        {

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j]+" \t");
                    
                }
                Console.WriteLine("\n");
            }

        }
        public static void main_game(int len)
        {
            int active_player = 1;
            char[,] arr = game_arr(len);
            arr_value(arr, len);
            int score1 = 0;
            int score2= 0;
            string val;
            string[] user_choice = new string[4];
            string[,] board = new string[len, len];
            Console.WriteLine("Player " + active_player + " turn");
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

                board[int.Parse(user_choice[0]),int.Parse(user_choice[1])] = arr[int.Parse(user_choice[0]), int.Parse(user_choice[1])].ToString();
                board[int.Parse(user_choice[2]), int.Parse(user_choice[3])] = arr[int.Parse(user_choice[2]), int.Parse(user_choice[3])].ToString();
                paint_borad(board);
                Console.Write("press any key");
                Console.ReadLine();
                if (board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] == board[int.Parse(user_choice[2]), int.Parse(user_choice[3])])
                {
                    board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] = "0";
                    board[int.Parse(user_choice[2]), int.Parse(user_choice[3])] = "0";
                    if(active_player == 1)
                    {
                        if(score1 == ((len * len) / 2) - 1)
                        {
                            Console.WriteLine("The winner is Player 1");
                        }
                        score1++;
                    }
                    else
                    {
                        if (score2 == ((len * len) / 2) - 1)
                        {
                            Console.WriteLine("The winner is Player 2");
                        }
                        score2++;
                    }
                    //score++;
                }
                else
                {
                    board[int.Parse(user_choice[0]), int.Parse(user_choice[1])] = "X";
                    board[int.Parse(user_choice[2]), int.Parse(user_choice[3])] = "X";
                    if(active_player == 1)
                    {
                        Console.WriteLine("Player " + active_player + " score is " + score1);
                        active_player = 2;
                    }
                    else
                    {
                        Console.WriteLine("player " + active_player + " score is " + score2);
                        active_player = 1;
                    }
                }
                paint_borad(board);
                Console.WriteLine("Player " + active_player + " turn");

            } while (score1 != (len * len) / 2 || score2 != (len * len) / 2);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            } 
        }
        static void Main(string[] args)
        {
            int flag = 0;
            int len;
            do
            {
                Console.WriteLine("Enter board length between 2, 4, 6");
                len = int.Parse(Console.ReadLine());
                if (len % 2 == 0 && len > 1 && len < 7)
                {
                    flag++;
                }
            } while (flag != 1);

            main_game(len);
            Console.ReadLine();
        }
    }
}
