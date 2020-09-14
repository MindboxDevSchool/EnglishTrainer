using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public class TaskManager
    {
        private List<WordInDictionary> _dictionary;

        private List<WordInDictionary> GetRandomWords(int amount)
        {
            Random rnd = new Random();
            int randomIndex;
            var result = new List<WordInDictionary>();
            
            while (result.Count < amount)
            {
                randomIndex = rnd.Next(_dictionary.Count);
                if (_dictionary[randomIndex].AmountOfSuccsessfulTranslations < 3)
                {
                    result.Add(_dictionary[randomIndex]);
                }
                else
                {
                    _dictionary.Remove(_dictionary[randomIndex]);
                }
            }
            return result;
        }

        public Dictionary<WordInDictionary,string> GiveTaskSprint()
        {
            var randomWords = GetRandomWords(15);
            var result = new Dictionary<WordInDictionary,string>();
            Random rnd = new Random();
            int randomIndex;
            
            for (int i = 0; i < randomWords.Count; i++)
            {
                if (rnd.Next(10) < 5)
                {
                    result[randomWords[i]] = randomWords[i].Russian;
                }
                else
                {
                    randomIndex = rnd.Next(_dictionary.Count);
                    result[randomWords[i]] = _dictionary[randomIndex].Russian;
                }
            }
            return result;
        }
        
        public List<WordInDictionary> GiveTaskTranslation()
        {
            return GetRandomWords(10);
        }

        public TaskResult CheckTaskSprint(Dictionary<WordInDictionary,string> task, List<bool> answers)
        {
            if (task.Count != answers.Count)
            {
                throw new ArgumentException("The amount of answers isn't right");
            }
            
            var results = new TaskResult();
            int i = 0;
            foreach (var item in task)
            {
                if ((item.Key.Russian == item.Value) == answers[i])
                {
                    results.AddCorrectAnswer(item.Key);
                    _dictionary.Find(word => word.Equals(item.Key))?.IncrementAmountOfSuccsessfulTranslations();
                }
                else
                {
                    results.AddIncorrectAnswer(item.Key);
                    _dictionary.Find(word => word.Equals(item.Key))?.ResetAmountOfSuccsessfulTranslations();
                }
                
                i++;
            }

            return results;
        }

        public TaskResult CheckTaskTranslation(List<WordInDictionary> task, List<string> answers)
        {
            if (task.Count != answers.Count)
            {
                throw new ArgumentException("The amount of answers isn't right");
            }
            var results = new TaskResult();

            for (int i = 0; i < task.Count; i++)
            {
                if (task[i].Russian == answers[i])
                {
                    results.AddIncorrectAnswer(task[i]);
                    _dictionary.Find(word => word.Equals(task[i]))?.ResetAmountOfSuccsessfulTranslations();
                }
                else
                {
                    results.AddIncorrectAnswer(task[i]);
                    _dictionary.Find(word => word.Equals(task[i]))?.ResetAmountOfSuccsessfulTranslations();
                }
            }

            return results;
        }
    }
}