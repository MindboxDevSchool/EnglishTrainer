using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TranslationEnglishToRussianTrainingMethods;

namespace EnglishTraining
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите режим тренировки: \n1. Ручной перевод\n2. Спринт");
            int index = Convert.ToInt32(Console.ReadLine());
            var translation = ParsingCsv("DictionaryData_EN-RU.csv");
            int correctCount = 0;
            switch (index)
            {
                case 1:
                    correctCount = ManualAndSprintModes.ManualTranslation(translation);
                    break;
                case 2:
                    correctCount = ManualAndSprintModes.SprintTranslation(translation);
                    break;
            }
            Console.WriteLine("Count of correct words: " + correctCount);
        }
        private static List<Parsing> ParsingCsv(string path)
        {
            return File.ReadAllLines(path)
                .Where(row => row.Length > 0)
                .Select(Parsing.ParseRow).ToList();
        }
    }
}