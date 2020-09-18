using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTrainer
{
    public class SprintExercise : IExercise
    {
        private IReadOnlyList<WordForSprintExercise> Words { get; }

        public SprintExercise(IReadOnlyList<WordForSprintExercise> wordsForSprintExercise)
        {
            Words = wordsForSprintExercise;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var word in Words)
            {
                sb.Append(string.Join(", ", word.Translations.Take(word.Translations.Count-1)));
                sb.Append(word.Translations.TakeLast(1) + ".\n");
            }

            return sb.ToString();
        }

        public Result GetResult(List<string> userAnswers)
        {
            var parsedAnswers = ParseUserAnswers(userAnswers);
            
            var numberOfCorrectAnswers = Words
                .Zip(parsedAnswers, (word, userAns) => (word.WithWrongTranslations && !userAns)
                                                       || !word.WithWrongTranslations && userAns)
                .Count();
            var numberOfWrongAnswers = Words.Count - numberOfCorrectAnswers;
            
            return new Result(numberOfCorrectAnswers, numberOfWrongAnswers);
        }

        private IEnumerable<bool> ParseUserAnswers(IReadOnlyCollection<string> userAnswers)
        {
            if (userAnswers.Count != Words.Count)
                throw new ArgumentException();

            return userAnswers
                .Select(ans => ans == "y")
                .ToList();
        }
    }
}