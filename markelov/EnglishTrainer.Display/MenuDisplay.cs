using System;
using System.Collections.Generic;

namespace EnglishTrainer.Display
{
    public class MenuDisplay : IDisplay
    {
        public void Display(Dictionary<string, Word> dictionary, Result result)
        {
            while (true)
            {
                Console.WriteLine("Pick up the type of exercise: ");
                Console.WriteLine("A. Sprint");
                Console.WriteLine("B. Translation");
                string choice = Console.ReadLine();

                if (choice == "A")
                {
                    IDisplay sprintDisplay = new SprintDisplay();
                    sprintDisplay.Display(dictionary, result);
                }
                else if (choice == "B")
                {
                    IDisplay translationDisplay = new TranslationDisplay();
                    translationDisplay.Display(dictionary, result);
                }
                else
                {
                    continue;
                }

                break;
            }
        }
    }
}