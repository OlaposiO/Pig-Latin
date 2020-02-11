using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExtraLabWeek4
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            bool validInput = false;
            do
            {
                Console.WriteLine("Pig Latin translator.");
                do
                {
                    Console.Write("Give me a word: ");
                    userInput = Console.ReadLine();

                    if (ValidInput(userInput) && ContainsVowel(userInput))
                    {
                        PigLatin(userInput);
                        validInput = true;
                    }
                    else
                    {
                        Console.Write("I'm sorry. There are a few reason why this error may have happened. \n1. You entered a word with no vowels. (\"y\" is not a vowel.) \n2. You entered a word with numbers or symbols \nPlease enter a new word: ");
                        validInput = false;
                    }
                } while (validInput == false);

            } while (Continue_Program());
        }

        static void PigLatin(string word)
        {
            Stack<char> stack = new Stack<char>();
            string[] multiWords = word.Split(" ");
            foreach (var item in multiWords)
            {
                char[] wordArray = item.ToCharArray();
                string output = "";
                string otherOutPut = "";

                char[] firstLetter = item.ToCharArray();
                string firstConst = "";

                if (isVowel(firstLetter[0]))
                {
                    Console.Write(item + "way ");
                }
                else
                {
                    int i = 0;
                    
                    do
                    {
                        if (!isVowel(wordArray[i]))
                        {
                            firstConst += wordArray[i];
                            i++;
                        }

                    } while (!isVowel(wordArray[i]));

                    for (int j = firstConst.Length; j < wordArray.Length; j++)
                    {
                        output += wordArray[j];
                    }
                    //for (int i = wordArray.Length - 1; i > 0; i--)
                    //{
                    //    output += wordArray[i];
                    //}
                    otherOutPut = $"{output}{firstConst}ay ";

                    Console.Write($"{otherOutPut} ");
                }
            }
            


        }

        static bool ValidInput(string input)
        {
            string pattern = @"^[A-Za-z ]*$";


            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }

            return false;

        }

        static bool isVowel(char l)
        {
            return (l == 'a' || l == 'A' || l == 'e'
            || l == 'E' || l == 'i' || l == 'I'
            || l == 'o' || l == 'O' || l == 'u'
            || l == 'U');
        }

        static bool ContainsVowel(string input)
        {

            string pattern = @"[AEIUOaeiou]+";
            
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }

            return false;
        }

        static bool Continue_Program()
        {
            char c;
            do
            {
                
                Console.Write("\nWould you like to do another word? (y/n)? << ");
                c = Console.ReadKey().KeyChar;
                if (c == 'n' || c == 'N')
                {
                    Console.WriteLine("\nGoodBye");
                    return false;
                }
                Console.WriteLine();
            } while (c != 'y' && c != 'Y');
            return true;
        }
    }
}
