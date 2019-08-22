using System;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class RuleValidationBookStoreNull : IRuleValidation
    {
        public void BuildException<T>(T obj)
        {
            var book = obj as BookStore;
            if (book is null)
            {
                throw new ArgumentNullException("Book is not stored");
            } 
        }
    }
}