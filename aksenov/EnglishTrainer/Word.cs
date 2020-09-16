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

        private int _studyProgress;

        public VocabularyWord(string spelling, string translation): base(spelling, translation)
        {
            Status = VocabularyWordStatus.NotStudied;
            _studyProgress = 0;
        }

        public void IncreaseStudyProgress()
        {
            _studyProgress++;

            if (_studyProgress == 3)
                Status = VocabularyWordStatus.Studied;
        }
    }
    
    public enum VocabularyWordStatus
    {
        Studied,
        NotStudied
    }
}