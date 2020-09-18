using System;
using System.IO;
using EnglishTrainer.Domain;
using EnglishTrainer.Infrastructure;

namespace EnglishTrainerHandyTester
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            string filename = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.Parent?.FullName + 
                              "\\EnglishTrainer\\TestData.csv";
            SprintTrainerCreator trainerCreator = 
                new SprintTrainerCreator(filename, DefaultUserInteractor.ConsoleTrainer, 5);
            trainerCreator.StartTraining();
            DefaultUserInteractor.ConsoleResult(trainerCreator.TrainingResult);
            
        }

    }
}