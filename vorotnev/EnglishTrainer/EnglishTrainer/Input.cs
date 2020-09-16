using System;
using System.Collections.Generic;

namespace EnglishTrainer
{
    public class Input
    {
        public Input()
        {
            WordsPair wordsPair1 = new WordsPair("one", "один");
            WordsPair wordsPair2 = new WordsPair("two", "два");
            WordsPair wordsPair3 = new WordsPair("three", "три");
            WordsPair wordsPair4 = new WordsPair("four", "четыре");
            WordsPair wordsPair5 = new WordsPair("five", "пять");
            
            List<WordsPair> wordsPairsList = new List<WordsPair>();
            wordsPairsList.Add(wordsPair1);
            wordsPairsList.Add(wordsPair2);
            wordsPairsList.Add(wordsPair3);
            wordsPairsList.Add(wordsPair4);
            wordsPairsList.Add(wordsPair5);
            
            WordsPairs wordsPairs = new WordsPairs(wordsPairsList);
        }

        public static bool GetUserAnswer()
        {
            var input = Console.ReadLine();
            if (input == "1")
                return true;
            return false;
        }
    }
}