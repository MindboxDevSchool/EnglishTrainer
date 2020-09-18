using System;

namespace EnglishTrainer
{
    public class Output
    {
        public static void OutputTextLine(string text)
        {
            Console.WriteLine(text);
        }

        public static void OutputGeneratedWordsPairs(int mode, WordsPair[] generatedWordsPairs)
        {
            switch (mode)
            {
                case 0:
                    OutputSprintGeneratedWordsPairs(generatedWordsPairs);
                    break;
                case 1:
                    OutputManualTranslationGeneratedWords(generatedWordsPairs);
                    break;
            }
        }
        
        public static void OutputSprintGeneratedWordsPairs(WordsPair[] generatedWordsPairs)
        {
            foreach (var wordsPair in generatedWordsPairs)
            {
                Console.WriteLine($"{wordsPair._englishWord}, {wordsPair._russianWord}");
            }
        }

        public static void OutputManualTranslationGeneratedWords(WordsPair[] generatedWordsPairs)
        {
            foreach (var wordsPair in generatedWordsPairs)
            {
                Console.WriteLine($"{wordsPair._englishWord}");
            }
        }

        public static void OutputFinalResult(int userScore, int numberOfWords)
        {
            Console.WriteLine($"Вы правильно перевели {userScore} слов, неправильно - {numberOfWords}");
        }
    }
}