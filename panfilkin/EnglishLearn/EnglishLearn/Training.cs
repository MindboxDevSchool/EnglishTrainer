using System;

namespace EnglishLearn
{
    public abstract class Training
    {
        public int CountOfWordsToCheck { get; protected set; }
        protected readonly WordsData WordsToLearn;
        protected readonly LearningStatistics LearningStatistics;

        protected Training(WordsData wordsToLearn)
        {
            WordsToLearn = wordsToLearn;
            LearningStatistics = new LearningStatistics();
        }

        public abstract LearningStatistics StartTraining();

        protected static string ReadLine()
        {
            // Idk how to test this stuff overriding console input 
            return "true";
            // return Console.ReadLine().Trim().ToLower();
        }
    }

    public class SprintTraining : Training
    {
        public SprintTraining(WordsData wordsToLearn): base(wordsToLearn)
        {
            CountOfWordsToCheck = 15;
        }
        
        public override LearningStatistics StartTraining()
        {
            for (var i = 0; i < CountOfWordsToCheck; i++)
            {
                var englishWord = WordsToLearn.GetRandomWordPair().Key;
                var russianWord = WordsToLearn.GetRandomWordPair().Value;
                var userInput = ReadLine();
                if (englishWord == WordsToLearn.GetEnglishTranslateOfRussianWord(russianWord) && userInput == "true")
                {
                    LearningStatistics.IncreaseLearningStatisticsForWord(englishWord);
                }
            }

            return LearningStatistics;
        }
    }
    
    public class TranslatorTraining : Training
    {
        public TranslatorTraining(WordsData wordsToLearn): base(wordsToLearn)
        {
            CountOfWordsToCheck = 10;
        }
        
        public override LearningStatistics StartTraining()
        {
            for (int i = 0; i < CountOfWordsToCheck; i++)
            {
                var (englishWord, russianWord) = WordsToLearn.GetRandomWordPair();

                Console.WriteLine(englishWord);
                var userDecision = ReadLine();
                if (userDecision == russianWord)
                {
                    LearningStatistics.IncreaseLearningStatisticsForWord(englishWord);
                }
            }

            return LearningStatistics;
        }
        
    }
}