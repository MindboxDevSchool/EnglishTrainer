using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Vocabularies;

namespace EnglishTrainer.Trainers
{
    public class Sprint : Trainer<Dictionary<string,bool>,List<(string word,string translation)>>
    {
        private Dictionary<string, bool> WordsToLearn { get; set; } = new Dictionary<string, bool>();
        public Sprint(Vocabulary vocabulary) : base(vocabulary)
        {
            NumberOfWordsToStudy = 15;
        }
        protected override List<(string word,string translation)> MakeWordsToTrain()
            => Vocabulary
                .Words
                .Where(e => !e.IsLearnedWord)
                .Take(NumberOfWordsToStudy)
                .Select(MixWords)
                .ToList();
        protected override (int correctAnswers, int errorAnswers, List<string> guessedWords) 
            CheckAnswers(Dictionary<string, bool> answers)
        {
            var guessedWords = answers
                .Where(answer
                    => WordsToLearn.ContainsKey(answer.Key) && WordsToLearn[answer.Key] == answer.Value)
                .Select(e => e.Key)
                .ToList();

            return (guessedWords.Count(), answers.Count() - guessedWords.Count(), guessedWords);
        }
        private (string word, string translation) MixWords(Word word)
        {
            var rand = new Random();
            string translation = null;
            
            if (rand.Next(1, 100) < 50)
            {
                WordsToLearn.Add(word.Value, false);
                translation = Vocabulary.Words.ElementAt(rand.Next(0, Vocabulary.Words.Count())).Translation;
            }
            else
                WordsToLearn.Add(word.Value, true);

            return (word.Value, translation ?? word.Translation);
        }
    }
}