using System;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class RuleValidationBookQuality : IRuleValidation
    {
        public void BuildException<T>(T obj)
        {
            var book = obj as BookStore;

            new StrategyContext().StrategyTypeQuality(book);
 
        }
    }

}