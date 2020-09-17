using System;
using System.Collections.Generic;

namespace EnglishTrainer
{
    public class Input
    {
        public static WordsPairs GetWordsPairs()
        {
            WordsPair wordsPair1 = new WordsPair("one", "один", true);
            WordsPair wordsPair2 = new WordsPair("two", "два", true);
            WordsPair wordsPair3 = new WordsPair("three", "три", true);
            WordsPair wordsPair4 = new WordsPair("four", "четыре", true);
            WordsPair wordsPair5 = new WordsPair("five", "пять", true);
            
            List<WordsPair> wordsPairsList = new List<WordsPair>();
            wordsPairsList.Add(wordsPair1);
            wordsPairsList.Add(wordsPair2);
            wordsPairsList.Add(wordsPair3);
            wordsPairsList.Add(wordsPair4);
            wordsPairsList.Add(wordsPair5);
            
            WordsPairs wordsPairs = new WordsPairs(wordsPairsList);
            return wordsPairs;
        }

        public static bool GetUserAnswer()
        {
            var input = Console.ReadLine();
            if (input == "1")
                return true;
            return false;
        }

        public static bool[] GetUserAnswersForSprintMode(int numberOfWords)
        {
            var userAnswersForSprintMode = new bool[numberOfWords];
            for (int i = 0; i > numberOfWords; i++)
            {
                var input = Console.ReadLine();
                if (input == "1" || input == "Да")
                    userAnswersForSprintMode[i] = true;
                else
                    userAnswersForSprintMode[i] = false;
            }

            return userAnswersForSprintMode;
        }
    }
}