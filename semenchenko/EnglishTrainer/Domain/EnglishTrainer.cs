using EnglishTrainer.App;
using EnglishTrainer.App.Sprint;
using EnglishTrainer.App.Translate;
using EnglishTrainer.Lib;

namespace EnglishTrainer.Domain
{
    public class EnglishTrainer
    {
        private WordsContainer _container;
        private SprintExcercise _sprint;
        private TranslateExcercise _translate;
        private FileParser _fileParser;
        
        public EnglishTrainer(string path)
        {
            DefineWordsContainer(path);
        }

        public void DefineWordsContainer(string path)
        {
            _fileParser = new FileParser();
            _fileParser.GetFile(path);
            _container = new WordsContainer(_fileParser.GetWords());
        }
        
        public SprintExcercise BuildSprint()
        {
            WordPair[] wordPairs = _container.GetRandomSelect(15);
            string[] translations = new string[wordPairs.Length];
            for (int i = 0; i < wordPairs.Length; i++)
            {
                translations[i] = _container.GetRandomTranslate(wordPairs[i]);
            }
            
            _sprint = new SprintExcercise(wordPairs, translations);
            return _sprint;
        }

        public TranslateExcercise BuildTranslate()
        {
            WordPair[] wordPairs = _container.GetRandomSelect(10);
            _translate = new TranslateExcercise(wordPairs);
            return _translate;
        }

        public void AdjustContainer(SprintExcercise excercise)
        {
            _container.AdjustMatchedWords(excercise.WordPairs, excercise.CheckCorrectness());
        }
        
        public void AdjustContainer(TranslateExcercise excercise)
        {
            _container.AdjustTranslatedWords(excercise.WordPairs, excercise.CheckCorrectness());
        }
    }
}