using System;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class RuleValidationBookQuantity : IRuleValidation
    {
        public void BuildException<T>(T obj)
        {
            var book = obj as BookStore;

            if(book.Quantity < 0)
            {
                throw new Exception($"Quantity: {book.Quantity}, must be a positive number");
            }
        }
    }
}