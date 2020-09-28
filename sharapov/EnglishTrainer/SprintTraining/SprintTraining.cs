using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer.SprintTraining {
    public class SprintTraining {
        private readonly int _amountWordsForTraining;
        private readonly double _rightWrongWordsRatio;
        private readonly WordsStorage _wordsStorage;
        private readonly Words _trainingWords;
        private readonly Words _rightAnswers;
        
        //rightWordsRatio should between 0.0 and 1.0
        public SprintTraining(WordsStorage wordsStorage, int amountWordsForTraining = 15, double rightWrongWordsRatio = 0.5d) {
            if (amountWordsForTraining <= 0) {
                throw new ArgumentException(
                    $"{nameof(amountWordsForTraining)} equal zero or less than zero");
            }
            if (rightWrongWordsRatio <= 0.0d || rightWrongWordsRatio >= 1.0d) {
                throw new ArgumentException($"{nameof(rightWrongWordsRatio)} should be between 0.0 and 1.0 exclusive but was {rightWrongWordsRatio}");
            }
            _rightWrongWordsRatio = rightWrongWordsRatio;
            _amountWordsForTraining = amountWordsForTraining;
            _wordsStorage = wordsStorage;
            (_rightAnswers, _trainingWords) = GenerateWordsForTraining();
        }

        //words to user (domain -> infrastructure) 
        public Words GetTrainingWords() {
            return _trainingWords;
        }

        //result from user to domain (infrastructure -> domain) 
        //answers should have same order as a Words from GetTrainingWords()
        public SprintTrainingResult ReportAboutTrainingResult(UserAnswers<bool> userUserAnswers) {
            var result = ProcessUserAnswers(userUserAnswers);
            var infoForUpdateStorage = CreateResultForUpdateStorage(result);
            _wordsStorage.UpdateProgress(infoForUpdateStorage);
            return result;
        }

        private IEnumerable<ResultForUpdateStorage> CreateResultForUpdateStorage(SprintTrainingResult userUserAnswers) {
            var infoForUpdateProgress =
                _rightAnswers.Zip(userUserAnswers, (word, ans) => new ResultForUpdateStorage(word, ans.UserMakeRightChoice));
            return infoForUpdateProgress;
        }

        private SprintTrainingResult ProcessUserAnswers(UserAnswers<bool> userAnswers) {
            if (userAnswers.Count() != _amountWordsForTraining) {
                throw new ArgumentException(
                    $"{nameof(userAnswers)} comes wrong amount of answers. Expected {_amountWordsForTraining}");
            }
            var result = new SprintTrainingResult(userAnswers, _trainingWords, _rightAnswers);
            return result;
        }
        
         private (Words, Words) GenerateWordsForTraining() {
            var wordsWithRightAnswer = _wordsStorage.GenerateUnlearntWords(_amountWordsForTraining);
            var wordsWithWrongAnswers = GenerateWordsWithWrongAnswers(wordsWithRightAnswer);

            //var wordsWithWrongAnswersShuffled = ShuffleWords(wordsWithWrongAnswers); <== return wordsWithWrongAnswersShuffled instead wordsWithWrongAnswers for shuffle 
            return (wordsWithRightAnswer, wordsWithWrongAnswers);
        }
         
        private static Words ShuffleWords(Words wordsWithWrongAnswers) {
            return new Words(wordsWithWrongAnswers
                .OrderBy(x => Guid.NewGuid())
                .ToList());
        }

        //without ShuffleWords[1] first [amountWordsForReplaceWithWrongAnswers] RusDefinition will be replace with wrongDefinition
        //another will be always right 
        private Words GenerateWordsWithWrongAnswers(Words wordsWithRightAnswer) {
            var wordsListWithWrongAnswers = MakeCopyOfWords(wordsWithRightAnswer); //deep copy
            var amountWordsForReplaceWithWrongAnswers = CalculateAmountOfWrongAnswers();
            foreach (var unlearntWord in wordsListWithWrongAnswers) {
                var randomWord = GetRandomWord(unlearntWord);
                ReplaceRusDefinition(wordsListWithWrongAnswers, unlearntWord, randomWord);
                amountWordsForReplaceWithWrongAnswers--;
                if (amountWordsForReplaceWithWrongAnswers == 0) break; 
            }
            return new Words(wordsListWithWrongAnswers);
        }

        //TODO here infinite cycle if _wordsStorage has single word
        private Word GetRandomWord(Word unlearntWord) {
            Word randomWord;
            do {
                randomWord = _wordsStorage.GetRandomWord();
            } while (randomWord.RusDefinition == unlearntWord.RusDefinition);  
            return randomWord;
        }

        private static void ReplaceRusDefinition(List<Word> wordsListWithWrongAnswers, Word unlearntWord, Word randomWord) {
            var wordForReplaceRusDefinition = wordsListWithWrongAnswers.Find(w => w.EngDefinition == unlearntWord.EngDefinition);
            wordForReplaceRusDefinition?.ReplaceRusDefinition(randomWord.RusDefinition);
        }

        private static List<Word> MakeCopyOfWords(Words wordsWithRightAnswer) {
            return wordsWithRightAnswer.Select(word=> new Word(word.RusDefinition,word.EngDefinition)).ToList();
        }

        private int CalculateAmountOfWrongAnswers() {
            return Convert.ToInt32(_amountWordsForTraining * _rightWrongWordsRatio);
        }
    }
}