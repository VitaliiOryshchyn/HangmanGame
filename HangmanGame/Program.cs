using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanGame
{
    class Program
    {
        public static string word = "";
        static char[] playerSymbols;
        public static string[] field;
        public static string[] hange = { "  --------", " |        |", " |        O", " |       /|\\ ", " |       / \\", " |\n---" };


        static void Main(string[] args)
        {
            RandomWord();

            Field(word);



            string symbol;
            string playerWord;
            playerSymbols = new char[word.Length];

            Console.Write("Do you wan't see the word?\nEnter Y or N: ");
            if ("Y" == Console.ReadLine().ToUpper())
            {
                Console.WriteLine($"Secret word: {word}");
                Console.WriteLine();
            }

            for (int i = 0; i < 6; i++)
            {
                Console.Write("Enter leter word: ");
                symbol = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (CheckSymbol(symbol))
                {

                    i--;
                    EnterPlayerSymbol(Convert.ToChar(symbol));

                    foreach (var n in field)
                    {
                        Console.Write(n);
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Incorrect");
                    Console.WriteLine("Status of death:");
                    Status(i);
                    Console.WriteLine();
                }

                playerWord = new string(playerSymbols);
                playerWord = playerWord.Replace(((char)0).ToString(), "");

                if (playerWord.Length == word.Length)
                {
                    Console.WriteLine("You win");
                    break;
                }
                if (i == 5)
                {
                    Console.WriteLine("You lose");
                    Console.WriteLine($"Your word it's = {word}");
                }
            }

        }

        static void EnterPlayerSymbol(char symbolWord)
        {

            for (int i = 0; i < word.Length; i++)
            {
                if (symbolWord == word[i])
                {
                    playerSymbols[i] = symbolWord;
                }
            }

        }

        static bool CheckSymbol(string symbol)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (symbol == word[i].ToString().ToLower())
                {
                    PrintField(symbol);
                    return true;
                }
            }
            return false;
        }

        static void PrintField(string symbol)
        {
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (symbol == word[j].ToString().ToLower())
                    {
                        field[j] = field[j].Remove(1, 1).Insert(1, symbol);
                    }

                }
            }
        }

        public static void Field(string word)
        {
            field = new string[word.Length];
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = "|_|";
            }
        }

        public static void Status(int countMissSymbol)
        {
            for (int i = 0; i <= countMissSymbol; i++)
            {
                Console.WriteLine(hange[i]);
            }
        }

        public static void RandomWord()
        {
            string[] words = File.ReadAllLines(@"WordsStockRus.txt");
            Random r = new Random();
            int indexWord = r.Next(0, words.Length);
            word = words[indexWord];
        }
    }
}