using System.Collections.Generic;
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
        public void Test1()
        {
            var list = new List<WordInDictionary>();
            var word1 = new WordInDictionary("Cat", "Кошка");
            list.Add(word1);
            var word2 = new WordInDictionary("Dog","Собака");
            list.Add(word2);
            var tasker = new TaskManager(list);

            var taskSprint = tasker.GiveTaskSprint(2);
            
            Assert.AreEqual(2,taskSprint.Count);
            Assert.IsTrue(taskSprint[word1] == "Кошка" || taskSprint[word1] == "Собака");
        }
    }
}