using System;
using System.Collections.Generic;
using System.Linq;
using BookToHome.Interfaces;
using BookToHome.Models;
using BookToHome.Utils;

namespace BookToHome.Logic
{
    public class BookRental : IBookRental
    {
        private readonly IBookData bookData;
        private RuleContext ruleContext;
        public BookRental(IBookData bookData)
        {
            this.bookData = bookData;
            ruleContext = new RuleContext();
        }

        public Result<string> RentBook(RentBook rent)
        {
            Func<int, int, int> delegateRentBook = (currentStock, rentQuantity) => currentStock - rentQuantity;
            return RentReturnBook(rent, delegateRentBook);
        }

        public Result<string> ReturnBook(RentBook rent)
        {
            Func<int, int, int> delegateReturnBook = (currentStock, rentQuantity) => currentStock + rentQuantity;
            return RentReturnBook(rent, delegateReturnBook);
        }

        private Result<string> RentReturnBook(RentBook rent, Func<int, int, int> delegateOpeBook)
        {
            var result = new Result<string>();

            try
            {
                ruleContext.RuleValidation(rent);
                
                var booksStored = bookData.GetStoredBooks();

                var bookToRent = booksStored.Find(b => b.Book.Title == rent.BookStore.Book.Title);
                
                ruleContext.RuleValidation(bookToRent);

                foreach (var item in booksStored)
                {
                    if(item.Book.Title == bookToRent.Book.Title)
                    {
                        item.Quantity = delegateOpeBook(item.Quantity, rent.BookStore.Quantity);
                    }
                }

                var bookInStock = booksStored.Find(b => b.Book.Title == rent.BookStore.Book.Title);

                result.Message = "Successful";
                result.Successful = true;
                result.Content = $"the store has {bookInStock.Quantity} units of a book titled {bookInStock.Book.Title}";
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Message = ex.Message;
            }

            return result;
        }

    }
}