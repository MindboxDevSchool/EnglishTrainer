namespace EnglishTrainer
{
    public class VocabularyWord
    {
        public Word Base { get; private set; }
        public bool IsStudied { get; private set; }

        private int _studyProgress;

        public VocabularyWord(string spelling, string translation)
        {
            Base = new Word(spelling, translation);
            IsStudied = false;
            _studyProgress = 0;
        }

        public void IncreaseStudyProgress()
        {
            _studyProgress++;

            if (_studyProgress == 3)
                IsStudied = true;
        }
    }
}