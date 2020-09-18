using System.Collections.Generic;

namespace EnglishTrainer
{
    public class Word
    {
        public Word(
            string spelling,
            List<string> translations,
            int correctlyGuessedByUserCount = 0)
        {
            Spelling = spelling;
            Translations = translations;
            CorrectlyGuessedByUserCount = correctlyGuessedByUserCount;
        }

        public string Spelling { get; }
        public List<string> Translations { get; }
        public int CorrectlyGuessedByUserCount { get; }
        public bool IsLearned => CorrectlyGuessedByUserCount >= 3;

        public override string ToString()
        {
            return $"{Spelling} - {string.Join(", ", Translations)}";
        }
    }
}