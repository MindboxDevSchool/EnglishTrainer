namespace LanguageTrainer.model
{
    class PracticedWord
    {
        private const int TimesToLearn = 3;
        
        public string Word { get; }
        public int Sprints { get; set; } = 0;
        public int Translations { get; set; } = 0;
        public bool Learned => Sprints + Translations >= TimesToLearn;

        public PracticedWord(string word)
        {
            Word = word;
        }
    }
}