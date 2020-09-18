using System;

namespace EnglishTrainer.Infrastructure
{
    public static class DefaultUserInteractor
    {
        public static bool ConsoleTrainer(string englishWord, string proposedTranslation)
        {
            Console.WriteLine($"Слово {englishWord} в переводе означает {proposedTranslation}, верно?");
            int answer;
            do
            {
                Console.WriteLine("Если верно введите 1, если неверно - 2");
                int.TryParse(Console.ReadLine(),  out answer);
            } while (answer != 1 && answer != 2);
            return answer == 1;
        }

        public static void ConsoleResult((int, int) result)
        {
            Console.WriteLine(result.Item2);
            Console.WriteLine(result.Item2 == 0
                ? "Нет новых слов для изучения"
                : $"Правильно отвечено {result.Item1} из {result.Item2}");
        }
    }
}