using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class TaskManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GiveTaskSprint_returnsCorrectTask()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            var tasker = new TaskManager(list);

            var taskSprint = tasker.GiveTaskSprint(2);
            var key1 =  taskSprint.Keys.First();
            
            Assert.AreEqual(2,taskSprint.Count);
            Assert.IsTrue((key1.English == "Cat" && key1.Russian == "Кошка")|| 
                          (key1.English == "Dog" && key1.Russian == "Собака"));
            Assert.IsTrue(taskSprint[word1] == "Кошка" || taskSprint[word1] == "Собака");
        }

        [Test]
        public void GiveTaskSprint_NeagativeLengthTask_throwsException()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            var tasker = new TaskManager(list);
            
            Assert.Throws<ArgumentException>(()=>tasker.GiveTaskSprint(-1));
        }
        
        [Test]
        public void GiveTaskSprint_TaskIsBiggerThanPresentedDictionary_throwsException()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            var tasker = new TaskManager(list);
            
            Assert.Throws<ArgumentException>(()=>tasker.GiveTaskSprint(3));
        }
        
        [Test]
        public void GiveTaskTranslation_NeagativeLengthTask_throwsException()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            var tasker = new TaskManager(list);
            
            Assert.Throws<ArgumentException>(()=>tasker.GiveTaskTranslation(-1));
        }
        
        [Test]
        public void GiveTaskTranslation_ReturnsCorrectTask()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            var tasker = new TaskManager(list);
            var task =  tasker.GiveTaskTranslation(2);
            
            Assert.AreEqual(2,task.Count);
            Assert.IsTrue((task[0].English == "Cat" && task[0].Russian == "Кошка")|| 
                          (task[0].English == "Dog" && task[0].Russian == "Собака"));
        }
        
        [Test]
        public void GiveTaskTranslation_TaskIsBiggerThanPresentedDictionary_throwsException()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            var tasker = new TaskManager(list);
            
            Assert.Throws<ArgumentException>(()=>tasker.GiveTaskSprint(3));
        }
        
        [Test]
        public void CheckTaskSprint_AllAnswersCorrect()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            
            var task = new Dictionary<WordInDictionary, string>();
            task[word1] = word1.Russian;
            task[word2] = word1.Russian;
            var answers = new List<bool>();
            answers.Add(true);
            answers.Add(false);
            
            var checker = new TaskManager(list);

            var result = checker.CheckTaskSprint(task, answers);
            
            Assert.AreEqual(2, result.AmountOfCorrect);
            Assert.AreEqual(0, result.AmountOfIncorrect);
            
            Assert.AreEqual("Cat",result.CorrectAnswers[0].English);
            Assert.AreEqual("Кошка",result.CorrectAnswers[0].Russian);
            Assert.AreEqual(1,result.CorrectAnswers[0].AmountOfSuccsessfulTranslations);
            
            Assert.AreEqual(1,list[0].AmountOfSuccsessfulTranslations);
        }
        
        [Test]
        public void CheckTaskSprint_AllAnswersIncorrect()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            
            var task = new Dictionary<WordInDictionary, string>();
            task[word1] = word1.Russian;
            task[word2] = word1.Russian;
            var answers = new List<bool>();
            answers.Add(false);
            answers.Add(true);
            
            var checker = new TaskManager(list);

            var result = checker.CheckTaskSprint(task, answers);
            
            Assert.AreEqual(0, result.AmountOfCorrect);
            Assert.AreEqual(2, result.AmountOfIncorrect);
            
            Assert.AreEqual("Cat",result.IncorrectAnswers[0].English);
            Assert.AreEqual("Кошка",result.IncorrectAnswers[0].Russian);
            Assert.AreEqual(0,result.IncorrectAnswers[0].AmountOfSuccsessfulTranslations);
        }
        
        [Test]
        public void CheckTaskTranslation_AllAnswersCorrect()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            
            var task = new List<WordInDictionary>();
            task.Add(word1);
            task.Add(word2);
            var answers = new List<string>();
            answers.Add(word1.Russian);
            answers.Add(word2.Russian);
            
            var checker = new TaskManager(list);

            var result = checker.CheckTaskTranslation(task, answers);
            
            Assert.AreEqual(2, result.AmountOfCorrect);
            Assert.AreEqual(0, result.AmountOfIncorrect);
            
            Assert.AreEqual("Cat",result.CorrectAnswers[0].English);
            Assert.AreEqual("Кошка",result.CorrectAnswers[0].Russian);
            Assert.AreEqual(1,result.CorrectAnswers[0].AmountOfSuccsessfulTranslations);
            
            Assert.AreEqual(1,list[0].AmountOfSuccsessfulTranslations);
        }
        
        [Test]
        public void CheckTaskTranslation_AllAnswersIncorrect()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            
            var task = new List<WordInDictionary>();
            task.Add(word1);
            task.Add(word2);
            var answers = new List<string>();
            answers.Add(word2.Russian);
            answers.Add(word1.Russian);
            
            var checker = new TaskManager(list);

            var result = checker.CheckTaskTranslation(task, answers);
            
            Assert.AreEqual(0, result.AmountOfCorrect);
            Assert.AreEqual(2, result.AmountOfIncorrect);
            
            Assert.AreEqual("Cat",result.IncorrectAnswers[0].English);
            Assert.AreEqual("Кошка",result.IncorrectAnswers[0].Russian);
            Assert.AreEqual(0,result.IncorrectAnswers[0].AmountOfSuccsessfulTranslations);
        }
    }
}