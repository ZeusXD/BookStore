using System;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class RuleValidationBookTitle : IRuleValidation
    {
        public void BuildException<T>(T obj)
        {
            var book = obj as BookStore;
            if (book.Book is null)
            {
                throw new Exception("Book should not by null");
            }
            if(book.Book.Title == string.Empty || book.Book.Title is null)
            {
                throw new Exception("Book title should not empty string");
            }
        }
    }
}