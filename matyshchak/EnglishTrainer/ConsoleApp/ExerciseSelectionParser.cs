using System;
using EnglishTrainer;

namespace ConsoleApp
{
    public class ExerciseSelectionParser
    {
        public static ExerciseType Parse(string input)
        {
            return input switch
            {
                "1" => ExerciseType.Sprint,
                "2" => ExerciseType.Translation,
                _ => throw new FormatException("User input is in incorrect format")
            };
        }
    }
}