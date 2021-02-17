using System;

namespace JOS.Result.BlogExamples
{
    public class Hamburger
    {
        public Hamburger(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }
    }
}
