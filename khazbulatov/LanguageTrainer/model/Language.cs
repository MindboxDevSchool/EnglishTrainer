using System;

namespace LanguageTrainer.model
{
    public class Language
    {
        public string Name { get; }

        public Language(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
