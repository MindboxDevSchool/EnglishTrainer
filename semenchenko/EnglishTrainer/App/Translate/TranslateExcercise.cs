using System.IO;
using EnglishTrainer.Domain;

namespace EnglishTrainer.App.Translate
{
    public class TranslateExcercise : Excercise
    {
        private TranslateQuestion Question { get; }
        private Answer<string> Answer { get; }
        public TranslateExcercise(WordPair[] pairs) : base(pairs)
        {
            Length = 10;    
            Question = new TranslateQuestion(pairs);
            Answer = new Answer<string>(Length);
        }

        public override bool[] CheckCorrectness()
        {
            if (Question.CorrectTranslation.Length != Answer.SubAnswers.Count)
            {
                throw new InvalidDataException();
            }
            
            for (int i = 0; i < Answer.SubAnswers.Count; i++)
            {
                Answer.MarkSubAnswer(Answer.SubAnswers[i] == Question.CorrectTranslation[i]);
            }

            return Answer.IsCorrect.ToArray();
        }
    }
}