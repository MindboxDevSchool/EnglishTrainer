using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TranslationEnglishToRussianTrainingMethods
{
    public class ManualAndSprintModes : Parsing
    {
         public static int ManualTranslation(List<Parsing> translation)
        {
            int correctCount = 0, iterationCount = 0;

            foreach (var line in translation)
            {
                Parsing randomRow = RowRandomiser(translation);
                Console.WriteLine(randomRow.EnglishWord);
                string answer = Console.ReadLine();
                string[] russianTranslate = randomRow.RussianWord.Split(',');
                correctCount = ManualCompareAnswerWithCorrectWord(russianTranslate, answer.ToLower(), correctCount);
                iterationCount++;
                if (iterationCount >= 10)
                {
                    break;
                }
            }

            return correctCount;
        }

        public static int SprintTranslation(List<Parsing> translation)
        {
            int correctCount = 0, iterationCount = 0;

            foreach (var line in translation)
            {
                Parsing randomRowEng = RowRandomiser(translation);
                Parsing randomRowRus = RowRandomiser(translation);
                SprintModeTaskOutput(randomRowEng.EnglishWord, randomRowRus.RussianWord);
                string answer = Console.ReadLine();
                correctCount = SprintCompareAnswerWithCorrectWord(randomRowEng.RussianWord,
                    randomRowRus.RussianWord, answer.ToLower(), correctCount);

                iterationCount++;
                if (iterationCount >= 10)
                {
                    break;
                }
            }

            return correctCount;
        }

        public static void SprintModeTaskOutput(string englishWord, string russianWord)
        {
            Console.WriteLine("Слово на английском: " + englishWord + "\n" + "Предполагаемый перевод: "
                              + russianWord);
        }

        public static Parsing RowRandomiser(List<Parsing> translation)
        {
            Random random = new Random();
            return translation[random.Next(0, translation.Count - 1)];
        }

        public static int ManualCompareAnswerWithCorrectWord(string[] correct, string answer, int correctCount)
        {
            if (answer == correct[0].ToLower())
            {
                correctCount++;
            }
            else if (correct.Length > 1 && answer == correct[1].ToLower())
            {
                correctCount++;
            }

            return correctCount;
        }

        public static int SprintCompareAnswerWithCorrectWord(string correctTranslate, string comparibleTranslate,
            string answer, int correctCount)
        {
            if (correctTranslate == comparibleTranslate && (answer == "да"
                                                             || answer == "yes")) 
            {
                correctCount++;
            }

            return correctCount;
        }
    }
}