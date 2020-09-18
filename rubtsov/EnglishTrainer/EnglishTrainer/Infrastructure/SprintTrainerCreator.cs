using System;
using EnglishTrainer.Domain;

namespace EnglishTrainer.Infrastructure
{
    public class SprintTrainerCreator
    {
        private IWordsRepository WordsRepository { get; }
        private Func<string, string, bool> UserInteractor { get; }
        private int WordsPerTraining { get; }
        private ITrainingSession TrainingSession { get; }
        public (int, int) TrainingResult { get; private set; }

        public SprintTrainerCreator(string filename, Func<string, string, bool> userInteractor, int wordsPerTraining = 5)
        {
            UserInteractor = userInteractor;
            WordsPerTraining = wordsPerTraining;
            WordsRepository = new SprintTrainerWordsRepository(filename, WordsPerTraining);
            TrainingSession = new SprintTrainingSession(WordsRepository, UserInteractor, WordsPerTraining);
        }

        public void StartTraining()
        {
            TrainingResult = TrainingSession.StartTrainingSession();
        }
    }
}