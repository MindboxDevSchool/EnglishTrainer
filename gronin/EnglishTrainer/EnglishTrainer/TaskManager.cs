using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public class TaskManager
    {
        public TaskManager(List<WordInDictionary> dictionary)
        {
            _dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }

        private List<WordInDictionary> _dictionary;

        private List<WordInDictionary> GetRandomWords(int amount)
        {
            if (amount > _dictionary.Count(elem => elem.AmountOfSuccsessfulTranslations < 3))
            {
                throw new ArgumentException("Not enough words in Dictionary");
            }

            Random rnd = new Random();
            return  _dictionary.Where(elem =>elem.AmountOfSuccsessfulTranslations<3)
                               .OrderBy(elem => rnd.Next())
                               .Take(amount).ToList();
        }

        public Dictionary<WordInDictionary,string> GiveTaskSprint(int amount)
        {
            if (amount < 1)
            {
                throw new ArgumentException("Amount of questions in task can't be less then 1");
            }

            var randomWords = GetRandomWords(amount);
            var result = new Dictionary<WordInDictionary,string>();
            Random rnd = new Random();

            for (int i = 0; i < randomWords.Count; i++)
            {
                if (rnd.Next(10) < 5)
                {
                    result[randomWords[i]] = randomWords[i].Russian;
                }
                else
                {
                    var randomIndex = rnd.Next(_dictionary.Count);
                    result[randomWords[i]] = _dictionary[randomIndex].Russian;
                }
            }
            return result;
        }
        
        public List<WordInDictionary> GiveTaskTranslation(int amount)
        {
            if (amount < 1)
            {
                throw new ArgumentException("Amount of questions in task can't be less then 1");
            }
            return GetRandomWords(amount);
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
                    results.AddCorrectAnswer(task[i]);
                    _dictionary.Find(word => word.Equals(task[i]))?.IncrementAmountOfSuccsessfulTranslations();
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