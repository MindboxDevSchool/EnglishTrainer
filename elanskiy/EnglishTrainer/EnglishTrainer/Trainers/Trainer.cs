using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Vocabularies;
using EnglishTrainer.Contracts;

namespace EnglishTrainer.Trainers
{
    public abstract class Trainer<TIn,TOut> where TIn : ICollection  
    {
        private int _numberOfWordsToStudy;
        private bool _isTrainingOver = false;
        private bool _isTrainingStarted = false;
        protected Vocabulary Vocabulary { get; }
        public int NumberOfWordsToStudy
        {
            get => _numberOfWordsToStudy;
            set
            {
                if (value <= 0)
                    throw new ArgumentException
                        ("Количество изучаемых слов в тренажере должно быть больше нуля");
                _numberOfWordsToStudy = value;
            }
        }
        protected Trainer(Vocabulary vocabulary)
        {
            Vocabulary = vocabulary ?? throw new ArgumentException("Нужен экземпляр словаря!");
        }
        public TOut Start()
        {
            if (_isTrainingStarted)
                throw new ApplicationException("Вы еще не закончили предыдущую тренировку!");
            if (_isTrainingOver)
                throw new ApplicationException("Тренировка закончена!");
            _isTrainingStarted = true;
            return MakeWordsToTrain();
        }
        protected abstract TOut MakeWordsToTrain();
        protected abstract (int correctAnswers, int errorAnswers, List<string> guessedWords) CheckAnswers(TIn answers);
        public Result GetResults(TIn answers)
        {
            if (!_isTrainingStarted)
                throw new ApplicationException("Тренировка еще не началась!");
            _isTrainingOver = true;
            var (correctAnswers, errorAnswers, guessedWords) = CheckAnswers(answers);

            if (guessedWords != null && guessedWords.Count > 0)
                Vocabulary.UpdateNumberOfCorrectlyTranslationsByUser(guessedWords);

            return new Result(errorAnswers, correctAnswers);
        }
    }
}