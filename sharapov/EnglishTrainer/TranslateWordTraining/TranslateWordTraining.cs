using System;
using System.Linq;

namespace EnglishTrainer.TranslateWordTraining {
    public class TranslateWordTraining {
         private readonly int _amountWordsForTraining;
         private readonly WordsStorage _wordsStorage;
         private readonly Words _trainingWords;

         public TranslateWordTraining(WordsStorage wordsStorage, int amountWordsForTraining = 10) {
             _amountWordsForTraining = amountWordsForTraining;
             _wordsStorage = wordsStorage;
             _trainingWords = GenerateWordsForTraining();
         }
         
         //words to user (domain -> infrastructure) 
         public EnglishWords GetTrainingWords() {
             return new EnglishWords(_trainingWords);
         }
        
         //result from user to domain (infrastructure -> domain) 
         //answers should have same order as a Words from GetTrainingWords()
         public TranslateWordTrainingResult ReportAboutTrainingResult(UserAnswers<string> userUserAnswers) {
             var result = ProcessUserAnswers(userUserAnswers); 
             var infoForUpdateProgress = result.Select(r => new ResultForUpdateStorage(r.Word, r.IsAnswerWasRight));
             _wordsStorage.UpdateProgress(infoForUpdateProgress);
             return result;
         }
         
         private TranslateWordTrainingResult ProcessUserAnswers(UserAnswers<string> userAnswers) {
             if (userAnswers.Count() != _amountWordsForTraining) {
                 throw new ArgumentException($"{nameof(userAnswers)} comes wrong amount of answers. Expected {_amountWordsForTraining}");
             }
             var result = TranslateWordTrainingResult.Create(userAnswers, _trainingWords);
             return result;
         }

         private Words GenerateWordsForTraining() {
             var wordsWithRightAnswer = _wordsStorage.GenerateUnlearntWords(_amountWordsForTraining);
             return wordsWithRightAnswer;
         }
    }
    
   
    
    
}