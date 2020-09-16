using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public abstract class Exercise
    {
        private Vocabulary _vocabulary;

        protected Exercise(Vocabulary vocabulary)
        {
            _vocabulary = vocabulary;
        }

        public abstract ExerciseData GenerateData();

        public List<ProcessedWord> CheckSolution(List<Word> words)
        {
            List<ProcessedWord> processedWords = new List<ProcessedWord>();
            
            foreach (var word in words)
            {
                var processedWord = _vocabulary.Words.First(w => w.Spelling == word.Spelling);
                if (processedWord.Translation == word.Translation)
                {
                    processedWords.Add(new ProcessedWord(processedWord.Spelling, processedWord.Translation,
                        word.Translation, ProcessedWordStatus.Correct));
                }
                else
                {
                    processedWords.Add(new ProcessedWord(processedWord.Spelling, processedWord.Translation,
                        word.Translation, ProcessedWordStatus.Incorrect));
                }
            }

            return processedWords;
        }
    }
}