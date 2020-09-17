using System;

namespace EnglishTrainer
{
    public class Output
    {
        public static void OutputTextLine(string text)
        {
            Console.WriteLine(text);
        }

        public static void OutputGeneratedWordsPairs(WordsPair[] generatedWordsPairs)
        {
            foreach (var wordsPair in generatedWordsPairs)
            {
                Console.WriteLine($"{wordsPair._englishWord}, {wordsPair._russianWord}");
            }
        }
    }
}