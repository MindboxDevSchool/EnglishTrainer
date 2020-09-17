using System.Collections.Generic;

namespace EnglishTrainer
{
    public class EnglishWord
    {
        public EnglishWord(
            string englishSpelling,
            string transcription,
            List<string> russianTranslations,
            int correctlyGuessedByUserCount = 0)
        {
            EnglishSpelling = englishSpelling;
            RussianTranslations = russianTranslations;
            Transcription = transcription;
            CorrectlyGuessedByUserCount = correctlyGuessedByUserCount;
        }

        public string EnglishSpelling { get; }
        public string Transcription { get; }
        public List<string> RussianTranslations { get; }
        public int CorrectlyGuessedByUserCount { get; }
        public bool IsLearned => CorrectlyGuessedByUserCount > 3;
    }
}