using System;
using System.Linq;

namespace EnglishTrainer.TranslateWordTraining {
    public class TranslateWordTraining {
         private const int AmountWordsForTraining = 10;
         private readonly WordsStorage _wordsStorage;
         private readonly Words _trainingWords;

         public TranslateWordTraining(WordsStorage wordsStorage) {
             _wordsStorage = wordsStorage;
             _trainingWords = GenerateWordsForTraining();
         }
         
         //words to user (domain -> infrastructure) 
         public EnglishWords GetTrainingWords() {
             return new EnglishWords(_trainingWords);
         }
        
         //result from user to domain (infrastructure -> domain) 
         public TranslateWordTrainingResult ReportAboutTrainingResult(Answers<string> userAnswers) {
             var result = ProcessUserAnswers(userAnswers); 
             var infoForUpdateProgress = result.Select(r => new ResultForUpdateStorage(r.Word, r.IsAnswerWasRight));
             _wordsStorage.UpdateProgress(infoForUpdateProgress);
             return result;
         }
         
         private TranslateWordTrainingResult ProcessUserAnswers(Answers<string> answers) {
             if (answers.Count() != AmountWordsForTraining) {
                 throw new ArgumentException($"{nameof(answers)} comes wrong amount of answers. Expected {AmountWordsForTraining}");
             }
             var result = TranslateWordTrainingResult.Create(answers, _trainingWords);
             return result;
         }

         private Words GenerateWordsForTraining() {
             var wordsWithRightAnswer = _wordsStorage.GenerateUnlearntWords(AmountWordsForTraining);
             return wordsWithRightAnswer;
         }
    }
    
   
    
    
}