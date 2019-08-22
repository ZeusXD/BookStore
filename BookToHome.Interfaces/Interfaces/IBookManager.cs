using System.Collections.Generic;
using BookToHome.Models;

namespace BookToHome.Interfaces
{
    public interface IBookManager
    {
        Result<BookStore> AddBook(BookStore book);

        Result<IList<BookStore>> ListStoredBooks();

        Result<IList<BookStore>> ListMinimunStockBooks();
    }
}