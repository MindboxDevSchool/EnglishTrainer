namespace EnglishTrainer.SprintTraining {
    public class WordLearnInfo {
        public string CorrectRusDefinition { get; }
        public string CorrectEngDefinition { get; }
        public string ProposedRusDefinition { get; }
        public bool UserMakeRightChoice { get; }

        public WordLearnInfo(string correctRusDefinition, string correctEngDefinition, string proposedRusDefinition, bool userMakeRightChoice) {
            CorrectRusDefinition = correctRusDefinition;
            CorrectEngDefinition = correctEngDefinition;
            ProposedRusDefinition = proposedRusDefinition;
            UserMakeRightChoice = userMakeRightChoice;
        }
    }
}