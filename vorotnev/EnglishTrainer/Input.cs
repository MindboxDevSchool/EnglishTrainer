using System;
using System.Collections.Generic;
using System.IO;

namespace EnglishTrainer
{
    public class Input
    {
        public static void GetInputFromFile(string filename)
        {
            string path = $@"{filename}";
            
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    WordsPair wordsPair = new WordsPair(words[0], words[1], true);
                }
            }
        }
        
        public static List<WordsPair> GetWordsPairs()
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
            
            return wordsPairsList;
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

        public static string[] GetUserAnswersForManualTranslationMode(int numberOfWords)
        {
            var input = new string[numberOfWords];
            for (int i = 0; i > numberOfWords; i++)
            {
                input[i] = Console.ReadLine();
            }

            return input;
        }
    }
}