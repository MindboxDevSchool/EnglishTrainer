using System.Collections.Generic;

namespace EnglishTrainer
{
    public interface IExercise
    {
        public Result GetResult(List<string> userAnswers);
    }
}