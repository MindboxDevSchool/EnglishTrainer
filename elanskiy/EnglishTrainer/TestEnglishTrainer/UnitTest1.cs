using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using EnglishTrainer.Trainers;
using EnglishTrainer.Vocabularies;
using NUnit.Framework;
using TestEnglishTrainer.Services;

namespace TestEnglishTrainer
{
    public class Tests
    {
        private Vocabulary _vocabulary;
        private Vocabulary Vocabulary
        {
            get { return _vocabulary ??= new Vocabulary(new CSVService()); }
        }

        [Test]
        public void DefaultVocabulary_StartSprint_CatchException()
        {
            var sprint = new Sprint(Vocabulary);

            var resultOfStartSprint = sprint.Start();

            Assert.Throws<ApplicationException>(() => sprint.Start());
            Assert.Throws<ArgumentException>(() => sprint.NumberOfWordsToStudy = -10);
        }
        
        [Test]
        public void DefaultVocabulary_StartSprintAndGetResults_GetWordsToLearnAndGetResults()
        {
            var sprint = new Sprint(Vocabulary);
            var answers = new Dictionary<string, bool> {{"translation", false}, {"language", true}};

            var resultOfStartSprint = sprint.Start();
            var resultOfTraining = sprint.GetResults(answers);

            Assert.AreEqual(4, resultOfStartSprint.Count());
            Assert.NotNull(resultOfStartSprint.FirstOrDefault().word);
            Assert.NotNull(resultOfStartSprint.FirstOrDefault().translation);
            Assert.True(resultOfTraining.NumberOfMistakes < 5);
        }
        
        [Test]
        public void DefaultVocabulary_StartManualAndGetResults_GetWordsToLearnAndGetResults()
        {
            var manual = new Manual(Vocabulary);
            var answers = new Dictionary<string, string> {{"translation", "перевод"}, {"language", "маленький"}};

            var resultOfStartManual = manual.Start();
            var resultOfTraining = manual.GetResults(answers);

            Assert.AreEqual(4, resultOfStartManual.Count());
            Assert.NotNull(resultOfStartManual.FirstOrDefault());
            Assert.True(resultOfTraining.NumberOfCorrectAnswer == 1);
        }
    }
}