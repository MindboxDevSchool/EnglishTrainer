using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Contracts;
using EnglishTrainer.Vocabularies;

namespace EnglishTrainer.Trainers
{
    public class Manual : Trainer<Dictionary<string,string>,List<string>>
    {
        public Manual(Vocabulary vocabulary) : base(vocabulary)
        {
            NumberOfWordsToStudy = 10;
        }
        protected override List<string> MakeWordsToTrain() 
            => Vocabulary
                .Words
                .Where(e => !e.IsLearnedWord).Take(NumberOfWordsToStudy)
                .Select(e => e.Translation)
                .ToList();
        protected override (int correctAnswers, int errorAnswers, List<string> guessedWords) 
            CheckAnswers(Dictionary<string, string> answers)
        {
            var guessedWords = answers
                .Where(word
                    => Vocabulary.Words.Any(e => e.Value == word.Key && e.Translation == word.Value))
                .Select(e => e.Key)
                .ToList();

            return (guessedWords.Count(), answers.Count() - guessedWords.Count(), guessedWords);
        }
    }
}