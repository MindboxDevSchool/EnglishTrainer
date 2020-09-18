namespace EnglishTrainer.SprintTraining {
    public class WordLearnInfo {
        public Word Word { get; }
        public string WrongRusDefinition { get; }
        public bool IsAnswerWasRight { get; }

        public WordLearnInfo(Word word, string wrongRusDefinition, bool isAnswerWasRight) {
            Word = word;
            WrongRusDefinition = wrongRusDefinition;
            IsAnswerWasRight = isAnswerWasRight;
        }
    }
}