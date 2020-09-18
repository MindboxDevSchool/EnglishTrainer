using System;

namespace EnglishTrainer
{
    public class Optional<T>
    {
        public Optional(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            
            Value = value;
            HasValue = true;
        }

        public Optional()
        {
            HasValue = false;
        }
        
        public T Value { get; }
        
        public bool HasValue { get; }
    }
}