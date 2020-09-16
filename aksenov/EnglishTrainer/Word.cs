namespace EnglishTrainer
{
    public class Word
    {
        public string Spelling { get; private set; }
        
        public string Translation { get; private set; }
        
        public Word(string spelling, string translation)
        {
            Spelling = spelling;
            Translation = translation;
        }
    }
    
    public class VocabularyWord : Word
    {
        public VocabularyWordStatus Status { get; private set; }

        public VocabularyWord(string spelling, string translation): base(spelling, translation)
        {
            Status = VocabularyWordStatus.Studied;
        }
        
        public void TryChangeStatus(VocabularyWordStatus newStatus)
        {
            Status = newStatus;
        }
    }
    
    public enum VocabularyWordStatus
    {
        Studied,
        NotStudied
    }

    public class ProcessedWord : Word
    {
        public string ChoosedTranslation { get; private set; }
        
        public ProcessedWordStatus Status { get; private set; }

        public ProcessedWord(string spelling, string correctTranslation, string choosedTranslation, ProcessedWordStatus status): base(spelling, correctTranslation)
        {
            ChoosedTranslation = choosedTranslation;
            Status = status;
        }
    }
    
    public enum ProcessedWordStatus
    {
        Correct,
        Incorrect
    }
}