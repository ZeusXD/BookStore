using System;
using System.Collections.Generic;
using System.Linq;
using BookToHome.Interfaces;
using BookToHome.Models;
using BookToHome.Utils;

namespace BookToHome.Logic
{
    public class BookManager : IBookManager
    {

        private readonly IBookData bookData;
        private readonly RuleContext ruleContext;
        public BookManager(IBookData bookData)
        {
            this.bookData = bookData;
            this.ruleContext = new RuleContext();
        }

        public Result<BookStore> AddBook(BookStore book)
        {
            var result = new Result<BookStore>();

            try
            {
                ruleContext.RuleValidation(book);

                bookData.AddBook(book);
                result.Successful = true;
                result.Message = $"the store has {book.Quantity} units of a book titled {book.Book.Title}";
                result.Content = book;
            }
            catch(Exception ex)
            {
                result.Successful = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result<IList<BookStore>> ListStoredBooks()
        {
            var result = new Result<IList<BookStore>>();

            try
            {
                result.Content = bookData.GetStoredBooks();
                result.Successful = true;
                result.Message = "List of books";
            }
            catch(Exception ex)
            {
                result.Successful = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result<IList<BookStore>> ListMinimunStockBooks()
        {
            var result = new Result<IList<BookStore>>();

            try
            {
                var booksMinimunStock = bookData.GetStoredBooks().Where(b =>
                    b.Quantity <= b.MinimunStock
                ).ToList();
                
                result.Content = booksMinimunStock;
                result.Successful = true;
                result.Message = "List of books with minimun stock";
            }
            catch(Exception ex)
            {
                result.Successful = false;
                result.Message = ex.Message;
            }

            return result;
        }

    }
}