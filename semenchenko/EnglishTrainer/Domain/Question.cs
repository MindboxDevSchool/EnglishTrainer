using EnglishTrainer.App;

namespace EnglishTrainer.Domain
{
    public class Question
    {
        public string[] QuestionWords { get; private set; }
        public string[] CorrectTranslation { get; private set; }

        public Question(WordPair[] pairs)
        {
            QuestionWords = new string[pairs.Length];
            CorrectTranslation = new string[pairs.Length];

            for (int i = 0; i < pairs.Length; i++)
            {
                QuestionWords[i] = pairs[i].ForeignLanguageWord;
                CorrectTranslation[i] = pairs[i].NativeLanguageWord;
            }
        }
    }
}