namespace EnglishTrainer.TranslateWordTraining {
    public class WordLearnInfo {
        public Word Word { get; }
        public string UserInputRusDefinition { get; }
        public bool IsAnswerWasRight { get; }

        public WordLearnInfo(Word word, string userInputRusDefinition, bool isAnswerWasRight) {
            Word = word;
            UserInputRusDefinition = userInputRusDefinition;
            IsAnswerWasRight = isAnswerWasRight;
        }
    }
}