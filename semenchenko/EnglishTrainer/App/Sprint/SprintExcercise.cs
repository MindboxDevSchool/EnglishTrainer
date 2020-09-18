using EnglishTrainer.Domain;

namespace EnglishTrainer.App.Sprint
{
    public class SprintExcercise : Excercise
    {
        private SprintQuestion Question { get; }
        private Answer<bool> Answer { get; }
        public SprintExcercise(WordPair[] pairs, string[] offered) : base(pairs)
        {
            Length = 15;
            Question = new SprintQuestion(pairs, offered);
            Answer = new Answer<bool>(Length);
        }

        public override bool[] CheckCorrectness()
        {
            for (int i = 0; i < Question.CorrectTranslation.Length; i++)
            {
                Answer.MarkSubAnswer(Question.CorrectTranslation[i] == Question.OfferedTranslate[i]);
            }

            return Answer.IsCorrect.ToArray();
        }


    }
} 