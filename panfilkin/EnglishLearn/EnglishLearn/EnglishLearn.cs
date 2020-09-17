using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishLearn
{
    public class EnglishLearn
    {
        private readonly WordsData _wordsTranslationData;
        private readonly LearningStatistics _learningStatistics;

        public EnglishLearn(string pathToWordTranslationCsvFile)
        {
            _wordsTranslationData = WordsDataFactory.MakeWordsDataFromFile(pathToWordTranslationCsvFile);
            _learningStatistics = new LearningStatistics();
        }

        public void StartLearn(string mode)
        {
            var wordsToLearn = new WordsData(GetWordsToLearn());
            Training training = mode switch
            {
                "sprint" => new SprintTraining(wordsToLearn),
                "translator" => new TranslatorTraining(wordsToLearn),
                _ => throw new EnglishLearnException("Mode not found!")
            };

            var trainingStatistics = training.StartTraining();
            WriteStatistics(trainingStatistics);
            UpgradeStatistics(trainingStatistics);
        }

        private Dictionary<string, string> GetWordsToLearn()
        {
            var notLearnedWords = new Dictionary<string, string>();
            foreach (var (englishWord, russianWord) in _wordsTranslationData.GetWordsData())
            {
                if (_learningStatistics.IsWordLearned(englishWord) == false)
                {
                    notLearnedWords.Add(englishWord, russianWord);
                }
            }

            return notLearnedWords;
        }

        private static void WriteStatistics(LearningStatistics learningStatistics)
        {
            Console.WriteLine(learningStatistics.GetLearningStatistics().Keys.First());
        }

        private void UpgradeStatistics(LearningStatistics learningStatistics)
        {
            foreach (var (englishWord, learningStatisticForWord) in learningStatistics.GetLearningStatistics())
            {
                for (int  i = 0;  i < learningStatisticForWord;  i++)
                {
                    _learningStatistics.IncreaseLearningStatisticsForWord(englishWord);
                }
            }
        }

    }
}
