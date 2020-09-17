using System;
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
            var txtFilePath = System.IO.Path.Combine(directory, @"..\..\..\..\..\english_words_with_translations.txt");
            
            var englishWordParser = new EnglishWordParser();
            var repository = new EnglishWordsTxtRepository(txtFilePath, englishWordParser);
            
            var sprintExercise = new SprintExercise(repository);
            
            var wordsWithWrongTranslations = sprintExercise.GetWords(15, 3);
            var words = repository.GetAllWords().ToList();
            //var wordsForSprintExercise = sprintExercise.GetWords(15, 3);

        }
    }
}