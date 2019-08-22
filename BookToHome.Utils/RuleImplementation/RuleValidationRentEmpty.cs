using System;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class RuleValidationRentEmpty : IRuleValidation
    {
        public void BuildException<T>(T obj)
        {
            var rent = obj as RentBook;

            if(rent.BookStore is null || rent.Customer is null)
            {
                throw new Exception("Customer or Book Store cant be nulls");
            }

        }
    }
}