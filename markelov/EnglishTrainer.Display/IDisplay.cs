using System.Collections.Generic;

namespace EnglishTrainer.Display
{
    public interface IDisplay
    {
        public void Display(Dictionary<string, Word> dictionary, Result result);
    }
}