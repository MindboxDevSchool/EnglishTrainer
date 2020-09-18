using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DataAccess;
using EnglishTrainer;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = Assembly.GetExecutingAssembly().Location;
            var txtFilePath = Path.Combine(directory, @"..\..\..\..\..\english_words_with_translations.txt");

            var words = WordsFromFileParser.Parse(txtFilePath, WordFromStringParser.Parse);
            var factory = new ExerciseFactory(words);

            UserOutput.SelectExerciseMessage();

            var userInput = UserInput.GetInput();
            var exerciseType = ExerciseSelectionParser.Parse(userInput);

            IExercise exercise;
            
            switch (exerciseType)
            {
                case ExerciseType.Sprint:
                    exercise = factory.CreateSprintExercise(15, 5);
                    break;
                case ExerciseType.Translation:
                    exercise = factory.CreateTranslationExercise(10);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine(exercise);
            userInput = UserInput.GetInput();
            var result = exercise.GetResult(userInput.Split(" ").ToList());
            Console.WriteLine(result);
        }
    }
}